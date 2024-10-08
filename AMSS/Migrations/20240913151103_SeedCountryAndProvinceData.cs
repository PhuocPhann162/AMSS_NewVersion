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
                    INSERT INTO [AMSS_N].[dbo].[CountryContinents] (Id, Co2Rate, ContinentCode, ContinentName, CountryCode, CountryName, CreatedAt, UpdatedAt)
                    VALUES
                    (NEWID(), 0.00, 'EU', 'Europe', 'AD', 'Andorra', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'AE', 'United Arab Emirates', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'AF', 'Afghanistan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'AG', 'Antigua and Barbuda', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'AI', 'Anguilla', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'AL', 'Albania', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'AM', 'Armenia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'AO', 'Angola', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AN', 'Antarctica', 'AQ', 'Antarctica', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'AR', 'Argentina', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'AS', 'American Samoa', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'AT', 'Austria', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'AU', 'Australia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'AW', 'Aruba', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'AX', 'Åland Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'AZ', 'Azerbaijan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'BA', 'Bosnia and Herzegovina', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'BB', 'Barbados', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'BD', 'Bangladesh', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'BE', 'Belgium', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'BF', 'Burkina Faso', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'BG', 'Bulgaria', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'BH', 'Bahrain', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'BI', 'Burundi', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'BJ', 'Benin', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'BL', 'Saint Barthélemy', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'BM', 'Bermuda', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'BN', 'Brunei Darussalam', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'BO', 'Bolivia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'BQ', 'Bonaire, Sint Eustatius and Saba', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'BR', 'Brazil', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'BS', 'Bahamas', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'BT', 'Bhutan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AN', 'Antarctica', 'BV', 'Bouvet Island', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'BW', 'Botswana', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'BY', 'Belarus', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'BZ', 'Belize', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'CA', 'Canada', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'CC', 'Cocos (Keeling) Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'CD', 'Congo, the Democratic Republic of the', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'CF', 'Central African Republic', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'CG', 'Congo', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'CH', 'Switzerland', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'CI', 'Côte d Ivoire', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'CK', 'Cook Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'CL', 'Chile', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'CM', 'Cameroon', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'CN', 'China', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'CO', 'Colombia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'CR', 'Costa Rica', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'CU', 'Cuba', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'CV', 'Cape Verde', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'CW', 'Curaçao', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'CX', 'Christmas Island', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'CY', 'Cyprus', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'CZ', 'Czech Republic', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'DE', 'Germany', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'DJ', 'Djibouti', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'DK', 'Denmark', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'DM', 'Dominica', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'DO', 'Dominican Republic', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'DZ', 'Algeria', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'EC', 'Ecuador', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'EE', 'Estonia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'EG', 'Egypt', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'EH', 'Western Sahara', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'ER', 'Eritrea', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'ES', 'Spain', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'ET', 'Ethiopia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'FI', 'Finland', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'FJ', 'Fiji', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'FK', 'Falkland Islands (Malvinas)', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'FM', 'Micronesia, Federated States of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'FO', 'Faroe Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'FR', 'France', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'GA', 'Gabon', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'GB', 'United Kingdom', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'GD', 'Grenada', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'GE', 'Georgia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'GF', 'French Guiana', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'GG', 'Guernsey', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'GH', 'Ghana', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'GI', 'Gibraltar', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'GL', 'Greenland', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'GM', 'Gambia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'GN', 'Guinea', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'GP', 'Guadeloupe', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'GQ', 'Equatorial Guinea', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'GR', 'Greece', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AN', 'Antarctica', 'GS', 'South Georgia and the South Sandwich Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'GT', 'Guatemala', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'GU', 'Guam', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'GW', 'Guinea-Bissau', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'GY', 'Guyana', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'HK', 'Hong Kong', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'HM', 'Heard Island and McDonald Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'HN', 'Honduras', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'HR', 'Croatia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'HT', 'Haiti', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'HU', 'Hungary', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'ID', 'Indonesia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'IE', 'Ireland', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'IL', 'Israel', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'IM', 'Isle of Man', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'IN', 'India', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'IO', 'British Indian Ocean Territory', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'IQ', 'Iraq', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'IR', 'Iran', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'IS', 'Iceland', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'IT', 'Italy', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'JE', 'Jersey', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'JM', 'Jamaica', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'JO', 'Jordan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'JP', 'Japan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'KE', 'Kenya', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'KG', 'Kyrgyzstan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'KH', 'Cambodia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'KI', 'Kiribati', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'KM', 'Comoros', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'KN', 'Saint Kitts and Nevis', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'KP', 'Korea, Democratic Peoples Republic of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'KR', 'Korea, Republic of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'KW', 'Kuwait', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'KY', 'Cayman Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'KZ', 'Kazakhstan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'LA', 'Lao People s Democratic Republic', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'LB', 'Lebanon', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'LC', 'Saint Lucia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'LI', 'Liechtenstein', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'LK', 'Sri Lanka', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'LR', 'Liberia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'LS', 'Lesotho', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'LT', 'Lithuania', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'LU', 'Luxembourg', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'LV', 'Latvia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'LY', 'Libya', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MA', 'Morocco', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'MC', 'Monaco', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'MD', 'Moldova, Republic of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'ME', 'Montenegro', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'MF', 'Saint Martin (French part)', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MG', 'Madagascar', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'MH', 'Marshall Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'MK', 'Macedonia, the Former Yugoslav Republic of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'ML', 'Mali', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'MM', 'Myanmar', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'MN', 'Mongolia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'MO', 'Macao', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'MP', 'Northern Mariana Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'MQ', 'Martinique', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MR', 'Mauritania', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'MS', 'Montserrat', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MT', 'Malta', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MU', 'Mauritius', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MV', 'Maldives', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MW', 'Malawi', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'NA', 'North America', 'MX', 'Mexico', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'MY', 'Malaysia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'MZ', 'Mozambique', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'NA', 'Namibia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'NC', 'New Caledonia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'NE', 'Niger', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'NF', 'Norfolk Island', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AF', 'Africa', 'NG', 'Nigeria', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'SA', 'South America', 'NI', 'Nicaragua', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'NL', 'Netherlands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'NO', 'Norway', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'NP', 'Nepal', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'NR', 'Nauru', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'NU', 'Niue', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'NZ', 'New Zealand', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'OM', 'Oman', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'PA', 'Panama', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'PE', 'Peru', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'PF', 'French Polynesia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'PG', 'Papua New Guinea', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'PH', 'Philippines', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'PK', 'Pakistan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'PL', 'Poland', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'PM', 'Saint Pierre and Miquelon', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'PN', 'Pitcairn', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'PR', 'Puerto Rico', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'PS', 'Palestine, State of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'PT', 'Portugal', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'EU', 'Europe', 'PW', 'Palau', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'PY', 'Paraguay', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'QA', 'Qatar', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'RE', 'Reunion', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'RO', 'Romania', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'RS', 'Serbia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'RU', 'Russian Federation', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'RW', 'Rwanda', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SA', 'Saudi Arabia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SB', 'Solomon Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SC', 'Seychelles', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SD', 'Sudan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SE', 'Sweden', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SG', 'Singapore', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'SH', 'Saint Helena', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'SI', 'Slovenia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'SJ', 'Svalbard and Jan Mayen', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SK', 'Slovakia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SL', 'Sierra Leone', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SM', 'San Marino', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SN', 'Senegal', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SO', 'Somalia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SR', 'Suriname', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SS', 'South Sudan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'ST', 'Sao Tome and Principe', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SV', 'El Salvador', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SX', 'Sint Maarten (Dutch part)', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC','Oceania', 'SY', 'Syrian Arab Republic', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'SZ', 'Eswatini', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TC', 'Turks and Caicos Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TD', 'Chad', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TF', 'French Southern Territories', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TG', 'Togo', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TH', 'Thailand', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TJ', 'Tajikistan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TK', 'Tokelau', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TL', 'Timor-Leste', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TM', 'Turkmenistan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TN', 'Tunisia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TO', 'Tonga', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TR', 'Turkey', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TT', 'Trinidad and Tobago', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TV', 'Tuvalu', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'AS', 'Asia', 'TW', 'Taiwan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'TZ', 'Tanzania, United Republic of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'UA', 'Ukraine', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'UG', 'Uganda', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'UM', 'United States Minor Outlying Islands', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'US', 'United States of America', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'UY', 'Uruguay', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'UZ', 'Uzbekistan', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'VA', 'Holy See', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'VC', 'Saint Vincent and the Grenadines', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'VE', 'Venezuela, Bolivarian Republic of', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'VG', 'Virgin Islands, British', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'VI', 'Virgin Islands, U.S.', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'VN', 'Viet Nam', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'VU', 'Vanuatu', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'WF', 'Wallis and Futuna', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'WS', 'Samoa', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'YE', 'Yemen', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'YT', 'Mayotte', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'ZA', 'South Africa', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'ZM', 'Zambia', GETUTCDATE(), GETUTCDATE()),
                    (NEWID(), 0.00, 'OC', 'Oceania', 'ZW', 'Zimbabwe', GETUTCDATE(), GETUTCDATE())
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
