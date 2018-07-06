CREATE TABLE [dbo].[KATEGORI] (
    [kategori_id] INT           IDENTITY (1, 1) NOT NULL,
    [emri]        VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([kategori_id] ASC)
);

