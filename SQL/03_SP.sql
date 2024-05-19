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

-- obter hisórico das reservas para o feedback
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
