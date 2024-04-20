-- Inserting data into Utilizador
INSERT INTO Utilizador(cc, nome, email, telefone, endereco, data_nascimento, pass)
VALUES (123456789, 'João D', 'johndoe@example.com', '1234567890', '123 Street, City, Country', '1980-01-01', 'password');

-- Inserting data into Administrador
INSERT INTO Administrador(cc, nome, email, telefone, pass)
VALUES (987654321, 'Admin', 'admin@example.com', '0987654321', 'adminpass');

-- Inserting data into Localizacao
INSERT INTO Localizacao(endereco, cidade, pais, id_administrador)
VALUES ('456 Avenue, City, Country', 'City', 'Country', 1);

-- Inserting data into Fornecedor
INSERT INTO Fornecedor(nome, email, telefone, id_localizacao)
VALUES ('Supplier', 'supplier@example.com', '1122334455', 1);

-- Inserting data into Equipamento
INSERT INTO Equipamento(nome, categoria, disponivel, id_localizacao, id_fornecedor, id_administrador, revisao)
VALUES ('Equipment', 'Category', 1, 1, 1, 1, '2022-01-01');

-- Inserting data into Reserva
INSERT INTO Reserva(data_inicio, data_fim, duracao_aluguer, id_utilizador, id_equipamento)
VALUES ('2022-02-01 10:00:00', '2022-02-01 12:00:00', 2, 1, 1);

-- Inserting data into Transacao
INSERT INTO Transacao(valor, MetodoPagamento, desconto, id_reserva)
VALUES (100.00, 'Credit Card', 0.00, 1);

-- Inserting data into AvaliacaoFeedback
INSERT INTO AvaliacaoFeedback(comentario, classificacao, data_avaliacao, id_utilizador, id_reserva)
VALUES ('Great service!', 5, '2022-02-01 12:30:00', 1, 1);

-- Inserting data into HistoricoAluguer
INSERT INTO HistoricoAluguer(data_aluguer, id_equipamento, id_reserva)
VALUES ('2022-02-01 12:00:00', 1, 1);

-- Inserting data into SeguroEquipamento
INSERT INTO SeguroEquipamento(descricao, id_equipamento)
VALUES ('Insurance Description', 1);

-- Inserting data into TecnicoManutencao
INSERT INTO TecnicoManutencao(nome, telefone, email)
VALUES ('Technician', '2211334455', 'technician@example.com');

-- Inserting data into ManutencaoEquipamento
INSERT INTO ManutencaoEquipamento(descricao, id_equipamento, id_tecnico)
VALUES ('Maintenance Description', 1, 1);