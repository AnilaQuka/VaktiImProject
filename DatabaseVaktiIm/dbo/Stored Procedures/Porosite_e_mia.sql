CREATE PROCEDURE [dbo].[Porosite_e_mia]
	@id int
AS
BEGIN
SELECT p.porosi_id,p.datetime_Porosi,p.status_porosie,SUM(poi.sasia*g.cmimi) AS Vlera
FROM POROSI p INNER JOIN POROSI_ITEM poi 
ON p.porosi_id=poi.porosi_id
INNER JOIN GATIM g
ON poi.gatim_id=g.gatim_id
WHERE p.klient_id=@id
GROUP BY p.porosi_id, p.datetime_Porosi,p.status_porosie
end
