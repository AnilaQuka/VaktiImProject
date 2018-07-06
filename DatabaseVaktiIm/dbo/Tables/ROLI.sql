CREATE TABLE [dbo].[ROLI] (
    [rol_id] INT          IDENTITY (1, 1) NOT NULL,
    [emri]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([rol_id] ASC),
    UNIQUE NONCLUSTERED ([emri] ASC)
);

