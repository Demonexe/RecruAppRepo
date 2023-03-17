create sequence [dbo].Components_Seq start with 1 increment by 1;
CREATE TABLE [dbo].[Components] (
    [Component_ID] INT           NOT NULL,
    [Name]         VARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([Component_ID] ASC)
);

create sequence [dbo].Delivery_Seq start with 1 increment by 1;
CREATE TABLE [dbo].[Delivery] (
    [Delivery_ID]  INT      NOT NULL,
    [Supplier_ID]  INT      NOT NULL,
    [Component_ID] INT      NOT NULL,
    [Date]         DATETIME NOT NULL,
    [Quantity]     INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Delivery_ID] ASC),
    FOREIGN KEY ([Component_ID]) REFERENCES [dbo].[Components] ([Component_ID]),
    FOREIGN KEY ([Supplier_ID]) REFERENCES [dbo].[Suppliers] ([Supplier_ID])
);

create sequence [dbo].Release_Seq start with 1 increment by 1;
CREATE TABLE [dbo].[Release] (
    [Release_ID]   INT      NOT NULL,
    [Component_ID] INT      NOT NULL,
    [Date]         DATETIME NOT NULL,
    [Quantity]     INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Release_ID] ASC),
    FOREIGN KEY ([Component_ID]) REFERENCES [dbo].[Components] ([Component_ID])
);

create sequence [dbo].Suppliers_Seq start with 1 increment by 1;
CREATE TABLE [dbo].[Suppliers] (
    [Supplier_ID]  INT           NOT NULL,
    [Name]         VARCHAR (200) NOT NULL,
    [E-mail]       VARCHAR (200) NOT NULL,
    [Phone_number] VARCHAR (12)  NOT NULL,
    [Address]      VARCHAR (200) NOT NULL,
    [City]         VARCHAR (200) NOT NULL,
    [Postal_code]  VARCHAR (6)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Supplier_ID] ASC)
);
