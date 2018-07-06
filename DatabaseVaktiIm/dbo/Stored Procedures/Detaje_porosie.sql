CREATE PROCEDURE [dbo].[Detaje_porosie]
@id INT
AS
BEGIN
SELECT g.emriGatimit,poi.sasia,g.cmimi
FROM POROSI_ITEM poi INNER JOIN GATIM g
ON g.gatim_id=poi.gatim_id
WHERE poi.porosi_id=1
END