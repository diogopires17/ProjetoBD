CREATE PROCEDURE AddEquipamento
  @Nome NVARCHAR(255),
  @Categoria NVARCHAR(255),
  @IdAdministrador INT,
  @Disponivel BIT,
  @IdLocalizacao INT,
  @IdFornecedor INT,
  @Revisao DATETIME,
  @Preco DECIMAL(10,2),
  @IdTecnico INT
AS
BEGIN
  INSERT INTO Equipamento (nome, categoria, id_administrador, disponivel, id_localizacao, id_fornecedor, revisao, preco, id_tecnico)
  VALUES (@Nome, @Categoria, @IdAdministrador, @Disponivel, @IdLocalizacao, @IdFornecedor, @Revisao, @Preco, @IdTecnico);
END;
GO