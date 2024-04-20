USE master;  -- switch to the master database
GO

ALTER DATABASE aluguer_equipamentos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

--DROP DATABASE aluguer_equipamentos;
--GO

CREATE DATABASE aluguer_equipamentos;

GO

USE aluguer_equipamentos;

-- Utilizador (Cliente)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Utilizador')
BEGIN
CREATE TABLE Utilizador (
    id_utilizador INT IDENTITY(1,1) PRIMARY KEY,
    cc INT UNIQUE NOT NULL,
    nome NVARCHAR(255) NOT NULL,
    email NVARCHAR(255) UNIQUE NOT NULL,
    telefone VARCHAR(20) UNIQUE,
    endereco NVARCHAR(255),
    data_nascimento DATE NOT NULL,
    pass NVARCHAR(255) NOT NULL
);
END

-- Administrador
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Administrador')
BEGIN
    CREATE TABLE Administrador (
        id_administrador INT IDENTITY(1,1),
        cc INT UNIQUE NOT NULL,
        nome NVARCHAR(255),
        email NVARCHAR(255) UNIQUE NOT NULL,
        telefone VARCHAR(20) UNIQUE,
        pass NVARCHAR(255) NOT NULL
        PRIMARY KEY (id_administrador)    
    );
END


-- Localização
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Localizacao')
BEGIN
    CREATE TABLE Localizacao (
        id_localizacao INT IDENTITY(1,1),
        endereco NVARCHAR(255),
        cidade NVARCHAR(255),
        pais NVARCHAR(255),
        id_administrador INT,
        PRIMARY KEY (id_localizacao),
        FOREIGN KEY (id_administrador) REFERENCES Administrador(id_administrador) 
    );
END

-- Fornecedor
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Fornecedor')
BEGIN
    CREATE TABLE Fornecedor (
        id_fornecedor INT IDENTITY(1,1),
        nome NVARCHAR(255),
        email NVARCHAR(255) UNIQUE NOT NULL,
        telefone VARCHAR(20) UNIQUE,
        id_localizacao INT,
        PRIMARY KEY (id_fornecedor)    
    );
END


-- Equipamento
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Equipamento')
BEGIN
    CREATE TABLE Equipamento (
        id_equipamento INT IDENTITY(1,1) PRIMARY KEY,
        nome NVARCHAR(255),
        categoria NVARCHAR(255),
        disponivel BIT,
        id_localizacao INT,
        id_fornecedor INT,
        id_administrador INT,
		revisao DATE,
        FOREIGN KEY (id_localizacao) REFERENCES Localizacao(id_localizacao),
        FOREIGN KEY (id_fornecedor) REFERENCES Fornecedor(id_fornecedor),
        FOREIGN KEY (id_administrador) REFERENCES Administrador(id_administrador)
    );
END



-- Reserva
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Reserva')
BEGIN
CREATE TABLE Reserva (
    id_reserva INT IDENTITY(1,1) PRIMARY KEY,
    data_inicio DATETIME,
    data_fim DATETIME,
    duracao_aluguer INT,    
    id_utilizador INT,
    id_equipamento INT,
    FOREIGN KEY (id_utilizador) REFERENCES Utilizador(id_utilizador),
    FOREIGN KEY (id_equipamento) REFERENCES Equipamento(id_equipamento)
);
END

-- Transacao
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Transacao')
BEGIN
CREATE TABLE Transacao (
    id_transacao INT IDENTITY(1,1) PRIMARY KEY,
    valor DECIMAL(10, 2),
    MetodoPagamento NVARCHAR(255),
    desconto DECIMAL(10, 2),
    id_reserva INT,
    FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva),
);
END

-- Avaliação/Feedback
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'AvaliacaoFeedback')
BEGIN
    CREATE TABLE AvaliacaoFeedback (
        id_feedback INT IDENTITY(1,1),
        comentario NVARCHAR(255),
        classificacao SMALLINT, -- 1 a 5
        data_avaliacao DATETIME,
        id_utilizador INT,
        id_reserva INT,
        PRIMARY KEY (id_feedback),
        FOREIGN KEY (id_utilizador) REFERENCES Utilizador(id_utilizador),
        FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva)
    );
END



-- Histórico de Aluguer
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HistoricoAluguer')
BEGIN
    CREATE TABLE HistoricoAluguer (
        id_historico INT IDENTITY(1,1),
        data_aluguer DATETIME,
        id_equipamento INT,
        id_reserva INT,
        PRIMARY KEY (id_historico),
        FOREIGN KEY (id_equipamento) REFERENCES Equipamento(id_equipamento),
        FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva) 
    );
END



-- Seguro de Equipamento
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SeguroEquipamento')
BEGIN
    CREATE TABLE SeguroEquipamento (
        id_seguro INT IDENTITY(1,1),
        descricao NVARCHAR(MAX),
        id_equipamento INT,
        PRIMARY KEY (id_seguro),
        FOREIGN KEY (id_equipamento) REFERENCES Equipamento(id_equipamento)
    );
END

-- Técnico de Manutenção
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TecnicoManutencao')
BEGIN
    CREATE TABLE TecnicoManutencao(
        id_tecnico INT IDENTITY(1,1),
        nome NVARCHAR(255),
        telefone VARCHAR(20) UNIQUE,
        email NVARCHAR(255) UNIQUE NOT NULL,
        PRIMARY KEY (id_tecnico)
    );
END

-- Manutenção Equipamento
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ManutencaoEquipamento')
BEGIN
    CREATE TABLE ManutencaoEquipamento (
        id_manutencao INT IDENTITY(1,1),
        descricao NVARCHAR(MAX),
        id_equipamento INT,
        id_tecnico INT,
        PRIMARY KEY (id_manutencao),
        FOREIGN KEY (id_tecnico) REFERENCES TecnicoManutencao(id_tecnico),
        FOREIGN KEY (id_equipamento) REFERENCES Equipamento(id_equipamento)
    );
END



