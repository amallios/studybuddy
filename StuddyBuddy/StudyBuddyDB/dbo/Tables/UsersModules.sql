CREATE TABLE [dbo].[UsersModules]
(
	[UniqueId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [ModuleId] INT NOT NULL, 
    CONSTRAINT [FK_UsersModules_Users] FOREIGN KEY (UserId) REFERENCES Users(UniqueId), 
    CONSTRAINT [FK_UsersModules_Modules] FOREIGN KEY (ModuleId) REFERENCES Modules(UniqueId)
)
