-- =============================================
-- Author:		<Anila Quka>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Porosit_e_bera]
@id int	
AS
BEGIN

select g.emriGatimit, pt.sasia,p.status_porosie,a.pershkrimi,s.emri as emriKlientit,k.emri
from POROSI as p inner join POROSI_ITEM as pt on p.porosi_id= pt.porosi_id
inner join GATIM as g  ON pt.gatim_id = g.gatim_id
INNER JOIN ADRESA AS a ON p.adresa_id= a.adrese_id
INNER JOIN PERDORUES AS s  ON p.klient_id = s.perdorues_id 
INNER JOIN PERDORUES AS k ON p.pergjegjes_id = k.perdorues_id
WHERE p.porosi_id = @id

END