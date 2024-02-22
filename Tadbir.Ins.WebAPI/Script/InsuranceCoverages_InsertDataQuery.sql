USE [TadbirInsuranceDB]
GO
SET IDENTITY_INSERT [InsBaseInfo].[InsuranceCoverages] ON 
GO
INSERT [InsBaseInfo].[InsuranceCoverages] ([Id], [CoverageTitle], [IsActive], [MinAmount], [MaxAmount], [RecordDate], [CoverageConstValue], [CoverageTypeId]) VALUES (1, N'پوشش جراحی', 1, 5000, 500000000, CAST(N'2024-02-22T00:00:00.0000000' AS DateTime2), CAST(0.0052 AS Decimal(10, 4)), 100)
GO
INSERT [InsBaseInfo].[InsuranceCoverages] ([Id], [CoverageTitle], [IsActive], [MinAmount], [MaxAmount], [RecordDate], [CoverageConstValue], [CoverageTypeId]) VALUES (3, N'پوشش دندانپزشکی', 1, 4000, 400000000, CAST(N'2024-02-22T00:00:00.0000000' AS DateTime2), CAST(0.0042 AS Decimal(10, 4)), 101)
GO
INSERT [InsBaseInfo].[InsuranceCoverages] ([Id], [CoverageTitle], [IsActive], [MinAmount], [MaxAmount], [RecordDate], [CoverageConstValue], [CoverageTypeId]) VALUES (4, N'پوشش بستر ی ', 1, 2000, 200000000, CAST(N'2024-02-22T00:00:00.0000000' AS DateTime2), CAST(0.0050 AS Decimal(10, 4)), 102)
GO
SET IDENTITY_INSERT [InsBaseInfo].[InsuranceCoverages] OFF
GO
