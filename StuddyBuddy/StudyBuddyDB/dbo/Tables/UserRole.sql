﻿CREATE TABLE [dbo].[UserRole]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [RoleId] INT NOT NULL 
)
