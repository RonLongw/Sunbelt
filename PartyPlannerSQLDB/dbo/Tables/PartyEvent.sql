CREATE TABLE [dbo].[PartyEvent] (
    [EventId]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [EventName]   NVARCHAR (255) NOT NULL,
    [EventDate]   DATETIME       NULL,
    [DateCreated] DATETIME       CONSTRAINT [DF_Event_DateCreated] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventId] ASC)
);

