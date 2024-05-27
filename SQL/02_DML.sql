-- inserir Utilizador
INSERT INTO Utilizador(cc, nome, email, telefone, endereco, data_nascimento, pass)
VALUES (123456789, 'João D', 'joão@ua.pt', '1234567890', '123 rua, cidade, pais', '1980-01-01', 'password');

-- inserir Administrador
INSERT INTO Administrador(cc, nome, email, telefone, pass)
VALUES (987654321, 'Admin', 'admin@ua.pt', '0987654321', 'adminpass');

-- inserir Localizacao
INSERT INTO Localizacao(endereco, cidade, pais, id_administrador)
VALUES (' avenida das amélias', 'Aveiro', 'Portugal', 1);

-- inserir Fornecedor
INSERT INTO Fornecedor(nome, email, telefone)
VALUES ('Fornecedor1', 'forncedor@ua.pt', '1122334455');

-- inserir Equipamento
INSERT INTO Equipamento(nome, categoria, disponivel, id_localizacao, id_fornecedor, id_administrador, revisao)
VALUES ('Mota de TT', 'Desporto terrestre', 1, 1, 1, 1, '2022-01-01');

-- inserir Reserva
INSERT INTO Reserva(data_inicio, data_fim, duracao_aluguer, id_utilizador, id_equipamento, desconto)
VALUES ('2022-02-01 10:00:00', '2022-02-01 12:00:00', 2, 1, 1, 12728);

-- inserir Transacao
INSERT INTO Transacao(valor, MetodoPagamento, id_reserva)
VALUES (100.00, 'Visa', 1);

-- inserir AvaliacaoFeedback
INSERT INTO AvaliacaoFeedback(comentario, classificacao, data_avaliacao, id_utilizador, id_reserva)
VALUES ('Great service!', 5, '2022-02-01 12:30:00', 1, 1);

-- inserir HistoricoAluguer
INSERT INTO HistoricoAluguer(data_aluguer, id_equipamento, id_reserva)
VALUES ('2022-02-01 12:00:00', 1, 1);

-- inserir SeguroEquipamento
INSERT INTO SeguroEquipamento(descricao, id_equipamento)
VALUES ('Seguro', 1);

-- inserir TecnicoManutencao
INSERT INTO TecnicoManutencao(nome, telefone, email)
VALUES ('Técnico', '2211334455', 'tecnico@ua.pt');

-- inserirManutencaoEquipamento
INSERT INTO ManutencaoEquipamento(descricao, id_equipamento, id_tecnico)
VALUES ('Mudar a correia', 1, 1);