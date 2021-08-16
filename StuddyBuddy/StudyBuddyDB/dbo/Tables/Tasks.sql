CREATE TABLE [dbo].[Tasks]
(
	[UniqueId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ModuleId] INT NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    [Completed] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Tasks_Modules] FOREIGN KEY (ModuleId) REFERENCES Modules([UniqueId])
)
