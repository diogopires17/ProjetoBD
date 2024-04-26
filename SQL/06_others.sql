
-- query para ir buscar as reservas no historico que um user fez 
DECLARE @IDUtilizador INT;
SET @IDUtilizador = 14;
SELECT h.*, e.nome AS EquipamentoNome
FROM HistoricoAluguer h
JOIN Reserva r ON h.id_reserva = r.id_reserva
JOIN Utilizador u ON r.id_utilizador = u.id_utilizador
JOIN Equipamento e ON r.id_equipamento = e.id_equipamento
WHERE u.id_utilizador = @IdUtilizador;
