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
  [product_type] int
)
GO

CREATE TABLE [Product_Type] (
  [id] int PRIMARY KEY,
  [name] nvarchar(255)
)
GO

INSERT INTO Product_Type (id, name) VALUES (1, 'Placa de vídeo');
INSERT INTO Product_Type (id, name) VALUES (2, 'Placa Mãe');
INSERT INTO Product_Type (id, name) VALUES (3, 'Memória RAM');
INSERT INTO Product_Type (id, name) VALUES (4, 'Processador AMD');
INSERT INTO Product_Type (id, name) VALUES (5, 'Processador Intel');
GO

ALTER TABLE [ProductPriceHistory] ADD FOREIGN KEY ([product_id]) REFERENCES [Products] ([id])
GO

ALTER TABLE [Products] ADD FOREIGN KEY ([product_type]) REFERENCES [Product_Type] ([id])
GO
