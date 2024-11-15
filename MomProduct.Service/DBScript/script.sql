-- Check if the database MomProduct exists, and create it if it doesn't
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'MomProduct')
BEGIN
    -- Create the database
    CREATE DATABASE MomProduct;
END
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'MomProduct')
BEGIN
    USE MomProduct;
END
GO
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BlogType')
BEGIN
    CREATE TABLE BlogType (
        Id INT PRIMARY KEY IDENTITY(1,1),
        BlogName NVARCHAR(100) NOT NULL,
        Description NVARCHAR(500) NULL 
    )
END
GO
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Blog')
BEGIN
    CREATE TABLE Blog (
        Id INT PRIMARY KEY IDENTITY(1,1),
        BlogTypeId INT NOT NULL,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
        ModifyDate DATETIME NULL,
        CreatedBy NVARCHAR(100) NOT NULL,
        ModifyBy NVARCHAR(100) NULL,
        IsPublished BIT NOT NULL DEFAULT 0, 
        CONSTRAINT FK_Blog_BlogType FOREIGN KEY (BlogTypeId) REFERENCES BlogType(Id)
    )
END
GO
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'BlogTemplates')
BEGIN
    CREATE TABLE BlogTemplates (
        Id INT PRIMARY KEY IDENTITY(1,1),
        BlogTitle NVARCHAR(200) NOT NULL,
        BlogDescription NVARCHAR(MAX) NOT NULL,
        BlogContent NVARCHAR(MAX) NULL, 
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
        ModifyDate DATETIME NULL,
        CreatedBy NVARCHAR(100) NOT NULL,
        ModifyBy NVARCHAR(100) NULL
    )
END
GO