CREATE FUNCTION dbo.GetTotalEquipmentsByLocation(@id_localizacao INT)
RETURNS INT
AS
BEGIN
    DECLARE @totalEquipments INT;
    SELECT @totalEquipments = COUNT(e.id_localizacao)
    FROM Equipamento e
    WHERE e.id_localizacao = @id_localizacao;
    RETURN @totalEquipments;
END
