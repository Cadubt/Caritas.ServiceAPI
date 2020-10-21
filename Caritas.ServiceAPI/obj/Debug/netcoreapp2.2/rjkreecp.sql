IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF SCHEMA_ID(N'shelt') IS NULL EXEC(N'CREATE SCHEMA [shelt];');

GO

IF SCHEMA_ID(N'usr') IS NULL EXEC(N'CREATE SCHEMA [usr];');

GO

CREATE TABLE [shelt].[Kinships] (
    [Id] int NOT NULL IDENTITY,
    [KinName] nvarchar(max) NULL,
    CONSTRAINT [PK_Kinships] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [shelt].[Responsibles] (
    [Id] int NOT NULL IDENTITY,
    [ResponsibleName] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [KinshipId] nvarchar(max) NULL,
    [CreatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Responsibles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [shelt].[ScheduleSheets] (
    [Id] int NOT NULL IDENTITY,
    [ShelteredName] nvarchar(max) NULL,
    [ShelteredAge] int NOT NULL,
    [ShelteredPhone] nvarchar(max) NULL,
    [ShelteredAddress] nvarchar(max) NULL,
    [ResponsibleName] nvarchar(max) NULL,
    [KinshipId] int NOT NULL,
    [ResponsiblePhone] nvarchar(max) NULL,
    [ResponsibleAddress] nvarchar(max) NULL,
    [InterviewDate] datetime2 NOT NULL,
    [ScheduleDate] datetime2 NOT NULL,
    [Observation] nvarchar(max) NULL,
    [ScheduleResponsible] nvarchar(max) NULL,
    [CreatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_ScheduleSheets] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [shelt].[Sheltereds] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Age] int NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [Phone] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [BloodTyping] nvarchar(max) NULL,
    [EntryDate] datetime2 NOT NULL,
    [PerfilImage] nvarchar(max) NULL,
    [CreatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Sheltereds] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [usr].[Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Role] int NOT NULL,
    [CreatedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201021093746_Initial', N'2.2.6-servicing-10079');

GO

