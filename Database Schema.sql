CREATE DATABASE HardwarePriceHistory;
GO

use HardwarePriceHistory;
GO

CREATE TABLE [ProductPriceHistory] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [product_id] int,
  [price] float,
  [datetime] datetime
)
GO

CREATE TABLE [Products] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [product_barcode] nvarchar(255),
  [name] nvarchar(255),
)
GO

ALTER TABLE [ProductPriceHistory] ADD FOREIGN KEY ([product_id]) REFERENCES [Products] ([id])
GO
