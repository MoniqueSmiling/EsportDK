-- Dropping the tables remove if creating DB from scratch
DROP TABLE Sponsorer;
DROP TABLE Turneringer;
DROP TABLE Ansatte;
DROP TABLE Spillere;

-- Create Spillere table
CREATE TABLE [dbo].[Spillere] (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
    [Fornavn]        NVARCHAR (50) NOT NULL,
    [Efternavn]      NVARCHAR (50) NOT NULL,
    [SummonerName]   NVARCHAR (70) NOT NULL,
    [Rang]           NVARCHAR (10) NOT NULL,
    [Telefon]        NVARCHAR (8) NOT NULL,
    [TurneringsType] NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_Spillere] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UC_Spillere] UNIQUE ([ID],[SummonerName],[Telefon])
);

-- Populate Spillere table 
INSERT INTO Spillere
			(Fornavn, Efternavn, SummonerName, Rang, Telefon, TurneringsType)
VALUES		( 'Lola', 'Jahn', 'YooshixLucy', 'Iron', '42724846', '3v3');


-- Create Ansatte Table
CREATE TABLE [dbo].[Ansatte] (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
    [Fornavn]        NVARCHAR (50) NOT NULL,
    [Efternavn]      NVARCHAR (50) NOT NULL,
    [Telefon]        NVARCHAR (20) NOT NULL,
    [Løn]            DECIMAL       NOT NULL,
    [Jobtype]        NVARCHAR (50) NOT NULL,
    [DommerLevel]    CHAR,
    CONSTRAINT [PK_Ansatte] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UC_Ansatte] UNIQUE ([ID],[Telefon]),
    CONSTRAINT Chk_DommerLevel CHECK (DommerLevel >= 1 AND DommerLevel <= 5)
);

-- Populate Ansatte with
INSERT INTO Ansatte 
            (Fornavn, Efternavn, Telefon, Løn, Jobtype, DommerLevel)
VALUES      ('Dieter', 'Knockaert', '42724846', 2400 , 'Dommer','3');

--  Create Turneringer table
CREATE TABLE [dbo].[Turneringer] (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
    [Turneringsnavn] NVARCHAR (50) NOT NULL,
    [SpillerID]      INT       NOT NULL, 
    [DommerID]       INT       NOT NULL,
    CONSTRAINT [PK_Turneriner] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Spillere_Turnering] FOREIGN KEY ([SpillerID])
    REFERENCES Spillere(ID),
    CONSTRAINT [FK_Ansatte] FOREIGN KEY ([DommerID])
    REFERENCES Ansatte(ID)
);

-- Populate Turneringer
INSERT INTO Turneringer 
            (Turneringsnavn, SpillerID, DommerID)
VALUES      ('ULTIMATE SHOWDOWN', 1, 1);

-- Create Sponsorer table
CREATE TABLE [dbo].Sponsorer (
    [ID]             INT        IDENTITY (1, 1) NOT NULL,
    [Firmanavn]      NVARCHAR (80) NOT NULL,
    [Branche]        NVARCHAR (50) NOT NULL,
    [SpillerID]      INT           NOT NULL,
    [Udgift]         DECIMAL       NOT NULL,
    CONSTRAINT [PK_Sponsorer] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [UC_Sponsorer] UNIQUE ([Firmanavn]),
    CONSTRAINT [FK_Spillere_Sponsor] FOREIGN KEY (SpillerID)
    REFERENCES Spillere(ID)
);

-- populate Sponsorer 
INSERT INTO Sponsorer
            (Firmanavn, Branche, SpillerID, Udgift)
VALUES      ('Helle''s Flynder', 'Engroshandel og detailhandel', 1 , 2400);
