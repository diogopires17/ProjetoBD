-- SPS PARA O EQUIPAMENTO 

-- Stored Procedure to Add Equipment
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

-- Stored Procedure to Delete Equipment
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


-- Stored Procedure to Get All Equipment
CREATE PROCEDURE GetEquipamentos
AS
BEGIN
    SELECT E.*, L.cidade
    FROM Equipamento E
    INNER JOIN localizacao L ON E.id_localizacao = L.id_localizacao;
END
GO

-- Stored Procedure to Get Equipment by ID
CREATE PROCEDURE GetEquipamentoById
    @IdEquipamento INT
AS
BEGIN
    SELECT *
    FROM Equipamento
    WHERE id_equipamento = @IdEquipamento;
END
GO

-- Stored Procedure to Update Equipment
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


EXEC sp_CheckAndUpdateAvailability;
------------------------------------------------------------------------------------------------------


