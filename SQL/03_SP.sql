-- SPS PARA O EQUIPAMENTO 

-- Stored Procedure para adicionar Equipamento
CREATE PROCEDURE AddEquipamento
    @Nome NVARCHAR(50),
    @Categoria NVARCHAR(50),
    @IdLocalizacao INT,
    @IdFornecedor INT,
    @Revisao DATETIME,
    @IdAdministrador INT,
    @Disponivel BIT,
    @Preco DECIMAL(18, 2),
    @IdTecnico INT
AS
BEGIN
    INSERT INTO Equipamento (nome, categoria, id_localizacao, id_fornecedor, revisao, id_administrador, disponivel, preco, id_tecnico)
    VALUES (@Nome, @Categoria, @IdLocalizacao, @IdFornecedor, @Revisao, @IdAdministrador, @Disponivel, @Preco, @IdTecnico);
END
GO

-- Stored Procedure para apagar Equipamento
CREATE PROCEDURE DeleteEquipamento
    @IdEquipamento INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DELETE FROM HistoricoAluguer
        WHERE id_equipamento = @IdEquipamento;

        DELETE FROM Reserva
        WHERE id_equipamento = @IdEquipamento;

        DELETE FROM ManutencaoEquipamento
        WHERE id_equipamento = @IdEquipamento;

        DELETE FROM Equipamento
        WHERE id_equipamento = @IdEquipamento;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO


-- obter equipamentos
CREATE PROCEDURE GetEquipamentos
AS
BEGIN
    SELECT E.*, L.cidade
    FROM Equipamento E
    INNER JOIN localizacao L ON E.id_localizacao = L.id_localizacao;
END
GO

-- obter equipamento por id
CREATE PROCEDURE GetEquipamentoById
    @IdEquipamento INT
AS
BEGIN
    SELECT *
    FROM Equipamento
    WHERE id_equipamento = @IdEquipamento;
END
GO

-- atualizar equipamento
CREATE PROCEDURE UpdateEquipamento
    @IdEquipamento INT,
    @Nome NVARCHAR(50),
    @Categoria NVARCHAR(50),
    @IdLocalizacao INT,
    @IdFornecedor INT,
    @Revisao DATETIME,
    @Disponivel BIT,
    @Preco DECIMAL(18, 2),
    @IdTecnico INT
AS
BEGIN
    UPDATE Equipamento
    SET nome = @Nome,
        categoria = @Categoria,
        id_localizacao = @IdLocalizacao,
        id_fornecedor = @IdFornecedor,
        revisao = @Revisao,
        disponivel = @Disponivel,
        preco = @Preco,
        id_tecnico = @IdTecnico
    WHERE id_equipamento = @IdEquipamento;
END
GO

---------------------------------------------------------- USER ----------------------

-- atulaizar disponibilidade dos equipamentos
CREATE PROCEDURE sp_CheckAndUpdateAvailability
AS
BEGIN
    DECLARE @CurrentDate DATETIME = GETDATE();
    UPDATE Equipamento
    SET disponivel = 1
    FROM Equipamento E
    INNER JOIN Reserva R ON E.id_equipamento = R.id_equipamento
    WHERE R.data_fim < @CurrentDate;

    INSERT INTO HistoricoAluguer (data_aluguer, id_equipamento, id_reserva)
    SELECT R.data_inicio, R.id_equipamento, R.id_reserva
    FROM Reserva R
    WHERE R.data_fim < @CurrentDate;
END;
GO
------------------------------------------------------------------------------------------------------


-----------------------------------------------------Feedback----------------------------------------

-- obter his rico das reservas para o feedback
CREATE PROCEDURE GetHistoricoAluguer
    @IdUtilizador INT
AS
BEGIN
    SELECT h.*, e.nome AS EquipamentoNome
    FROM HistoricoAluguer h
    JOIN Reserva r ON h.id_reserva = r.id_reserva
    JOIN Utilizador u ON r.id_utilizador = u.id_utilizador
    JOIN Equipamento e ON r.id_equipamento = e.id_equipamento
    WHERE u.id_utilizador = @IdUtilizador;
END
GO

-- inserir feedback
CREATE PROCEDURE InsertAvaliacaoFeedback
    @IdReserva INT,
    @Classificacao INT,
    @IdUtilizador INT,
    @DataAvaliacao DATETIME,
    @Comentario NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO AvaliacaoFeedback (id_reserva, classificacao, id_utilizador, data_avaliacao, comentario)
    VALUES (@IdReserva, @Classificacao, @IdUtilizador, @DataAvaliacao, @Comentario);
END
GO

-- reservas detalhes id 
CREATE PROCEDURE GetReservaDetails
    @IdReserva INT
AS
BEGIN
    SELECT h.*, e.nome AS EquipamentoNome
    FROM HistoricoAluguer h
    JOIN Reserva r ON h.id_reserva = r.id_reserva
    JOIN Equipamento e ON r.id_equipamento = e.id_equipamento
    WHERE h.id_reserva = @IdReserva;
