CREATE VIEW dbo.EquipmentView AS
SELECT 
    E.id_equipamento,
    E.nome,
    E.disponivel,
    E.categoria,
    E.id_localizacao,
    E.preco,
    L.cidade
FROM 
    Equipamento E
INNER JOIN 
    localizacao L ON E.id_localizacao = L.id_localizacao;
GO