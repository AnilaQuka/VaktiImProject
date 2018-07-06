CREATE TABLE [dbo].[POROSI] (
    [porosi_id]        INT      IDENTITY (1, 1) NOT NULL,
    [adresa_id]        INT      NOT NULL,
    [datetime_Porosi]  DATETIME NOT NULL,
    [status_porosie]   BIT      NOT NULL DEFAULT 1,
    [klient_id]        INT      NOT NULL,
    [pergjegjes_id]    INT      NOT NULL DEFAULT 2,
    [data_Modifikimit] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([porosi_id] ASC),
    CONSTRAINT [POROSI_fk0] FOREIGN KEY ([adresa_id]) REFERENCES [dbo].[ADRESA] ([adrese_id]),
    CONSTRAINT [POROSI_fk1] FOREIGN KEY ([klient_id]) REFERENCES [dbo].[PERDORUES] ([perdorues_id]),
    CONSTRAINT [POROSI_fk2] FOREIGN KEY ([pergjegjes_id]) REFERENCES [dbo].[PERDORUES] ([perdorues_id])
);

