SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wilson Camacho
-- Create date: 22/05/2023
-- Description:	Remove user of app
-- =============================================
CREATE PROCEDURE DeleteUsers
	-- Add the parameters for the stored procedure here
	@IDIdentifier BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Users
	WHERE IDIdentifier = @IDIdentifier
END
GO
