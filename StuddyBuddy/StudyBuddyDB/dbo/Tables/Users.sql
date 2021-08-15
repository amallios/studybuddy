CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(MAX) NOT NULL, 
    [Firstname] NVARCHAR(50) NOT NULL, 
    [Lastname] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(MAX) NOT NULL,
    [Password] NVARCHAR(MAX) NOT NULL,
    [Active] BIT NOT NULL DEFAULT 1, 
  
)
