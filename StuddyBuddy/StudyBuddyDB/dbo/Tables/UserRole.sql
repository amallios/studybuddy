CREATE TABLE [dbo].[UserRole]
(
	[UniqueId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [FK_UserRole_Users] FOREIGN KEY (UserId) REFERENCES Users([UniqueId]), 
    CONSTRAINT [FK_UserRole_Roles] FOREIGN KEY (RoleId) REFERENCES Roles([UniqueId]) 
)
