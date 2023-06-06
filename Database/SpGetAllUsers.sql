SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wilson Camacho
-- Create date: 22/05/2023
-- Description:	return all users of app
-- =============================================
CREATE PROCEDURE GetAllUsers
	-- Add the parameters for the stored procedure here	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT IDIdentifier, Name, LastName, Email, PhoneNumber, DateOfBirthday
	FROM Users
END
GO
