DROP TABLE Spillere;
DROP TABLE Turneringer;
DROP TABLE Ansatte;
DROP TABLE Sponsorer;

CREATE TABLE [dbo].[Spillere] (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
    [Fornavn]        NVARCHAR (50) NOT NULL,
    [Efternavn]      NVARCHAR (50) NOT NULL,
    [SummonerName]   NVARCHAR (50) NOT NULL,
    [Rang]           NVARCHAR (50) NOT NULL,
    [Telefon]        NVARCHAR (20) NOT NULL,
    [TurneringsType] NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Spillere] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UC_Spillere] UNIQUE ([ID],[SummonerName],[Telefon])
);


INSERT INTO Spillere
			(fornavn, efternavn, SummonerName, rang, telefon, turneringsType)
VALUES		( 'Lola', 'Jahn', 'YooshixLucy', 'Iron', '42724846', '3v3');


CREATE TABLE [dbo].[Turneringer] (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
    [Turneringsnavn] NVCARCHAR (50) NOT NULL,
    []

);

CREATE TABLE [dbo].TurneringsDeltager (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
);

CREATE TABLE [dbo].[Ansatte] (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
    [Fornavn]        NVARCHAR (50) NOT NULL,
    [Efternavn]      NVARCHAR (50) NOT NULL,
    [SummonerName]   NVARCHAR (50) NULL,
    [Rang]           NVARCHAR (50) NOT NULL,
    [Telefon]        NVARCHAR (20) NOT NULL,
    [TurneringsType] NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Spillere] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UC_Spillere] UNIQUE ([ID],[SummonerName],[Telefon])
);

CREATE TABLE [dbo].Dommere ();

CREATE TABLE [dbo].Sponsorer (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
);
