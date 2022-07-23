CREATE TABLE [ProductPriceHistory] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [product_id] nvarchar(255),
  [price] decimal,
  [datetime] datetime
)
GO

CREATE TABLE [Products] (
  [id] int PRIMARY KEY,
  [product_barcode] nvarchar(255),
  [name] nvarchar(255),
)
GO

ALTER TABLE [ProductPriceHistory] ADD FOREIGN KEY ([product_id]) REFERENCES [Products] ([id])
GO
