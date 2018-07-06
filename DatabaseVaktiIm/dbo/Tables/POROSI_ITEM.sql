CREATE TABLE [dbo].[POROSI_ITEM] (
    [porosi_id] INT NOT NULL,
    [sasia]     INT NOT NULL DEFAULT 1 ,
    [gatim_id]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([porosi_id] ASC, [gatim_id] ASC),
    CONSTRAINT [POROSI_ITEM_fk0] FOREIGN KEY ([porosi_id]) REFERENCES [dbo].[POROSI] ([porosi_id]),
    CONSTRAINT [POROSI_ITEM_fk1] FOREIGN KEY ([gatim_id]) REFERENCES [dbo].[GATIM] ([gatim_id])
);

