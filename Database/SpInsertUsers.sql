SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Wilson Camacho
-- Create date: 22/05/2023
-- Description:	Create user of app
-- =============================================
CREATE PROCEDURE InsertUsers 
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

    INSERT INTO Users(IDIdentifier, Name, LastName, Email, PhoneNumber, DateOfBirthday)
	VALUES(@IDIdentifier, @Name, @LastName, @Email, @PhoneNumber, @DateOfBirthday)
END
GO
