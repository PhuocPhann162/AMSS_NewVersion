﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMSS.Migrations
{
    /// <inheritdoc />
    public partial class SeedCountryAndProvinceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // CountryContinent
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM [AMSS_N].[dbo].[CountryContinents] WHERE CountryCode = 'VN') 
                BEGIN
                    INSERT INTO [AMSS_N].[dbo].[CountryContinents] 
                      (Id, Co2Rate, ContinentCode, ContinentName, CountryCode, CountryName, PhoneCode, CreatedAt, UpdatedAt)
                    VALUES
                      (NEWID(), 0.00, 'EU', 'Europe', 'AD', 'Andorra', N'+376', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'AE', 'United Arab Emirates', N'+971', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'AF', 'Afghanistan', N'+93', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'AG', 'Antigua and Barbuda', N'+1268', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'AI', 'Anguilla', N'+1264', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'AL', 'Albania', N'+355', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'AM', 'Armenia', N'+374', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'AO', 'Angola', N'+244', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AN', 'Antarctica', 'AQ', 'Antarctica', N'+672', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'AR', 'Argentina', N'+54', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'AS', 'American Samoa', N'+1684', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'AT', 'Austria', N'+43', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'AU', 'Australia', N'+61', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'AW', 'Aruba', N'+297', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'AX', 'Åland Islands', N'+358', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'AZ', 'Azerbaijan', N'+994', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'BA', 'Bosnia and Herzegovina', N'+387', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'BB', 'Barbados', N'+1246', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'BD', 'Bangladesh', N'+880', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'BE', 'Belgium', N'+32', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'BF', 'Burkina Faso', N'+226', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'BG', 'Bulgaria', N'+359', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'BH', 'Bahrain', N'+973', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'BI', 'Burundi', N'+257', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'BJ', 'Benin', N'+229', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'BL', 'Saint Barthélemy', N'+590', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'BM', 'Bermuda', N'+1441', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'BN', 'Brunei Darussalam', N'+673', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'BO', 'Bolivia', N'+591', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'BQ', 'Bonaire, Sint Eustatius and Saba', N'+599', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'BR', 'Brazil', N'+55', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'BS', 'Bahamas', N'+1242', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'BT', 'Bhutan', N'+975', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AN', 'Antarctica', 'BV', 'Bouvet Island', N'+47', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'BW', 'Botswana', N'+267', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'BY', 'Belarus', N'+375', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'BZ', 'Belize', N'+501', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'CA', 'Canada', N'+1', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'CC', 'Cocos (Keeling) Islands', N'+61', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'CD', 'Congo, the Democratic Republic of the', N'+243', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'CF', 'Central African Republic', N'+236', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'CG', 'Congo', N'+242', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'CH', 'Switzerland', N'+41', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'CI', 'Côte d Ivoire', N'+225', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'CK', 'Cook Islands', N'+682', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'CL', 'Chile', N'+56', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'CM', 'Cameroon', N'+237', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'CN', 'China', N'+86', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'CO', 'Colombia', N'+57', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'CR', 'Costa Rica', N'+506', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'CU', 'Cuba', N'+53', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'CV', 'Cape Verde', N'+238', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'CW', 'Curaçao', N'+599', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'CX', 'Christmas Island', N'+61', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'CY', 'Cyprus', N'+357', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'CZ', 'Czech Republic', N'+420', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'DE', 'Germany', N'+49', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'DJ', 'Djibouti', N'+253', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'DK', 'Denmark', N'+45', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'DM', 'Dominica', N'+1767', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'DO', 'Dominican Republic', N'+1809,+1829,+1849', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'DZ', 'Algeria', N'+213', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'EC', 'Ecuador', N'+593', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'EE', 'Estonia', N'+372', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'EG', 'Egypt', N'+20', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'EH', 'Western Sahara', N'+212', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'ER', 'Eritrea', N'+291', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'ES', 'Spain', N'+34', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'ET', 'Ethiopia', N'+251', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'FI', 'Finland', N'+358', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'FJ', 'Fiji', N'+679', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'FK', 'Falkland Islands (Malvinas)', N'+500', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'FM', 'Micronesia, Federated States of', N'+691', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'FO', 'Faroe Islands', N'+298', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'FR', 'France', N'+33', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'GA', 'Gabon', N'+241', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'GB', 'United Kingdom', N'+44', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'GD', 'Grenada', N'+1473', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'GE', 'Georgia', N'+995', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'GF', 'French Guiana', N'+594', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'GG', 'Guernsey', N'+44-1481', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'GH', 'Ghana', N'+233', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'GI', 'Gibraltar', N'+350', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'GL', 'Greenland', N'+299', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'GM', 'Gambia', N'+220', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'GN', 'Guinea', N'+224', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'GP', 'Guadeloupe', N'+590', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'GQ', 'Equatorial Guinea', N'+240', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'GR', 'Greece', N'+30', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AN', 'Antarctica', 'GS', 'South Georgia and the South Sandwich Islands', N'+500', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'GT', 'Guatemala', N'+502', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'GU', 'Guam', N'+1671', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'GW', 'Guinea-Bissau', N'+245', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'GY', 'Guyana', N'+592', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'HK', 'Hong Kong', N'+852', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'HM', 'Heard Island and McDonald Islands', N'+672', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'HN', 'Honduras', N'+504', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'HR', 'Croatia', N'+385', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'HT', 'Haiti', N'+509', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'HU', 'Hungary', N'+36', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'ID', 'Indonesia', N'+62', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'IE', 'Ireland', N'+353', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'IL', 'Israel', N'+972', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'IM', 'Isle of Man', N'+44-1624', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'IN', 'India', N'+91', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'IO', 'British Indian Ocean Territory', N'+246', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'IQ', 'Iraq', N'+964', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'IR', 'Iran', N'+98', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'IS', 'Iceland', N'+354', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'IT', 'Italy', N'+39', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'JE', 'Jersey', N'+44', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'JM', 'Jamaica', N'+1876', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'JO', 'Jordan', N'+962', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'JP', 'Japan', N'+81', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'KE', 'Kenya', N'+254', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'KG', 'Kyrgyzstan', N'+996', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'KH', 'Cambodia', N'+855', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'KI', 'Kiribati', N'+686', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'KM', 'Comoros', N'+269', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'KN', 'Saint Kitts and Nevis', N'+1869', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'KP', 'Korea, Democratic Peoples Republic of', N'+850', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'KR', 'Korea, Republic of', N'+82', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'KW', 'Kuwait', N'+965', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'KY', 'Cayman Islands', N'+1345', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'KZ', 'Kazakhstan', N'+7', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'LA', 'Lao People s Democratic Republic', N'+856', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'LB', 'Lebanon', N'+961', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'LC', 'Saint Lucia', N'+1758', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'LI', 'Liechtenstein', N'+423', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'LK', 'Sri Lanka', N'+94', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'LR', 'Liberia', N'+231', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'LS', 'Lesotho', N'+266', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'LT', 'Lithuania', N'+370', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'LU', 'Luxembourg', N'+352', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'LV', 'Latvia', N'+371', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'LY', 'Libya', N'+218', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MA', 'Morocco', N'+212', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'MC', 'Monaco', N'+377', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'MD', 'Moldova, Republic of', N'+373', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'ME', 'Montenegro', N'+382', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'MF', 'Saint Martin (French part)', N'+590', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MG', 'Madagascar', N'+261', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'MH', 'Marshall Islands', N'+692', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'MK', 'Macedonia, the Former Yugoslav Republic of', N'+389', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'ML', 'Mali', N'+223', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'MM', 'Myanmar', N'+95', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'MN', 'Mongolia', N'+976', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'MO', 'Macao', N'+853', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'MP', 'Northern Mariana Islands', N'+1670', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'MQ', 'Martinique', N'+596', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MR', 'Mauritania', N'+222', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'MS', 'Montserrat', N'+1664', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MT', 'Malta', N'+356', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MU', 'Mauritius', N'+230', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MV', 'Maldives', N'+960', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MW', 'Malawi', N'+265', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'NA', 'North America', 'MX', 'Mexico', N'+52', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'MY', 'Malaysia', N'+60', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'MZ', 'Mozambique', N'+258', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'NA', 'Namibia', N'+264', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'NC', 'New Caledonia', N'+687', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'NE', 'Niger', N'+227', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'NF', 'Norfolk Island', N'+672', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AF', 'Africa', 'NG', 'Nigeria', N'+234', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'SA', 'South America', 'NI', 'Nicaragua', N'+505', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'NL', 'Netherlands', N'+31', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'NO', 'Norway', N'+47', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'NP', 'Nepal', N'+977', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'NR', 'Nauru', N'+674', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'NU', 'Niue', N'+683', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'NZ', 'New Zealand', N'+64', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'OM', 'Oman', N'+968', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'PA', 'Panama', N'+507', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'PE', 'Peru', N'+51', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'PF', 'French Polynesia', N'+689', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'PG', 'Papua New Guinea', N'+675', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'PH', 'Philippines', N'+63', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'PK', 'Pakistan', N'+92', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'PL', 'Poland', N'+48', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'PM', 'Saint Pierre and Miquelon', N'+508', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'PN', 'Pitcairn', N'+64', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'PR', 'Puerto Rico', N'+1-787', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'PS', 'Palestine, State of', N'+970', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'PT', 'Portugal', N'+351', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'EU', 'Europe', 'PW', 'Palau', N'+680', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'PY', 'Paraguay', N'+595', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'QA', 'Qatar', N'+974', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'RE', 'Reunion', N'+262', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'RO', 'Romania', N'+40', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'RS', 'Serbia', N'+381', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'RU', 'Russian Federation', N'+7', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'RW', 'Rwanda', N'+250', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SA', 'Saudi Arabia', N'+966', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SB', 'Solomon Islands', N'+677', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SC', 'Seychelles', N'+248', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SD', 'Sudan', N'+249', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SE', 'Sweden', N'+46', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SG', 'Singapore', N'+65', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'SH', 'Saint Helena', N'+290', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'SI', 'Slovenia', N'+386', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'SJ', 'Svalbard and Jan Mayen', N'+47', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SK', 'Slovakia', N'+421', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SL', 'Sierra Leone', N'+232', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SM', 'San Marino', N'+378', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SN', 'Senegal', N'+221', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SO', 'Somalia', N'+252', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SR', 'Suriname', N'+597', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SS', 'South Sudan', N'+211', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'ST', 'Sao Tome and Principe', N'+239', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SV', 'El Salvador', N'+503', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SX', 'Sint Maarten (Dutch part)', N'+1721', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SY', 'Syrian Arab Republic', N'+963', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'SZ', 'Eswatini', N'+268', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TC', 'Turks and Caicos Islands', N'+1649', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TD', 'Chad', N'+235', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TF', 'French Southern Territories', N'+262', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TG', 'Togo', N'+228', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TH', 'Thailand', N'+66', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TJ', 'Tajikistan', N'+992', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TK', 'Tokelau', N'+690', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TL', 'Timor-Leste', N'+670', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TM', 'Turkmenistan', N'+993', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TN', 'Tunisia', N'+216', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TO', 'Tonga', N'+676', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TR', 'Turkey', N'+90', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TT', 'Trinidad and Tobago', N'+1868', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TV', 'Tuvalu', N'+688', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'AS', 'Asia', 'TW', 'Taiwan', N'+886', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'TZ', 'Tanzania, United Republic of', N'+255', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'UA', 'Ukraine', N'+380', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'UG', 'Uganda', N'+256', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'UM', 'United States Minor Outlying Islands', N'+1', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'US', 'United States of America', N'+1', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'UY', 'Uruguay', N'+598', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'UZ', 'Uzbekistan', N'+998', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'VA', 'Holy See', N'+379', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'VC', 'Saint Vincent and the Grenadines', N'+1784', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'VE', 'Venezuela, Bolivarian Republic of', N'+58', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'VG', 'Virgin Islands, British', N'+1284', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'VI', 'Virgin Islands, U.S.', N'+1340', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'VN', 'Viet Nam', N'+84', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'VU', 'Vanuatu', N'+678', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'WF', 'Wallis and Futuna', N'+681', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'WS', 'Samoa', N'+685', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'YE', 'Yemen', N'+967', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'YT', 'Mayotte', N'+262', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'ZA', 'South Africa', N'+27', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'ZM', 'Zambia', N'+260', GETUTCDATE(), GETUTCDATE()),
                      (NEWID(), 0.00, 'OC', 'Oceania', 'ZW', 'Zimbabwe', N'+263', GETUTCDATE(), GETUTCDATE())
                END
            ");

            migrationBuilder.Sql(
                @$"IF NOT EXISTS(SELECT * FROM [AMSS_N].[dbo].[Provinces] WHERE CountryCode = 'VN')
                BEGIN 
                    INSERT INTO [AMSS_N].[dbo].[Provinces] ([Id], [Code], [CountryCode], [Name], [Category]) VALUES
	                (NEWID(), 'VN-44', 'VN', N'An Giang', 'Province'),
	                (NEWID(), 'VN-43', 'VN', N'Bà Rịa - Vũng Tàu', 'Province'),
	                (NEWID(), 'VN-54', 'VN', N'Bắc Giang', 'Province'),
	                (NEWID(), 'VN-53', 'VN', N'Bắc Kạn', 'Province'),
	                (NEWID(), 'VN-55', 'VN', N'Bạc Liêu', 'Province'),
	                (NEWID(), 'VN-56', 'VN', N'Bắc Ninh', 'Province'),
	                (NEWID(), 'VN-50', 'VN', N'Bến Tre', 'Province'),
	                (NEWID(), 'VN-31', 'VN', N'Bình Định', 'Province'),
	                (NEWID(), 'VN-57', 'VN', N'Bình Dương', 'Province'),
	                (NEWID(), 'VN-58', 'VN', N'Bình Phước', 'Province'),
	                (NEWID(), 'VN-40', 'VN', N'Bình Thuận', 'Province'),
	                (NEWID(), 'VN-59', 'VN', N'Cà Mau', 'Province'),
	                (NEWID(), 'VN-04', 'VN', N'Cao Bằng', 'Province'),
	                (NEWID(), 'VN-33', 'VN', N'Đắk Lắk', 'Province'),
	                (NEWID(), 'VN-72', 'VN', N'Đắk Nông', 'Province'),
	                (NEWID(), 'VN-71', 'VN', N'Điện Biên', 'Province'),
	                (NEWID(), 'VN-39', 'VN', N'Đồng Nai', 'Province'),
	                (NEWID(), 'VN-45', 'VN', N'Đồng Tháp', 'Province'),
	                (NEWID(), 'VN-30', 'VN', N'Gia Lai', 'Province'),
	                (NEWID(), 'VN-03', 'VN', N'Hà Giang', 'Province'),
	                (NEWID(), 'VN-63', 'VN', N'Hà Nam', 'Province'),
	                (NEWID(), 'VN-23', 'VN', N'Hà Tĩnh', 'Province'),
	                (NEWID(), 'VN-61', 'VN', N'Hải Dương', 'Province'),
	                (NEWID(), 'VN-73', 'VN', N'Hậu Giang', 'Province'),
	                (NEWID(), 'VN-14', 'VN', N'Hòa Bình', 'Province'),
	                (NEWID(), 'VN-66', 'VN', N'Hưng Yên', 'Province'),
	                (NEWID(), 'VN-34', 'VN', N'Khánh Hòa', 'Province'),
	                (NEWID(), 'VN-47', 'VN', N'Kiên Giang', 'Province'),
	                (NEWID(), 'VN-28', 'VN', N'Kon Tum', 'Province'),
	                (NEWID(), 'VN-01', 'VN', N'Lai Châu', 'Province'),
	                (NEWID(), 'VN-35', 'VN', N'Lâm Đồng', 'Province'),
	                (NEWID(), 'VN-09', 'VN', N'Lạng Sơn', 'Province'),
	                (NEWID(), 'VN-02', 'VN', N'Lào Cai', 'Province'),
	                (NEWID(), 'VN-41', 'VN', N'Long An', 'Province'),
	                (NEWID(), 'VN-67', 'VN', N'Nam Định', 'Province'),
	                (NEWID(), 'VN-22', 'VN', N'Nghệ An', 'Province'),
	                (NEWID(), 'VN-18', 'VN', N'Ninh Bình', 'Province'),
	                (NEWID(), 'VN-36', 'VN', N'Ninh Thuận', 'Province'),
	                (NEWID(), 'VN-68', 'VN', N'Phú Thọ', 'Province'),
	                (NEWID(), 'VN-68', 'VN', N'Phú Thọ', 'Province'),
	                (NEWID(), 'VN-68', 'VN', N'Phú Thọ', 'Province'),
	                (NEWID(), 'VN-32', 'VN', N'Phú Yên', 'Province'),
	                (NEWID(), 'VN-24', 'VN', N'Quảng Bình', 'Province'),
	                (NEWID(), 'VN-27', 'VN', N'Quảng Nam', 'Province'),
	                (NEWID(), 'VN-29', 'VN', N'Quảng Ngãi', 'Province'),
	                (NEWID(), 'VN-13', 'VN', N'Quảng Ninh', 'Province'),
	                (NEWID(), 'VN-25', 'VN', N'Quảng Trị', 'Province'),
	                (NEWID(), 'VN-52', 'VN', N'Sóc Trăng', 'Province'),
	                (NEWID(), 'VN-05', 'VN', N'Sơn La', 'Province'),
	                (NEWID(), 'VN-37', 'VN', N'Tây Ninh', 'Province'),
	                (NEWID(), 'VN-20', 'VN', N'Thái Bình', 'Province'),
	                (NEWID(), 'VN-69', 'VN', N'Thái Nguyên', 'Province'),
	                (NEWID(), 'VN-21', 'VN', N'Thanh Hóa', 'Province'),
	                (NEWID(), 'VN-26', 'VN', N'Thừa Thiên Huế', 'Province'),
	                (NEWID(), 'VN-46', 'VN', N'Tiền Giang', 'Province'),
	                (NEWID(), 'VN-51', 'VN', N'Trà Vinh', 'Province'),
	                (NEWID(), 'VN-07', 'VN', N'Tuyên Quang', 'Province'),
	                (NEWID(), 'VN-49', 'VN', N'Vĩnh Long', 'Province'),
	                (NEWID(), 'VN-70', 'VN', N'Vĩnh Phúc', 'Province'),
	                (NEWID(), 'VN-06', 'VN', N'Yên Bái', 'Province'),
	                (NEWID(), 'VN-CT', 'VN', N'Cần Thơ', 'Municipality'),
	                (NEWID(), 'VN-DN', 'VN', N'Đà Nẵng', 'Municipality'),
	                (NEWID(), 'VN-HN', 'VN', N'Hà Nội', 'Municipality'),
	                (NEWID(), 'VN-HP', 'VN', N'Hải Phòng', 'Municipality'),
	                (NEWID(), 'VN-SG', 'VN', N'Hồ Chí Minh', 'Municipality');
                END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
