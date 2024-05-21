
-- OBTEM O RATING DO EQUIPAMENTO
CREATE FUNCTION dbo.GetAverageRating(@id_equipamento INT)
RETURNS FLOAT
AS
BEGIN
    DECLARE @avgRating FLOAT;
    SELECT @avgRating = AVG(af.classificacao)
    FROM Reserva r
    LEFT JOIN AvaliacaoFeedback af ON r.id_reserva = af.id_reserva
    WHERE r.id_equipamento = @id_equipamento;
    RETURN @avgRating;
END
GO

-- OBTEM AS RESERVAS
CREATE FUNCTION dbo.GetTotalReservations(@id_equipamento INT)
RETURNS INT
AS
BEGIN
    DECLARE @totalReservations INT;
    SELECT @totalReservations = COUNT(r.id_equipamento)
    FROM Reserva r
    WHERE r.id_equipamento = @id_equipamento;
    RETURN @totalReservations;
END
GO

-- OBTEM AS MANUTENCOES
CREATE FUNCTION dbo.GetTotalMaintenance(@id_tecnico INT)
RETURNS INT
AS
BEGIN
    DECLARE @totalMaintenance INT;
    SELECT @totalMaintenance = COUNT(m.id_tecnico)
    FROM ManutencaoEquipamento m
    WHERE m.id_tecnico = @id_tecnico;
    RETURN @totalMaintenance;
END
GO
-- OBTEM OS EQUIPAMENTOS POR LOCALIZACAO
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
GO