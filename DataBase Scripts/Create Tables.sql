CREATE TABLE [Categories] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Products] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [CategoryId] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) --ON DELETE CASCADE
);
GO


CREATE TABLE [PriceLists] (
    [Id] int NOT NULL IDENTITY,
    [ProductId] int NOT NULL,
    [Price] int NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_PriceLists] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PriceLists_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) --ON DELETE CASCADE
);
GO


CREATE INDEX [IX_PriceLists_ProductId] ON [PriceLists] ([ProductId]);
GO


CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

DECLARE @CategoryIdUno AS INTEGER, @CategoryIdDos AS INTEGER

SET DATEFORMAT ymd
INSERT INTO Categories(Name) VALUES(N'PRODUNO')
SET @CategoryIdUno = @@identity

INSERT INTO Categories(Name) VALUES(N'PRODDOS')
SET @CategoryIdDos = @@identity
 


SET DATEFORMAT ymd
INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoA', @CategoryIdUno)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 10, '2019-10-25 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoB', @CategoryIdDos)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 60, '2019-10-21 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoC', @CategoryIdUno)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 5, '2019-10-22 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoD', @CategoryIdDos)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 5, '2019-10-29 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoE', @CategoryIdUno)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 15, '2019-09-11 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoA2', @CategoryIdUno)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 50, '2019-10-25 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoB2', @CategoryIdDos)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 44, '2019-10-21 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoC2', @CategoryIdUno)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 40, '2019-10-22 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoD2', @CategoryIdDos)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 5, '2019-10-29 00:00:00.0000000')

INSERT INTO Products(Name, CategoryId) VALUES(N'ProductoE2', @CategoryIdUno)
INSERT INTO PriceLists(ProductId, Price, Date) VALUES(@@identity, 15, '2019-09-11 00:00:00.0000000')
