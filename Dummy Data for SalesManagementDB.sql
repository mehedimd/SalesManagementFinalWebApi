USE [SalesManagmentFinalDB]

-- Pharmacy Route 
GO
SET IDENTITY_INSERT [dbo].[PharmacyRoute] ON 
GO
INSERT [dbo].[PharmacyRoute] ([Id], [RouteName]) VALUES (1, N'Mirpur-1')
GO
INSERT [dbo].[PharmacyRoute] ([Id], [RouteName]) VALUES (3, N'Paltan')
GO
INSERT [dbo].[PharmacyRoute] ([Id], [RouteName]) VALUES (4, N'Banani')
GO
INSERT [dbo].[PharmacyRoute] ([Id], [RouteName]) VALUES (5, N'Gulshan-02')
GO
SET IDENTITY_INSERT [dbo].[PharmacyRoute] OFF
GO

-- Pharmacy
SET IDENTITY_INSERT [dbo].[Pharmacies] ON 
GO
INSERT [dbo].[Pharmacies] ([PharmacyId], [PharmacyName], [PhoneNumber], [EmailAddress], [Address], [Country], [City], [State], [PostalCode], [RouteId]) VALUES (5, N'Care Pharmacy', N'01787878787', N'care@gmail.com', N'Mirpur-01', N'Bangladesh', N'Dhaka', N'BD', N'1234', 1)
GO
INSERT [dbo].[Pharmacies] ([PharmacyId], [PharmacyName], [PhoneNumber], [EmailAddress], [Address], [Country], [City], [State], [PostalCode], [RouteId]) VALUES (8, N'Don Pharma', N'01547589564', N'don@gmail.com', N'Puran Paltan', N'Bangladesh', N'Dhaka', N'BD', N'1200', 3)
GO
INSERT [dbo].[Pharmacies] ([PharmacyId], [PharmacyName], [PhoneNumber], [EmailAddress], [Address], [Country], [City], [State], [PostalCode], [RouteId]) VALUES (9, N'Lazz Pharma', N'01874857487', N'lazz@gmail.com', N'Mazar Road, Mirpur-01', N'Bangladesh', N'Dhaka', N'BD', N'1245', 1)
GO
INSERT [dbo].[Pharmacies] ([PharmacyId], [PharmacyName], [PhoneNumber], [EmailAddress], [Address], [Country], [City], [State], [PostalCode], [RouteId]) VALUES (11, N'Bravuna Pharma', N'01547458747', N'br@gmail.com', N'Banani Block-D', N'Bangladesh', N'Dhaka', N'BD', N'1246', 4)
GO
INSERT [dbo].[Pharmacies] ([PharmacyId], [PharmacyName], [PhoneNumber], [EmailAddress], [Address], [Country], [City], [State], [PostalCode], [RouteId]) VALUES (12, N'Jamil Pharma', N'01654582424', N'jamil@gmail.com', N'Banani Block-C', N'Bangladesh', N'Dhaka', N'BD', N'1244', 4)
GO
INSERT [dbo].[Pharmacies] ([PharmacyId], [PharmacyName], [PhoneNumber], [EmailAddress], [Address], [Country], [City], [State], [PostalCode], [RouteId]) VALUES (14, N'Aristo Pharma 02', N'01971980871', N'aristo@gmail.com', N'Gulshan-02', N'Bangladesh', N'Dhaka', N'BD', N'1200', 5)
GO
SET IDENTITY_INSERT [dbo].[Pharmacies] OFF
GO
-- Asp Net Roles
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2f964105-63d8-4e3e-bf10-ea4abaeeb06f', N'manager', N'manager', N'4d67151e-82c0-438e-a1d6-3c69eac9ca87')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'57c4a678-12e2-44a5-8d04-cf5817981f68', N'rider', N'rider', N'e91dad29-e525-4583-9bab-fb6815486e53')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'67dd35a1-65a4-43e2-8c7d-9b27f3ce33cb', N'sr', N'sr', N'89b453ee-69ff-4cae-985f-46dcdda4f82e')
GO
-- Asp Net Users
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'05cc0275-0b4e-4c34-90b6-ca48a2d7a2b8', N'Mehedi', N'Hasan', N'mehedi@gmail.com', N'MEHEDI@GMAIL.COM', N'mehedi@gmail.com', N'MEHEDI@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEMXPEsNEDWk7IDUJn0zDKfXGd2D9CY8vjLIsjNhAps3iUnfi6aDAncMhln1GtJ+Jpw==', N'AS4TXKLR2XUT7OQC2RWQAR4HSTFATX6N', N'2d224226-b79f-4a41-8e67-74e669f3d46b', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'10af0b26-f9b8-466d-9c76-abd827bd9fc3', N'Sefat', N'Ullah', N'sefat@gmail.com', N'SEFAT@GMAIL.COM', N'sefat@gmail.com', N'SEFAT@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEOBGYla5cKjMRroYfaAo+wdjcVSMNaZwUwqNNE2T6ie2zsyXeIq1ADGWrX8ajYOag==', N'J4SJBKRI7H5R4OOMDZ5UC7LZMEAWDA6B', N'aa688997-7d63-46c3-83d5-2601e57788c8', NULL, 0, 0, NULL, 1, 0)
GO
-- Set User Role
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'05cc0275-0b4e-4c34-90b6-ca48a2d7a2b8', N'2f964105-63d8-4e3e-bf10-ea4abaeeb06f')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10af0b26-f9b8-466d-9c76-abd827bd9fc3', N'67dd35a1-65a4-43e2-8c7d-9b27f3ce33cb')
GO
-- Product Category
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'OTC Medecine')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Supliment')
GO
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'Devices')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
-- Products
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId]) VALUES (1, N'Napa 500mg', N'napa', CAST(125.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId]) VALUES (2, N'Seclo 500mg', N'seclo', CAST(140.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId]) VALUES (4, N'Savelon Baby Wipes', N'Savelon Baby Wipes', CAST(251.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId]) VALUES (6, N'Fexo 120mg', N'tulshi kasi sirup', CAST(110.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId]) VALUES (7, N'Thermometer', N'Thermometer', CAST(270.00 AS Decimal(18, 2)), 3)
GO
INSERT [dbo].[Products] ([ProductId], [ProductName], [ProductDescription], [Price], [CategoryId]) VALUES (8, N'Blood Pressure Machine', N'Blood Pressure Machine', CAST(2550.00 AS Decimal(18, 2)), 3)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
-- Orders
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderId], [OrderNo], [OrderDate], [GrandTotal], [IsApproved], [IsDelivered], [PharmacyId], [EmployeeId]) VALUES (1036, 10829, CAST(N'2024-06-02T00:00:00.0000000' AS DateTime2), CAST(877.00 AS Decimal(18, 2)), 1, 0, 5, NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderNo], [OrderDate], [GrandTotal], [IsApproved], [IsDelivered], [PharmacyId], [EmployeeId]) VALUES (1037, 10508, CAST(N'2024-06-02T00:00:00.0000000' AS DateTime2), CAST(280.00 AS Decimal(18, 2)), 1, 0, 5, NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderNo], [OrderDate], [GrandTotal], [IsApproved], [IsDelivered], [PharmacyId], [EmployeeId]) VALUES (1038, 11188, CAST(N'2024-06-02T00:00:00.0000000' AS DateTime2), CAST(125.00 AS Decimal(18, 2)), 0, 0, 11, NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderNo], [OrderDate], [GrandTotal], [IsApproved], [IsDelivered], [PharmacyId], [EmployeeId]) VALUES (1039, 11004, CAST(N'2024-06-02T00:00:00.0000000' AS DateTime2), CAST(550.00 AS Decimal(18, 2)), 0, 0, 5, NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderNo], [OrderDate], [GrandTotal], [IsApproved], [IsDelivered], [PharmacyId], [EmployeeId]) VALUES (1040, 10540, CAST(N'2024-06-02T00:00:00.0000000' AS DateTime2), CAST(3135.00 AS Decimal(18, 2)), 0, 0, 8, NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderNo], [OrderDate], [GrandTotal], [IsApproved], [IsDelivered], [PharmacyId], [EmployeeId]) VALUES (1041, 11236, CAST(N'2024-06-02T00:00:00.0000000' AS DateTime2), CAST(1312.00 AS Decimal(18, 2)), 1, 0, 5, NULL)
GO
INSERT [dbo].[Orders] ([OrderId], [OrderNo], [OrderDate], [GrandTotal], [IsApproved], [IsDelivered], [PharmacyId], [EmployeeId]) VALUES (1042, 11141, CAST(N'2024-06-03T00:00:00.0000000' AS DateTime2), CAST(5090.00 AS Decimal(18, 2)), 0, 0, 5, NULL)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
-- Units
SET IDENTITY_INSERT [dbo].[Units] ON 
GO
INSERT [dbo].[Units] ([UnitId], [UnitName]) VALUES (1, N'Box')
GO
INSERT [dbo].[Units] ([UnitId], [UnitName]) VALUES (2, N'Pices')
GO
SET IDENTITY_INSERT [dbo].[Units] OFF
GO
-- Order Items
SET IDENTITY_INSERT [dbo].[OrderItems] ON 
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1101, 1, 1, 1038, 1)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1102, 6, 5, 1039, 1)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1103, 1, 5, 1040, 1)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1104, 4, 10, 1040, 2)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1107, 1, 5, 1042, 1)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1108, 2, 5, 1042, 1)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1109, 4, 15, 1042, 2)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1110, 2, 2, 1037, 1)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1111, 1, 3, 1036, 1)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1112, 4, 2, 1036, 2)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1113, 4, 2, 1041, 2)
GO
INSERT [dbo].[OrderItems] ([Id], [ProductId], [Quantity], [OrderId], [UnitId]) VALUES (1114, 7, 3, 1041, 2)
GO
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
-- Stocks
SET IDENTITY_INSERT [dbo].[Stocks] ON 
GO
INSERT [dbo].[Stocks] ([StockId], [Quantity], [ProductId]) VALUES (1, 99990, 1)
GO
INSERT [dbo].[Stocks] ([StockId], [Quantity], [ProductId]) VALUES (2, 549998, 2)
GO
INSERT [dbo].[Stocks] ([StockId], [Quantity], [ProductId]) VALUES (3, 199991, 4)
GO
INSERT [dbo].[Stocks] ([StockId], [Quantity], [ProductId]) VALUES (4, 500000, 6)
GO
INSERT [dbo].[Stocks] ([StockId], [Quantity], [ProductId]) VALUES (5, 69817, 7)
GO
INSERT [dbo].[Stocks] ([StockId], [Quantity], [ProductId]) VALUES (6, 48600, 8)
GO
SET IDENTITY_INSERT [dbo].[Stocks] OFF
GO
