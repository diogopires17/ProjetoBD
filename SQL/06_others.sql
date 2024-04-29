
-- query para ir buscar as reservas no historico que um user fez 
DECLARE @IDUtilizador INT;
SET @IDUtilizador = 14;
SELECT h.*, e.nome AS EquipamentoNome
FROM HistoricoAluguer h
JOIN Reserva r ON h.id_reserva = r.id_reserva
JOIN Utilizador u ON r.id_utilizador = u.id_utilizador
JOIN Equipamento e ON r.id_equipamento = e.id_equipamento
WHERE u.id_utilizador = @IdUtilizador;


-- query para fazer o gráfico das avaliaões médias

SELECT e.id_equipamento, e.nome AS EquipmentName, AVG(af.classificacao) AS AvgRating FROM Equipamento e LEFT JOIN Reserva r ON e.id_equipamento = r.id_equipamento LEFT JOIN AvaliacaoFeedback af ON r.id_reserva = af.id_reserva GROUP BY e.id_equipamento, e.nome


-- query para ver os equipamentos mais alugados
SELECT e.id_equipamento, e.nome AS EquipmentName, COUNT(r.id_equipamento) AS TotalReservations FROM Equipamento e LEFT JOIN Reserva r ON e.id_equipamento = r.id_equipamento GROUP BY e.id_equipamento, e.nome

--query para ver os tecnicos com mais manutencoes

SELECT tm.nome AS TechnicianName, COUNT(*) AS MaintenanceCount FROM TecnicoManutencao tm JOIN ManutencaoEquipamento me ON tm.id_tecnico = me.id_tecnico GROUP BY tm.nome


--query localizacoes com mais equipamentos
 Select l.id_localizacao, l.cidade AS LocationName, COUNT(e.id_localizacao) AS TotalEquipments FROM Localizacao l LEFT JOIN Equipamento e ON l.id_localizacao = e.id_localizacao GROUP BY l.id_localizacao, l.cidade


-- remove equipamento em cascata
@"
            BEGIN TRANSACTION;
        
            -- Exclui todas as reservas associadas ao equipamento
            DELETE FROM Reserva WHERE id_equipamento = @IdEquipamento;
        
            -- Remove a associação entre os técnicos e o equipamento
            UPDATE ManutencaoEquipamento SET id_equipamento = NULL WHERE id_equipamento = @IdEquipamento;
        
            -- Exclui o equipamento
            DELETE FROM Equipamento WHERE id_equipamento = @IdEquipamento;
        
            COMMIT TRANSACTION;
            ";

