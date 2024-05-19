CREATE INDEX idx_equipamento_localizacao ON Equipamento(id_localizacao);


-- acelera join entre  Equipamento e localizacao
CREATE INDEX idx_equipamento_id_localizacao ON Equipamento(id_localizacao);

-- acelera reservas por id de equipamento
CREATE INDEX idx_reserva_id_equipamento ON Reserva(id_equipamento);


-- numero de reservas por user id 
CREATE INDEX idx_reserva_id_utilizador ON Reserva(id_utilizador);


-- acelera as que usam a reserva p ir buscar dados
CREATE INDEX idx_reserva_id_reserva ON Reserva(id_reserva);

-- acelera querys que usam id fornecedor

CREATE INDEX idx_equipamento_id_fornecedor ON Equipamento(id_fornecedor);

-- querys id administradro

CREATE INDEX idx_equipamento_id_administrador ON Equipamento(id_administrador);

-- id do utilizador
CREATE INDEX idx_utilizador_id ON Utilizador(id_utilizador);
--  id do equipamento
CREATE INDEX idx_equipamento_id ON Equipamento(id_equipamento);
