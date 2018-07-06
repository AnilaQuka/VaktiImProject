CREATE TABLE [dbo].[ADRESA] (
    [adrese_id]  INT           IDENTITY (1, 1) NOT NULL,
    [rruga]      VARCHAR (100) NOT NULL,
    [pershkrimi] VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([adrese_id] ASC)
);

