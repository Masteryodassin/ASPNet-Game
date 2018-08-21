SET IDENTITY_INSERT [dbo].[Resources] ON
INSERT INTO [dbo].[Resources] ([Id], [Name], [ImagePath]) VALUES (1, N'Crystal', N'http://axl6732pmj11yssb62rgy2mh.wpengine.netdna-cdn.com/wp-content/uploads/2016/04/Blue-Crystals.jpg')
INSERT INTO [dbo].[Resources] ([Id], [Name], [ImagePath]) VALUES (2, N'Gold', N'https://previews.123rf.com/images/assistant/assistant1711/assistant171100035/89475208-golden-background-gold-natural-mineral-macro-photo-of-the-precious-stone-.jpg')
INSERT INTO [dbo].[Resources] ([Id], [Name], [ImagePath]) VALUES (3, N'Stone', NULL)
SET IDENTITY_INSERT [dbo].[Resources] OFF

SET IDENTITY_INSERT [dbo].[UnitTemplates] ON
INSERT INTO [dbo].[UnitTemplates] ([Id], [Abilities], [AttackPoint], [Speed], [ExtractionCapacity], [BuildingSpeedRatio], [StorageCapacity], [MaxHealth], [BuildingDelay], [Name], [ImagePath], [UnitTemplate_Id], [ExtractedResource_Id], [StoredResource_Id], [Active]) VALUES (1, 8, 0, 0, 1000, 0, 0, 24000, 120, N'Crystal mine', N'https://img4.wikia.nocookie.net/__cb20130802090032/fr.ogame/images/f/f0/Mine_de_cristal.jpg', NULL, 1, NULL, 1)
INSERT INTO [dbo].[UnitTemplates] ([Id], [Abilities], [AttackPoint], [Speed], [ExtractionCapacity], [BuildingSpeedRatio], [StorageCapacity], [MaxHealth], [BuildingDelay], [Name], [ImagePath], [UnitTemplate_Id], [ExtractedResource_Id], [StoredResource_Id], [Active]) VALUES (2, 3, 15, 100, 0, 0, 0, 1800, 240, N'Striker', N'https://wallpapersite.com/images/pages/pic_w/7078.jpg', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UnitTemplates] OFF

SET IDENTITY_INSERT [dbo].[ResourceAmounts] ON
INSERT INTO [dbo].[ResourceAmounts] ([Id], [Amount], [Resource_Id], [UnitTemplate_Id]) VALUES (1, 1500, 3, 1)
INSERT INTO [dbo].[ResourceAmounts] ([Id], [Amount], [Resource_Id], [UnitTemplate_Id]) VALUES (3, 800, 1, 1)
SET IDENTITY_INSERT [dbo].[ResourceAmounts] OFF

