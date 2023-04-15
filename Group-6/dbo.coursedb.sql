CREATE TABLE [dbo].[coursedb] (
    [couseId]     INT           NOT NULL,
    [courseName]  VARCHAR (50)  NULL,
    [description] VARCHAR (MAX) NULL,
    [duration]    VARCHAR(50) NULL,
    [courseEmail] VARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([couseId] ASC)
);

