﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewDataPhoneCodeAndProvince : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF NOT EXISTS(SELECT * FROM [AMSS_N].[dbo].[Provinces] WHERE CountryCode = 'BR')
                BEGIN 
                    INSERT INTO [AMSS_N].[dbo].[Provinces] ([Id], [Code], [CountryCode], [Name], [Category]) VALUES
                    -- Brazil
                    (NEWID(), 'BR-AC', 'BR', N'Acre', 'Province'),
                    (NEWID(), 'BR-AL', 'BR', N'Alagoas', 'Province'),
                    (NEWID(), 'BR-AM', 'BR', N'Amazonas', 'Province'),
                    (NEWID(), 'BR-AP', 'BR', N'Amapá', 'Province'),
                    (NEWID(), 'BR-BA', 'BR', N'Bahia', 'Province'),
                    (NEWID(), 'BR-CE', 'BR', N'Ceará', 'Province'),
                    (NEWID(), 'BR-DF', 'BR', N'Federal District', 'FederalDistrict'),
                    (NEWID(), 'BR-ES', 'BR', N'Espírito Santo', 'Province'),
                    (NEWID(), 'BR-GO', 'BR', N'Goiás', 'Province'),
                    (NEWID(), 'BR-MA', 'BR', N'Maranhão', 'Province'),
                    (NEWID(), 'BR-MG', 'BR', N'Minas Gerais', 'Province'),
                    (NEWID(), 'BR-MS', 'BR', N'Mato Grosso do Sul', 'Province'),
                    (NEWID(), 'BR-MT', 'BR', N'Mato Grosso', 'Province'),
                    (NEWID(), 'BR-PA', 'BR', N'Pará', 'Province'),
                    (NEWID(), 'BR-PB', 'BR', N'Paraíba', 'Province'),
                    (NEWID(), 'BR-PE', 'BR', N'Pernambuco', 'Province'),
                    (NEWID(), 'BR-PI', 'BR', N'Piauí', 'Province'),
                    (NEWID(), 'BR-PR', 'BR', N'Paraná', 'Province'),
                    (NEWID(), 'BR-RJ', 'BR', N'Rio de Janeiro', 'Province'),
                    (NEWID(), 'BR-RN', 'BR', N'Rio Grande do Norte', 'Province'),
                    (NEWID(), 'BR-RO', 'BR', N'Rondônia', 'Province'),
                    (NEWID(), 'BR-RR', 'BR', N'Roraima', 'Province'),
                    (NEWID(), 'BR-RS', 'BR', N'Rio Grande do Sul', 'Province'),
                    (NEWID(), 'BR-SC', 'BR', N'Santa Catarina', 'Province'),
                    (NEWID(), 'BR-SE', 'BR', N'Sergipe', 'Province'),
                    (NEWID(), 'BR-SP', 'BR', N'São Paulo', 'Province'),
                    (NEWID(), 'BR-TO', 'BR', N'Tocantins', 'Province'), 
                    -- China 
                    (NEWID(), 'CN-AH', 'CN', N'Anhui Sheng', 'Province'),
                    (NEWID(), 'CN-BJ', 'CN', N'Beijing Shi', 'Municipality'),
                    (NEWID(), 'CN-CQ', 'CN', N'Chongqing Shi', 'Municipality'),
                    (NEWID(), 'CN-FJ', 'CN', N'Fujian Sheng', 'Province'),
                    (NEWID(), 'CN-GD', 'CN', N'Guangdong Sheng', 'Province'),
                    (NEWID(), 'CN-GS', 'CN', N'Gansu Sheng', 'Province'),
                    (NEWID(), 'CN-GX', 'CN', N'Guangxi Zhuangzu Zizhiqu', 'AutonomousRegion'),
                    (NEWID(), 'CN-GZ', 'CN', N'Guizhou Sheng', 'Province'),
                    (NEWID(), 'CN-HA', 'CN', N'Henan Sheng', 'Province'),
                    (NEWID(), 'CN-HB', 'CN', N'Hubei Sheng', 'Province'),
                    (NEWID(), 'CN-HE', 'CN', N'Hebei Sheng', 'Province'),
                    (NEWID(), 'CN-HI', 'CN', N'Hainan Sheng', 'Province'),
                    (NEWID(), 'CN-HK', 'CN', N'Hong Kong SAR', 'SpecialAdministrativeRegion'),
                    (NEWID(), 'CN-HL', 'CN', N'Heilongjiang Sheng', 'Province'),
                    (NEWID(), 'CN-HN', 'CN', N'Hunan Sheng', 'Province'),
                    (NEWID(), 'CN-JL', 'CN', N'Jilin Sheng', 'Province'),
                    (NEWID(), 'CN-JS', 'CN', N'Jiangsu Sheng', 'Province'),
                    (NEWID(), 'CN-JX', 'CN', N'Jiangxi Sheng', 'Province'),
                    (NEWID(), 'CN-LN', 'CN', N'Liaoning Sheng', 'Province'),
                    (NEWID(), 'CN-MO', 'CN', N'Macao SAR', 'SpecialAdministrativeRegion'),
                    (NEWID(), 'CN-NM', 'CN', N'Nei Mongol Zizhiqu', 'AutonomousRegion'),
                    (NEWID(), 'CN-NX', 'CN', N'Ningxia Huizu Zizhiqu', 'AutonomousRegion'),
                    (NEWID(), 'CN-QH', 'CN', N'Qinghai Sheng', 'Province'),
                    (NEWID(), 'CN-SC', 'CN', N'Sichuan Sheng', 'Province'),
                    (NEWID(), 'CN-SD', 'CN', N'Shandong Sheng', 'Province'),
                    (NEWID(), 'CN-SH', 'CN', N'Shanghai Shi', 'Municipality'),
                    (NEWID(), 'CN-SN', 'CN', N'Shaanxi Sheng', 'Province'),
                    (NEWID(), 'CN-SX', 'CN', N'Shanxi Sheng', 'Province'),
                    (NEWID(), 'CN-TJ', 'CN', N'Tianjin Shi', 'Municipality'),
                    (NEWID(), 'CN-TW', 'CN', N'Taiwan Sheng', 'Province'),
                    (NEWID(), 'CN-XJ', 'CN', N'Xinjiang Uygur Zizhiqu', 'AutonomousRegion'),
                    (NEWID(), 'CN-XZ', 'CN', N'Xizang Zizhiqu', 'AutonomousRegion'),
                    (NEWID(), 'CN-YN', 'CN', N'Yunnan Sheng', 'Province'),
                    (NEWID(), 'CN-ZJ', 'CN', N'Zhejiang Sheng', 'Province'),
                    -- Indonesia
                    (NEWID(), 'ID-AC', 'ID', N'Aceh', 'Province'),
                    (NEWID(), 'ID-BA', 'ID', N'Bali', 'Province'),
                    (NEWID(), 'ID-BB', 'ID', N'Bangka Belitung Islands', 'Province'),
                    (NEWID(), 'ID-BE', 'ID', N'Bengkulu', 'Province'),
                    (NEWID(), 'ID-BT', 'ID', N'Banten', 'Province'),
                    (NEWID(), 'ID-GO', 'ID', N'Gorontalo', 'Province'),
                    (NEWID(), 'ID-JA', 'ID', N'Jambi', 'Province'),
                    (NEWID(), 'ID-JB', 'ID', N'West Java', 'Province'),
                    (NEWID(), 'ID-JI', 'ID', N'East Java', 'Province'),
                    (NEWID(), 'ID-JK', 'ID', N'Jakarta', 'SpecialCapitalRegion'),
                    (NEWID(), 'ID-JT', 'ID', N'Central Java', 'Province'),
                    (NEWID(), 'ID-KB', 'ID', N'West Kalimantan', 'Province'),
                    (NEWID(), 'ID-KI', 'ID', N'East Kalimantan', 'Province'),
                    (NEWID(), 'ID-KR', 'ID', N'Riau Islands', 'Province'),
                    (NEWID(), 'ID-KS', 'ID', N'South Kalimantan', 'Province'),
                    (NEWID(), 'ID-KT', 'ID', N'Central Kalimantan', 'Province'),
                    (NEWID(), 'ID-KU', 'ID', N'North Kalimantan', 'Province'),
                    (NEWID(), 'ID-LA', 'ID', N'Lampung', 'Province'),
                    (NEWID(), 'ID-MA', 'ID', N'Maluku', 'Province'),
                    (NEWID(), 'ID-MU', 'ID', N'North Maluku', 'Province'),
                    (NEWID(), 'ID-NB', 'ID', N'West Nusa Tenggara', 'Province'),
                    (NEWID(), 'ID-NT', 'ID', N'East Nusa Tenggara', 'Province'),
                    (NEWID(), 'ID-PA', 'ID', N'Papua', 'Province'),
                    (NEWID(), 'ID-PB', 'ID', N'West Papua', 'Province'),
                    (NEWID(), 'ID-PD', 'ID', N'Southwest Papua', 'Province'),
                    (NEWID(), 'ID-PE', 'ID', N'Highland Papua', 'Province'),
                    (NEWID(), 'ID-PS', 'ID', N'South Papua', 'Province'),
                    (NEWID(), 'ID-PT', 'ID', N'Central Papua', 'Province'),
                    (NEWID(), 'ID-RI', 'ID', N'Riau', 'Province'),
                    (NEWID(), 'ID-SA', 'ID', N'North Sulawesi', 'Province'),
                    (NEWID(), 'ID-SB', 'ID', N'West Sumatra', 'Province'),
                    (NEWID(), 'ID-SG', 'ID', N'Southeast Sulawesi', 'Province'),
                    (NEWID(), 'ID-SN', 'ID', N'South Sulawesi', 'Province'),
                    (NEWID(), 'ID-SR', 'ID', N'West Sulawesi', 'Province'),
                    (NEWID(), 'ID-SS', 'ID', N'South Sumatra', 'Province'),
                    (NEWID(), 'ID-ST', 'ID', N'Central Sulawesi', 'Province'),
                    (NEWID(), 'ID-SU', 'ID', N'North Sumatra', 'Province'),
                    (NEWID(), 'ID-YO', 'ID', N'Yogyakarta', 'SpecialRegion'),
                    -- Mexico 
                    (NEWID(), 'MX-AGU', 'MX', N'Aguascalientes', 'Province'),
                    (NEWID(), 'MX-BCN', 'MX', N'Baja California', 'Province'),
                    (NEWID(), 'MX-BCS', 'MX', N'Baja California Sur', 'Province'),
                    (NEWID(), 'MX-CAM', 'MX', N'Campeche', 'Province'),
                    (NEWID(), 'MX-CHH', 'MX', N'Durango', 'Province'),
                    (NEWID(), 'MX-CHP', 'MX', N'Colima', 'Province'),
                    (NEWID(), 'MX-CMX', 'MX', N'Chiapas', 'Province'),
                    (NEWID(), 'MX-COA', 'MX', N'Chihuahua', 'FederalEntity'),
                    (NEWID(), 'MX-COL', 'MX', N'Coahuila', 'Province'),
                    (NEWID(), 'MX-DUR', 'MX', N'Guanajuato', 'Province'),
                    (NEWID(), 'MX-GRO', 'MX', N'Hidalgo', 'Province'),
                    (NEWID(), 'MX-GUA', 'MX', N'Guerrero', 'Province'),
                    (NEWID(), 'MX-HID', 'MX', N'Jalisco', 'Province'),
                    (NEWID(), 'MX-JAL', 'MX', N'Mexico City', 'Province'),
                    (NEWID(), 'MX-MEX', 'MX', N'Mexico State', 'Province'),
                    (NEWID(), 'MX-MIC', 'MX', N'Michoacán', 'Province'),
                    (NEWID(), 'MX-MOR', 'MX', N'Morelos', 'Province'),
                    (NEWID(), 'MX-NAY', 'MX', N'Nayarit', 'Province'),
                    (NEWID(), 'MX-NLE', 'MX', N'Nuevo León', 'Province'),
                    (NEWID(), 'MX-OAX', 'MX', N'Oaxaca', 'Province'),
                    (NEWID(), 'MX-PUE', 'MX', N'Puebla', 'Province'),
                    (NEWID(), 'MX-QUE', 'MX', N'Querétaro', 'Province'),
                    (NEWID(), 'MX-ROO', 'MX', N'Quintana Roo', 'Province'),
                    (NEWID(), 'MX-SIN', 'MX', N'Sinaloa', 'Province'),
                    (NEWID(), 'MX-SLP', 'MX', N'San Luis Potosí', 'Province'),
                    (NEWID(), 'MX-SON', 'MX', N'Sonora', 'Province'),
                    (NEWID(), 'MX-TAB', 'MX', N'Tabasco', 'Province'),
                    (NEWID(), 'MX-TAM', 'MX', N'Tamaulipas', 'Province'),
                    (NEWID(), 'MX-TLA', 'MX', N'Tlaxcala', 'Province'),
                    (NEWID(), 'MX-VER', 'MX', N'Veracruz', 'Province'),
                    (NEWID(), 'MX-YUC', 'MX', N'Yucatán', 'Province'),
                    (NEWID(), 'MX-ZAC', 'MX', N'Zacatecas', 'Province'),
                    -- Malaysia 
                    (NEWID(), 'MY-01', 'MY', N'Johor', 'State'),
                    (NEWID(), 'MY-02', 'MY', N'Kedah', 'State'),
                    (NEWID(), 'MY-03', 'MY', N'Kelantan', 'State'),
                    (NEWID(), 'MY-04', 'MY', N'Melaka', 'State'),
                    (NEWID(), 'MY-05', 'MY', N'Negeri Sembilan', 'State'),
                    (NEWID(), 'MY-06', 'MY', N'Pahang', 'State'),
                    (NEWID(), 'MY-07', 'MY', N'Pulau Pinang', 'State'),
                    (NEWID(), 'MY-08', 'MY', N'Perak', 'State'),
                    (NEWID(), 'MY-09', 'MY', N'Perlis', 'State'),
                    (NEWID(), 'MY-10', 'MY', N'Selangor', 'State'),
                    (NEWID(), 'MY-11', 'MY', N'Terengganu', 'State'),
                    (NEWID(), 'MY-12', 'MY', N'Sabah', 'State'),
                    (NEWID(), 'MY-13', 'MY', N'Sarawak', 'State'),
                    (NEWID(), 'MY-14', 'MY', N'Wilayah Persekutuan Kuala Lumpur', 'FederalTerritory'),
                    (NEWID(), 'MY-15', 'MY', N'Wilayah Persekutuan Labuan', 'FederalTerritory'),
                    (NEWID(), 'MY-16', 'MY', N'Wilayah Persekutuan Putrajaya', 'FederalTerritory'), 
                    -- Thailand
                    (NEWID(), 'TH-10', 'TH', N'Krung Thep Maha Nakhon (local variant: Bangkok)', 'SpecialAdministrativeArea'),
                    (NEWID(), 'TH-11', 'TH', N'Samut Prakan', 'Province'),
                    (NEWID(), 'TH-12', 'TH', N'Nonthaburi', 'Province'),
                    (NEWID(), 'TH-13', 'TH', N'Pathum Thani', 'Province'),
                    (NEWID(), 'TH-14', 'TH', N'Phra Nakhon Si Ayuthaya', 'Province'),
                    (NEWID(), 'TH-15', 'TH', N'Ang Thong', 'Province'),
                    (NEWID(), 'TH-16', 'TH', N'Lop Buri', 'Province'),
                    (NEWID(), 'TH-17', 'TH', N'Sing Buri', 'Province'),
                    (NEWID(), 'TH-18', 'TH', N'Chai Nat', 'Province'),
                    (NEWID(), 'TH-19', 'TH', N'Saraburi', 'Province'),
                    (NEWID(), 'TH-20', 'TH', N'Chon Buri', 'Province'),
                    (NEWID(), 'TH-21', 'TH', N'Rayong', 'Province'),
                    (NEWID(), 'TH-22', 'TH', N'Chanthaburi', 'Province'),
                    (NEWID(), 'TH-23', 'TH', N'Trat', 'Province'),
                    (NEWID(), 'TH-24', 'TH', N'Chachoengsao', 'Province'),
                    (NEWID(), 'TH-25', 'TH', N'Prachin Buri', 'Province'),
                    (NEWID(), 'TH-26', 'TH', N'Nakhon Nayok', 'Province'),
                    (NEWID(), 'TH-27', 'TH', N'Sa Kaeo', 'Province'),
                    (NEWID(), 'TH-30', 'TH', N'Nakhon Ratchasima', 'Province'),
                    (NEWID(), 'TH-31', 'TH', N'Buri Ram', 'Province'),
                    (NEWID(), 'TH-32', 'TH', N'Surin', 'Province'),
                    (NEWID(), 'TH-33', 'TH', N'Si Sa Ket', 'Province'),
                    (NEWID(), 'TH-34', 'TH', N'Ubon Ratchathani', 'Province'),
                    (NEWID(), 'TH-35', 'TH', N'Yasothon', 'Province'),
                    (NEWID(), 'TH-36', 'TH', N'Chaiyaphum', 'Province'),
                    (NEWID(), 'TH-37', 'TH', N'Amnat Charoen', 'Province'),
                    (NEWID(), 'TH-38', 'TH', N'Bueng Kan', 'Province'),
                    (NEWID(), 'TH-39', 'TH', N'Nong Bua Lam Phu', 'Province'),
                    (NEWID(), 'TH-40', 'TH', N'Khon Kaen', 'Province'),
                    (NEWID(), 'TH-41', 'TH', N'Udon Thani', 'Province'),
                    (NEWID(), 'TH-42', 'TH', N'Loei', 'Province'),
                    (NEWID(), 'TH-43', 'TH', N'Nong Khai', 'Province'),
                    (NEWID(), 'TH-44', 'TH', N'Maha Sarakham', 'Province'),
                    (NEWID(), 'TH-45', 'TH', N'Roi Et', 'Province'),
                    (NEWID(), 'TH-46', 'TH', N'Kalasin', 'Province'),
                    (NEWID(), 'TH-47', 'TH', N'Sakon Nakhon', 'Province'),
                    (NEWID(), 'TH-48', 'TH', N'Nakhon Phanom', 'Province'),
                    (NEWID(), 'TH-49', 'TH', N'Mukdahan', 'Province'),
                    (NEWID(), 'TH-50', 'TH', N'Chiang Mai', 'Province'),
                    (NEWID(), 'TH-51', 'TH', N'Lamphun', 'Province'),
                    (NEWID(), 'TH-52', 'TH', N'Lampang', 'Province'),
                    (NEWID(), 'TH-53', 'TH', N'Uttaradit', 'Province'),
                    (NEWID(), 'TH-54', 'TH', N'Phrae', 'Province'),
                    (NEWID(), 'TH-55', 'TH', N'Nan', 'Province'),
                    (NEWID(), 'TH-56', 'TH', N'Phayao', 'Province'),
                    (NEWID(), 'TH-57', 'TH', N'Chiang Rai', 'Province'),
                    (NEWID(), 'TH-58', 'TH', N'Mae Hong Son', 'Province'),
                    (NEWID(), 'TH-60', 'TH', N'Nakhon Sawan', 'Province'),
                    (NEWID(), 'TH-61', 'TH', N'Uthai Thani', 'Province'),
                    (NEWID(), 'TH-62', 'TH', N'Kamphaeng Phet', 'Province'),
                    (NEWID(), 'TH-63', 'TH', N'Tak', 'Province'),
                    (NEWID(), 'TH-64', 'TH', N'Sukhothai', 'Province'),
                    (NEWID(), 'TH-65', 'TH', N'Phitsanulok', 'Province'),
                    (NEWID(), 'TH-66', 'TH', N'Phichit', 'Province'),
                    (NEWID(), 'TH-67', 'TH', N'Phetchabun', 'Province'),
                    (NEWID(), 'TH-70', 'TH', N'Ratchaburi', 'Province'),
                    (NEWID(), 'TH-71', 'TH', N'Kanchanaburi', 'Province'),
                    (NEWID(), 'TH-72', 'TH', N'Suphan Buri', 'Province'),
                    (NEWID(), 'TH-73', 'TH', N'Nakhon Pathom', 'Province'),
                    (NEWID(), 'TH-74', 'TH', N'Samut Sakhon', 'Province'),
                    (NEWID(), 'TH-75', 'TH', N'Samut Songkhram', 'Province'),
                    (NEWID(), 'TH-76', 'TH', N'Phetchaburi', 'Province'),
                    (NEWID(), 'TH-77', 'TH', N'Prachuap Khiri Khan', 'Province'),
                    (NEWID(), 'TH-80', 'TH', N'Nakhon Si Thammarat', 'Province'),
                    (NEWID(), 'TH-81', 'TH', N'Krabi', 'Province'),
                    (NEWID(), 'TH-82', 'TH', N'Phangnga', 'Province'),
                    (NEWID(), 'TH-83', 'TH', N'Phuket', 'Province'),
                    (NEWID(), 'TH-84', 'TH', N'Surat Thani', 'Province'),
                    (NEWID(), 'TH-85', 'TH', N'Ranong', 'Province'),
                    (NEWID(), 'TH-86', 'TH', N'Chumphon', 'Province'),
                    (NEWID(), 'TH-90', 'TH', N'Songkhla', 'Province'),
                    (NEWID(), 'TH-91', 'TH', N'Satun', 'Province'),
                    (NEWID(), 'TH-92', 'TH', N'Trang', 'Province'),
                    (NEWID(), 'TH-93', 'TH', N'Phatthalung', 'Province'),
                    (NEWID(), 'TH-94', 'TH', N'Pattani', 'Province'),
                    (NEWID(), 'TH-95', 'TH', N'Yala', 'Province'),
                    (NEWID(), 'TH-96', 'TH', N'Narathiwat', 'Province'),
                    (NEWID(), 'TH-S', 'TH', N'Phatthaya', 'SpecialGovernedCity');

                    -- Temp Table
                    DECLARE @PhoneCodes TABLE (
                        CountryCode NVARCHAR(2),
                        PhoneCode NVARCHAR(20)
                    );

                    INSERT INTO @PhoneCodes (CountryCode, PhoneCode)
                    VALUES 
                        ('AD', N'+376'), ('AE', N'+971'), ('AF', N'+93'), ('AG', N'+1268'),
                        ('AI', N'+1264'), ('AL', N'+355'), ('AM', N'+374'), ('AO', N'+244'),
                        ('AQ', N'+672'), ('AR', N'+54'), ('AS', N'+1684'), ('AT', N'+43'),
                        ('AU', N'+61'), ('AW', N'+297'), ('AX', N'+358'), ('AZ', N'+994'),
                        ('BA', N'+387'), ('BB', N'+1246'), ('BD', N'+880'), ('BE', N'+32'),
                        ('BF', N'+226'), ('BG', N'+359'), ('BH', N'+973'), ('BI', N'+257'),
                        ('BJ', N'+229'), ('BL', N'+590'), ('BM', N'+1441'), ('BN', N'+673'),
                        ('BO', N'+591'), ('BQ', N'+599'), ('BR', N'+55'), ('BS', N'+1242'),
                        ('BT', N'+975'), ('BV', N'+47'), ('BW', N'+267'), ('BY', N'+375'),
                        ('BZ', N'+501'), ('CA', N'+1'), ('CC', N'+61'), ('CD', N'+243'),
                        ('CF', N'+236'), ('CG', N'+242'), ('CH', N'+41'), ('CI', N'+225'),
                        ('CK', N'+682'), ('CL', N'+56'), ('CM', N'+237'), ('CN', N'+86'),
                        ('CO', N'+57'), ('CR', N'+506'), ('CU', N'+53'), ('CV', N'+238'),
                        ('CW', N'+599'), ('CX', N'+61'), ('CY', N'+357'), ('CZ', N'+420'),
                        ('DE', N'+49'), ('DJ', N'+253'), ('DK', N'+45'), ('DM', N'+1767'),
                        ('DO', N'+1809,+1829,+1849'), ('DZ', N'+213'), ('EC', N'+593'), ('EE', N'+372'),
                        ('EG', N'+20'), ('EH', N'+212'), ('ER', N'+291'), ('ES', N'+34'),
                        ('ET', N'+251'), ('FI', N'+358'), ('FJ', N'+679'), ('FK', N'+500'),
                        ('FM', N'+691'), ('FO', N'+298'), ('FR', N'+33'), ('GA', N'+241'),
                        ('GB', N'+44'), ('GD', N'+1473'), ('GE', N'+995'), ('GF', N'+594'),
                        ('GG', N'+44-1481'), ('GH', N'+233'), ('GI', N'+350'), ('GL', N'+299'),
                        ('GM', N'+220'), ('GN', N'+224'), ('GP', N'+590'), ('GQ', N'+240'),
                        ('GR', N'+30'), ('GS', N'+500'), ('GT', N'+502'), ('GU', N'+1671'),
                        ('GW', N'+245'), ('GY', N'+592'), ('HK', N'+852'), ('HM', N'+672'),
                        ('HN', N'+504'), ('HR', N'+385'), ('HT', N'+509'), ('HU', N'+36'),
                        ('ID', N'+62'), ('IE', N'+353'), ('IL', N'+972'), ('IM', N'+44-1624'),
                        ('IN', N'+91'), ('IO', N'+246'), ('IQ', N'+964'), ('IR', N'+98'),
                        ('IS', N'+354'), ('IT', N'+39'), ('JE', N'+44'), ('JM', N'+1876'),
                        ('JO', N'+962'), ('JP', N'+81'), ('KE', N'+254'), ('KG', N'+996'),
                        ('KH', N'+855'), ('KI', N'+686'), ('KM', N'+269'), ('KN', N'+1869'),
                        ('KP', N'+850'), ('KR', N'+82'), ('KW', N'+965'), ('KY', N'+1345'),
                        ('KZ', N'+7'), ('LA', N'+856'), ('LB', N'+961'), ('LC', N'+1758'),
                        ('LI', N'+423'), ('LK', N'+94'), ('LR', N'+231'), ('LS', N'+266'),
                        ('LT', N'+370'), ('LU', N'+352'), ('LV', N'+371'), ('LY', N'+218'),
                        ('MA', N'+212'), ('MC', N'+377'), ('MD', N'+373'), ('ME', N'+382'),
                        ('MF', N'+590'), ('MG', N'+261'), ('MH', N'+692'), ('MK', N'+389'),
                        ('ML', N'+223'), ('MM', N'+95'), ('MN', N'+976'), ('MO', N'+853'),
                        ('MP', N'+1670'), ('MQ', N'+596'), ('MR', N'+222'), ('MS', N'+1664'),
                        ('MT', N'+356'), ('MU', N'+230'), ('MV', N'+960'), ('MW', N'+265'),
                        ('MX', N'+52'), ('MY', N'+60'), ('MZ', N'+258'), ('NA', N'+264'),
                        ('NC', N'+687'), ('NE', N'+227'), ('NF', N'+672'), ('NG', N'+234'),
                        ('NI', N'+505'), ('NL', N'+31'), ('NO', N'+47'), ('NP', N'+977'),
                        ('NR', N'+674'), ('NU', N'+683'), ('NZ', N'+64'), ('OM', N'+968'),
                        ('PA', N'+507'), ('PE', N'+51'), ('PF', N'+689'), ('PG', N'+675'),
                        ('PH', N'+63'), ('PK', N'+92'), ('PL', N'+48'), ('PM', N'+508'),
                        ('PN', N'+64'), ('PR', N'+1-787'), ('PS', N'+970'), ('PT', N'+351'),
                        ('PW', N'+680'), ('PY', N'+595'), ('QA', N'+974'), ('RE', N'+262'),
                        ('RO', N'+40'), ('RS', N'+381'), ('RU', N'+7'), ('RW', N'+250'),
                        ('SA', N'+966'), ('SB', N'+677'), ('SC', N'+248'), ('SD', N'+249'),
                        ('SE', N'+46'), ('SG', N'+65'), ('SH', N'+290'), ('SI', N'+386'),
                        ('SJ', N'+47'), ('SK', N'+421'), ('SL', N'+232'), ('SM', N'+378'),
                        ('SN', N'+221'), ('SO', N'+252'), ('SR', N'+597'), ('SS', N'+211'),
                        ('ST', N'+239'), ('SV', N'+503'), ('SX', N'+1721'), ('SY', N'+963'),
                        ('SZ', N'+268'), ('TC', N'+1649'), ('TD', N'+235'), ('TF', N'+262'),
                        ('TG', N'+228'), ('TH', N'+66'), ('TJ', N'+992'), ('TK', N'+690'),
                        ('TL', N'+670'), ('TM', N'+993'), ('TN', N'+216'), ('TO', N'+676'),
                        ('TR', N'+90'), ('TT', N'+1868'), ('TV', N'+688'), ('TW', N'+886'),
                        ('TZ', N'+255'), ('UA', N'+380'), ('UG', N'+256'), ('UM', N'+1'),
                        ('US', N'+1'), ('UY', N'+598'), ('UZ', N'+998'), ('VA', N'+379'),
                        ('VC', N'+1784'), ('VE', N'+58'), ('VG', N'+1284'), ('VI', N'+1340'),
                        ('VN', N'+84'), ('VU', N'+678'), ('WF', N'+681'), ('WS', N'+685'),
                        ('YE', N'+967'), ('YT', N'+262'), ('ZA', N'+27'), ('ZM', N'+260'),
                        ('ZW', N'+263');
                    
                    -- UPDATE PHONE CODE
                    UPDATE cc
                    SET cc.PhoneCode = pc.PhoneCode
                    FROM [AMSS_N].[dbo].[CountryContinents] cc
                    JOIN @PhoneCodes pc ON cc.CountryCode = pc.CountryCode;
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
