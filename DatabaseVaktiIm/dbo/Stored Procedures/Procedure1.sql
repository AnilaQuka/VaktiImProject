CREATE PROCEDURE [dbo].[Procedure1]
AS
BEGIN

select g.emriGatimit, pt.sasia,p.datetime_Porosi,p.adresa_id,p.klient_id,p.pergjegjes_id,p.porosi_id,p.status_porosie
from POROSI as p inner join POROSI_ITEM as pt
on p.porosi_id= pt.porosi_id
inner join GATIM as g 
on pt.gatim_id = g.gatim_id

END