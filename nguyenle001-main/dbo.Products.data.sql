SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (1, N'Coca', N'Coca', N'Cate001             ', CAST(10000.00 AS Decimal(18, 2)), N'~/Content/image/coca.jpg')
INSERT INTO [dbo].[Products] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (2, N'7Up', N'7UP', N'Cate001             ', CAST(10000.00 AS Decimal(18, 2)), N'~/Content/image/7up.jpg')
INSERT INTO [dbo].[Products] ([ProductID], [NamePro], [DecriptionPro], [Category], [Price], [ImagePro]) VALUES (3, N'Sprite', N'Sprite', N'Cate001             ', CAST(10000.00 AS Decimal(18, 2)), N'~/Content/image/sprite.jpg')
SET IDENTITY_INSERT [dbo].[Products] OFF
