CREATE TABLE [dbo].[GATIM] (
    [gatim_id]        INT           IDENTITY (1, 1) NOT NULL,
    [emriGatimit]            VARCHAR (100) NOT NULL,
    [pershkrimi]      TEXT          NOT NULL,
    [cmimi]           MONEY         NOT NULL,
    [disponueshmeria] BIT           NOT NULL,
    [foto]            VARCHAR (100) NULL,
    [datakrijimit]    DATETIME      NOT NULL,
    [datamodifikimit] DATETIME      NULL,
    [createdBy]       INT           NOT NULL,
    [modifiedBy]      INT           NULL,
    [kategori_id]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([gatim_id] ASC),
    CONSTRAINT [GATIM_fk0] FOREIGN KEY ([createdBy]) REFERENCES [dbo].[PERDORUES] ([perdorues_id]),
    CONSTRAINT [GATIM_fk1] FOREIGN KEY ([modifiedBy]) REFERENCES [dbo].[PERDORUES] ([perdorues_id]),
    CONSTRAINT [GATIM_fk2] FOREIGN KEY ([kategori_id]) REFERENCES [dbo].[KATEGORI] ([kategori_id])
);