END
GO

-- apagar reserva
CREATE PROCEDURE DeleteReserva
    @IdReserva INT
AS
BEGIN
    DELETE FROM Reserva WHERE id_reserva = @IdReserva;
END
GO


-- GRAFICOS

CREATE PROCEDURE dbo.GetEquipmentAverageRatings
AS
BEGIN
    SELECT e.id_equipamento, e.nome AS EquipmentName, dbo.GetAverageRating(e.id_equipamento) AS AvgRating 
    FROM Equipamento e;
END
GO

CREATE PROCEDURE dbo.GetEquipmentTotalReservations
AS
BEGIN
    SELECT e.id_equipamento, e.nome AS EquipmentName, dbo.GetTotalReservations(e.id_equipamento) AS TotalReservations 
    FROM Equipamento e;
END
GO



CREATE PROCEDURE dbo.GetTechnicianTotalMaintenance
AS
BEGIN
    SELECT t.id_tecnico, t.nome AS TechnicianName, dbo.GetTotalMaintenance(t.id_tecnico) AS TotalMaintenance 
    FROM TecnicoManutencao t;
END
GO

CREATE PROCEDURE dbo.GetLocationTotalEquipments
AS
BEGIN
    SELECT l.id_localizacao, l.cidade AS LocationName, dbo.GetTotalEquipmentsByLocation(l.id_localizacao) AS TotalEquipments 
    FROM Localizacao l;
END
GO	


--- inserir manutencao

CREATE PROCEDURE dbo.InsertMaintenance
@id_equipamento INT,
@id_tecnico INT,
@descricao NVARCHAR(MAX),
@data DATETIME
AS
BEGIN
    INSERT INTO MANUTENCAOEquipamento (id_equipamento, id_tecnico, descricao, data)
    VALUES (@id_equipamento, @id_tecnico, @descricao, @data);
END
GO


-- atualizar revisao

CREATE PROCEDURE dbo.UpdateEquipmentRevision
@id_equipamento INT,
@revisao DATETIME,
@id_tecnico INT
AS
BEGIN
    UPDATE Equipamento
    SET revisao = @revisao, id_tecnico = @id_tecnico
    WHERE id_equipamento = @id_equipamento;
END
GO


-- LOGIN

CREATE PROCEDURE dbo.LoginUser
    @Email NVARCHAR(50),
    @Password NVARCHAR(256)
AS
BEGIN
    SELECT id_utilizador
    FROM Utilizador
    WHERE email = @Email AND pass = @Password;
END
GO




CREATE PROCEDURE dbo.LoginAdmin
@Email NVARCHAR(50),
@Password NVARCHAR(50)
AS
BEGIN
    SELECT id_utilizador
    FROM Utilizador
    WHERE email = @Email AND pass = @Password AND email LIKE 'admin%';
END
GO


-- inserir reservas
CREATE PROCEDURE dbo.InsertReserva
    @DataInicio DATETIME,
    @DataFim DATETIME,
    @DuracaoAluguer INT,
    @IdUtilizador INT,
    @IdEquipamento INT,
    @Desconto INT,
    @IdReserva INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TempTable TABLE (id_reserva INT);

    INSERT INTO Reserva (data_inicio, data_fim, duracao_aluguer, id_utilizador, id_equipamento, desconto)
    OUTPUT INSERTED.id_reserva INTO @TempTable
    VALUES (@DataInicio, @DataFim, @DuracaoAluguer, @IdUtilizador, @IdEquipamento, @Desconto);

    SELECT @IdReserva = id_reserva FROM @TempTable;
END
GO

-- transacao
CREATE PROCEDURE dbo.InsertTransacao
@Valor DECIMAL(18, 2),
@MetodoPagamento NVARCHAR(50),
@IdReserva INT
AS
BEGIN
    INSERT INTO Transacao (valor, MetodoPagamento, id_reserva)
    VALUES (@Valor, @MetodoPagamento, @IdReserva);
END
GO

-- add user 
CREATE PROCEDURE dbo.AddUser
    @cc INT,
    @nome NVARCHAR(50),
    @email NVARCHAR(50),
    @telefone INT,
    @endereco NVARCHAR(100),
    @dataNascimento DATE,
    @pass NVARCHAR(256)
AS
BEGIN
    INSERT INTO Utilizador (cc, nome, email, telefone, endereco, data_nascimento, pass)
    VALUES (@cc, @nome, @email, @telefone, @endereco, @dataNascimento, @pass);
END
GO


EXEC dbo.LoginUser @Email = 'your-email@example.com', @Password = 'hashed_password_here';
SELECT id_utilizador FROM Utilizador WHERE email = 'bdd@gmail.com' AND pass = '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4';
