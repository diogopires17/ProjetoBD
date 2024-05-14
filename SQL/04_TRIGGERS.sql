

-- update a disponiblidade
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
