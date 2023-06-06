SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wilson Camacho
-- Create date: 22/05/2023
-- Description:	Update user of app
-- =============================================
CREATE PROCEDURE UpdateUsers
	-- Add the parameters for the stored procedure here
	@IDIdentifier BIGINT,
	@Name VARCHAR(50),
	@LastName VARCHAR(50),
	@Email VARCHAR(200),
	@PhoneNumber BIGINT,
	@DateOfBirthday DATE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE Users
	SET Name = @Name,
	    LastName = @LastName,
		Email = @Email,
		PhoneNumber = @PhoneNumber,
		DateOfBirthday = @DateOfBirthday
	WHERE IDIdentifier = @IDIdentifier
END
GO
