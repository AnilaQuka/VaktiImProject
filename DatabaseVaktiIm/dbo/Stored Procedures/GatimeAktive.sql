-- =============================================
-- Author:		<Anila Quka>
-- Create date: <6/6/2018>
-- Description:	<te gjitha ato gatime qe jan te disponueshme per klientet>
-- =============================================
CREATE PROCEDURE GatimeAktive
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	Select * from Gatim
	where disponueshmeria = 1;
END
