

-- update a disponiblidade quando passa a data 
CREATE TRIGGER trg_UpdateEquipmentAvailability
ON Reserva
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF (UPDATE(data_fim))
    BEGIN
        UPDATE Equipamento
        SET disponivel = 1
        FROM Equipamento e
        INNER JOIN inserted i ON e.id_equipamento = i.id_equipamento
        WHERE i.data_fim <= GETDATE();
    END
END;
GO

-- disponibilidade de equipamento  quando se reserva
CREATE TRIGGER trg_UpdateEquipamentoDisponibilidade
ON Reserva
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Equipamento
    SET disponivel = 0
    FROM Equipamento E
    INNER JOIN inserted I ON E.id_equipamento = I.id_equipamento;  
END
GO


-- TRIGGER DE AUDIT DEPOIS DE ELIMINAR
CREATE TRIGGER trg_AuditDeleteEquipamento
ON dbo.Equipamento
AFTER DELETE
AS
BEGIN
    INSERT INTO EquipamentoAudit(deleted_id, deleted_at, operation, operation_date)
    SELECT d.id_equipamento, GETDATE(), 'DELETE', GETDATE()
    FROM deleted d;
END;
GO



-- TRIGGER DE AUDIT DEPOIS DE INSERIR
CREATE TRIGGER AfterInsertEquipamento
ON dbo.Equipamento
AFTER INSERT
AS
BEGIN
    INSERT INTO EquipamentoAudit (id_equipamento, nome, categoria, operation, operation_date)
    SELECT i.id_equipamento, i.nome, i.categoria, 'INSERT', GETDATE()
    FROM inserted i;
END;
GO


