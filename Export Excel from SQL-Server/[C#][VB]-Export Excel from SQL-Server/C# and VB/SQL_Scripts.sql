---
-- IMPORTANT  First create a database named ExcelExporting
---

/* Drop and Recreate Table */
IF EXISTS(SELECT * FROM sys.sysobjects WHERE type = 'U' AND name = 'Customers')
BEGIN
    DROP TABLE dbo.Customers;
END
GO

CREATE TABLE dbo.Customers(
	CustomerIdentifier INT IDENTITY(1,1) NOT NULL,
	CompanyName NVARCHAR(40) NOT NULL,
	ContactName NVARCHAR(30) NULL,
	ContactTitle NVARCHAR(30) NULL,
	Address NVARCHAR(60) NULL,
	City NVARCHAR(15) NULL,
	Region NVARCHAR(15) NULL,
	PostalCode NVARCHAR(10) NULL,
	Country NVARCHAR(15) NULL,
	Phone NVARCHAR(24) NULL,
 CONSTRAINT PK_Customers_1 PRIMARY KEY CLUSTERED 
(
	CustomerIdentifier ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Bardudollantor Holdings ', N'Regina Mc Gee', N'Technical', N'89 Green Nobel Freeway', N'St. Louis', N'UT-ZV', N'86036', N'Tonga', N'404-9904812')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Parsapadan  ', N'Dewayne Forbes', N'Prepaid Customer', N'54 South Second Parkway', N'Fort Worth', N'VA-PL', N'98849', N'Cape Verde', N'6590516203')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Ciprobin Direct Inc', N'Jolene Nunez', N'Web', N'85 Old Avenue', N'Denver', N'OK-SD', N'18483', N'Guinea', N'892458-2226')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Tuperax  ', N'Tricia Ingram', N'Technical', N'860 East Rocky Fabien Freeway', N'Norfolk', N'PA-EU', N'07514', N'Estonia', N'350-7139889')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Sursipplover Direct ', N'Shane Anderson', N'Service', N'36 Green Nobel Blvd.', N'Miami', N'MD-VQ', N'09047', N'Somalia', N'697-563-1683')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Kliglibantor Holdings ', N'Marjorie Perez', N'Technical', N'412 Second Drive', N'Columbus', N'NM-AD', N'21100', N'Malvinas', N'7250266524')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Rapniponistor Holdings Corp.', N'Olivia Stokes', N'Technical', N'13 New Boulevard', N'Jacksonville', N'IA-CK', N'15986', N'Liberia', N'669-2527282')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Parzapeficator WorldWide ', N'Alisa Santos', N'Web', N'559 Rocky Fabien Avenue', N'Little Rock', N'HI-KA', N'05975', N'Kazakhstan', N'039-730-4383')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES (N'Dopzapover Holdings ', N'Felix Lawson', N'Accounting', N'96 White Nobel Drive', N'Anaheim', N'OK-TA', N'12879', N'Venezuela', N'9395752097')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Frotinor WorldWide Company', N'Wendi Ross', N'Accounting', N'72 White Second Road', N'Baltimore', N'AL-JJ', N'86163', N'Denmark', N'8333602586')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emkililantor  ', N'Sheryl Hale', N'Service', N'62 Second Drive', N'Fremont', N'CO-OY', N'04101', N'Congo', N'968-4293726')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Parbanar Holdings ', N'Jody Browning', N'Prepaid Customer', N'48 Rocky Fabien Blvd.', N'Virginia Beach', N'AR-JO', N'20856', N'Philippines', N'7330933314')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trukilonentor WorldWide Group', N'Bradford Bentley', N'Prepaid Customer', N'606 South Fabien Parkway', N'Detroit', N'OR-CK', N'91041', N'Bulgaria', N'989-6185367')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thrudimazz International ', N'Scottie Spence', N'Corporate Customer', N'106 Second Way', N'Detroit', N'WY-KO', N'43313', N'Nepal', N'5338290210')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supwerpantor Direct Inc', N'Darren Barry', N'Customer', N'750 Green First Parkway', N'Omaha', N'NH-ON', N'85152', N'Micronesia', N'015-489-5571')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Indudistor  Corp.', N'Rhonda Gamble', N'Accounting', N'47 Old Boulevard', N'Jacksonville', N'OK-GU', N'64228', N'Angola', N'726-9056801')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supweramar WorldWide Group', N'Annie Adams', N'Technical', N'79 East White First St.', N'Bakersfield', N'CA-LQ', N'99414', N'Denmark', N'3984837418')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwifropaquax International Company', N'Alvin Benton', N'Service', N'960 South Hague Avenue', N'San Antonio', N'TX-UX', N'05507', N'Uzbekistan', N'3578679589')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Suphupegar  Inc', N'Luke Rocha', N'Accounting', N'21 Oak Blvd.', N'Lincoln', N'LA-NG', N'53532', N'Timor-Leste', N'5785709974')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unsipewower WorldWide ', N'Evan Russell', N'Marketing', N'10 Hague Road', N'Nashville', N'RI-BF', N'38161', N'Iran', N'597-1157128')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupkilover Direct Inc', N'Lynette Day', N'Service', N'36 West Green First Freeway', N'Omaha', N'AL-RE', N'67749', N'Tajikistan', N'8949646426')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Varcadazz WorldWide ', N'Kelly Pratt', N'Service', N'555 New Drive', N'Dallas', N'SD-BZ', N'57284', N'Slovenia', N'9920844111')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rapmunegan  Inc', N'Helen Collier', N'Accounting', N'97 Green Cowley Road', N'Yonkers', N'PA-LE', N'42881', N'Guadeloupe', N'341940-9408')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Suptumplan Direct Corp.', N'Rochelle Robles', N'Accounting', N'59 Old Drive', N'Jackson', N'VA-RX', N'98840', N'South Georgia', N'689-7840566')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Haptumedover Direct Corp.', N'Karen Pope', N'Technical', N'55 North Second Drive', N'Washington', N'CT-WK', N'73218', N'Lebanon', N'743-1244819')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thrududegover Holdings Corp.', N'Herman Huffman', N'Technical', N'316 Cowley Drive', N'Stockton', N'NY-SO', N'03785', N'North Korea', N'575-520-4961')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winkilicator Direct ', N'Courtney Faulkner', N'Service', N'34 South Rocky Nobel Boulevard', N'Cleveland', N'ID-CN', N'75644', N'Slovenia', N'484-4104424')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupjubefower Direct Company', N'Abel Gallagher', N'Accessory Customer', N'618 Green New Street', N'Jackson', N'GA-UN', N'46948', N'New Caledonia', N'975-293-4382')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rapfropax International ', N'Courtney Hubbard', N'Service', N'67 Green Cowley Parkway', N'Columbus', N'RI-NE', N'14637', N'Rwanda', N'1525383708')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Monjubor  ', N'Gerard Beck', N'Accounting', N'510 Cowley Freeway', N'San Jose', N'MT-AC', N'71686', N'Macedonia', N'106-735-4420')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thrubananar Holdings Group', N'Stephen Ali', N'Web', N'59 First Boulevard', N'Houston', N'NY-WR', N'94828', N'Burkina Faso', N'127816-5972')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Partinefor Holdings ', N'Marie Wilkins', N'Service', N'55 Old Boulevard', N'Shreveport', N'OK-ZN', N'35710', N'Mauritania', N'495-477-7018')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thrusapor WorldWide ', N'Alejandro Conrad', N'Prepaid Customer', N'65 New Blvd.', N'Kansas', N'TN-CA', N'15379', N'Luxembourg', N'118-0020434')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emdudepentor WorldWide ', N'Leonard Ritter', N'Service', N'88 West Nobel Freeway', N'Baltimore', N'GA-OG', N'93420', N'Congo', N'763-5993537')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Haperover  Corp.', N'Jimmie Hoover', N'Web', N'831 North Rocky Clarendon Blvd.', N'Oakland', N'TX-YP', N'36641', N'Jamaica', N'807414-4682')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopsapupin WorldWide Company', N'Trisha Travis', N'Service', N'136 White Oak Way', N'Fort Wayne', N'VA-VP', N'09904', N'Bermuda', N'942-1662190')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klikilentor  ', N'Shauna Harrell', N'Accounting', N'46 New Avenue', N'Milwaukee', N'MI-KP', N'12781', N'Niger', N'574-9785198')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endnipar Direct Corp.', N'Clarence Ayers', N'Accounting', N'27 Hague St.', N'Mobile', N'KS-KB', N'10402', N'South Korea', N'807921-2303')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grosipanex  ', N'Jonathan Shah', N'Accounting', N'591 White Oak Parkway', N'Boston', N'PA-TF', N'09229', N'Philippines', N'214-7152532')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Hapkilicator WorldWide Group', N'Stephanie Lyons', N'Service', N'946 White First St.', N'Des Moines', N'VT-WQ', N'16348', N'Libya', N'9681422500')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winrobilicator  ', N'Derrick Mills', N'Accounting', N'17 White First Blvd.', N'St. Louis', N'GA-RP', N'49440', N'New Zealand', N'6644786475')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Lomfropefex Holdings Inc', N'Tyrone Villarreal', N'Service', N'419 South Rocky Fabien Freeway', N'San Jose', N'AR-IC', N'70025', N'United Kingdom', N'399552-8976')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipwerinin  ', N'Rick Powers', N'Prepaid Customer', N'97 Green Hague Parkway', N'Fort Wayne', N'RI-IK', N'60111', N'Panama', N'2156172708')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Bardimazz WorldWide Company', N'Moses Berry', N'Sales', N'50 Hague Road', N'Yonkers', N'CO-FB', N'93443', N'Colombia', N'7763631435')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Monnipower WorldWide ', N'Yesenia Compton', N'Prepaid Customer', N'826 Milton Street', N'Colorado', N'NY-GU', N'08059', N'Botswana', N'492-588-2213')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klivenazz  Corp.', N'Jessie Weber', N'Prepaid Customer', N'519 North Green Clarendon St.', N'Boston', N'HI-EI', N'67354', N'Sri Lanka', N'7431295793')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopfropupor  Group', N'Rickey Navarro', N'Technical', N'11 White Milton Drive', N'Houston', N'GA-HK', N'97933', N'Austria', N'182259-8864')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Raprobplower  ', N'Derek Mills', N'Prepaid Customer', N'544 Milton Avenue', N'Mesa', N'VT-JU', N'17355', N'Moldova', N'149608-1066')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tiprobor International ', N'Rhonda Stout', N'Technical', N'77 Old Freeway', N'Las Vegas', N'ID-KI', N'19535', N'Uganda', N'8944922435')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Hapfropadistor WorldWide Company', N'Lester Medina', N'Accessory Customer', N'93 White Cowley Drive', N'Greensboro', N'UT-NR', N'79523', N'Fiji', N'2641831913')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupvenamistor  ', N'Malcolm Turner', N'Service', N'11 New Drive', N'Arlington', N'NJ-VB', N'11015', N'Grenada', N'183830-1146')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Monsapazz Holdings ', N'Isaac Crosby', N'Web', N'948 Fabien Road', N'Fremont', N'FL-ZJ', N'31692', N'Gibraltar', N'163469-9598')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rekilamor Holdings ', N'Jacob Small', N'National Sales', N'47 Oak St.', N'Nashville', N'NV-OP', N'06013', N'Jamaica', N'488416-9623')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Suptanor  ', N'Yvette Hubbard', N'Service', N'17 Rocky Hague Road', N'Buffalo', N'SD-KU', N'75324', N'Bolivia', N'937-4665887')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unkilefentor WorldWide ', N'Bonnie Spears', N'Accounting', N'14 West Oak Boulevard', N'Boston', N'MD-JB', N'33187', N'Sierra Leone', N'241-3369097')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barsipexor WorldWide Group', N'Preston Gilbert', N'Technical', N'95 West New St.', N'Denver', N'MS-FK', N'76371', N'Belgium', N'835-679-7285')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Uneranover  Corp.', N'Cassandra Rangel', N'Accounting', N'732 Milton Blvd.', N'Honolulu', N'VA-EU', N'19252', N'South Africa', N'528-540-6798')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klitumewax  ', N'Neil Hogan', N'Prepaid Customer', N'16 Nobel Drive', N'Omaha', N'WI-FK', N'11713', N'Malawi', N'4681345495')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supquestommor Direct ', N'Billie Lozano', N'Web', N'725 Rocky New Street', N'Tulsa', N'SC-EY', N'45594', N'Senegal', N'041619-4307')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Parkilin Holdings ', N'Enrique Hebert', N'Accessory Marketing', N'39 Fabien Way', N'Aurora', N'NM-EF', N'88708', N'Cambodia', N'880143-1814')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dophupewicator International Group', N'Autumn Whitehead', N'Prepaid Customer', N'420 Rocky Clarendon St.', N'Anchorage', N'AZ-WF', N'74312', N'Réunion', N'044-263-2746')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winmunex  Inc', N'Kirsten Welch', N'Web', N'97 East Rocky Nobel Avenue', N'Atlanta', N'SD-ZD', N'03480', N'Sudan', N'737-643-5194')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barsipazz International Inc', N'Lea Lyons', N'Service', N'35 East Second Boulevard', N'Chicago', N'VA-YN', N'32390', N'Paraguay', N'804-986-2586')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Surcadistor International Group', N'Holly Black', N'Service', N'12 White Milton St.', N'Omaha', N'TX-FR', N'31024', N'Jersey', N'306-8085003')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Surwerpamicator International ', N'Leanne Maynard', N'Corporate Sales', N'798 North Rocky Cowley Blvd.', N'Phoenix', N'AR-DQ', N'97158', N'Barbados', N'1692399671')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emnipin  ', N'Kara Warner', N'Prepaid Customer', N'870 North New Way', N'Seattle', N'SD-KR', N'40098', N'Namibia', N'157546-7171')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Parpebefin Direct ', N'Kris Horn', N'Prepaid Customer', N'349 Rocky New Avenue', N'Detroit', N'MS-UG', N'00911', N'Costa Rica', N'9836500093')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supdimackower  ', N'Jocelyn Sexton', N'Technical', N'45 West White Hague Avenue', N'Little Rock', N'VA-EG', N'46515', N'United States', N'237-0346991')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endbanedgistor WorldWide ', N'Jeannette Howe', N'Accounting', N'27 South Nobel Avenue', N'Jersey', N'FL-ZO', N'49847', N'Costa Rica', N'058-127-5418')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Addiman International ', N'Teresa Higgins', N'Accounting', N'47 South Fabien Drive', N'Buffalo', N'AZ-PD', N'24011', N'Kyrgyzstan', N'553434-5364')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Redudazz  ', N'Latasha Cobb', N'Technical', N'732 Cowley Way', N'Fort Wayne', N'NE-WI', N'34513', N'Guyana', N'669-424-9564')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endquestedgor Holdings ', N'Trevor Suarez', N'Web', N'151 East Rocky First Drive', N'Memphis', N'WV-NI', N'34458', N'Hungary', N'515-1627171')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trunipax  Company', N'Tyler Weiss', N'Prepaid Customer', N'48 White Second Way', N'Dayton', N'LA-WE', N'31007', N'Ecuador', N'863959-3093')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tiprobor WorldWide ', N'Noel Mata', N'Prepaid Customer', N'39 Green Second Street', N'Los Angeles', N'AL-KW', N'67290', N'Iceland', N'870-3759323')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipsipazz  ', N'Iris Odom', N'Technical', N'55 Fabien Street', N'Garland', N'NE-TQ', N'40246', N'Saint Lucia', N'343329-0129')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barjubedgor  ', N'Armando Grant', N'Prepaid Customer', N'99 Green Clarendon Avenue', N'Virginia Beach', N'WI-FL', N'79847', N'United Kingdom', N'079-003-0074')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trukilimover  ', N'Rachel O''Neill', N'Web', N'86 Milton Road', N'San Antonio', N'MS-IR', N'33248', N'Bhutan', N'526-9706787')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rerobonower  Corp.', N'Kristine Bonilla', N'Customer', N'40 Rocky Oak Street', N'Arlington', N'MS-QB', N'79181', N'Chile', N'246-240-2098')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Truwerpentor WorldWide ', N'Patrick Rivera', N'Service', N'33 Milton Street', N'New Orleans', N'TN-CT', N'51724', N'Paraguay', N'245-757-2600')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopwerpimower Direct ', N'Quentin Rivas', N'Technical', N'857 Second Boulevard', N'Arlington', N'KY-TU', N'24466', N'New Caledonia', N'215647-0126')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Parzapadex Direct ', N'James Kaufman', N'Sales', N'147 Rocky Oak Blvd.', N'Anchorage', N'NC-XL', N'88717', N'Mozambique', N'9721186645')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Truglibollentor International Corp.', N'Marcie Hays', N'Technical', N'11 Green First Boulevard', N'Anchorage', N'NM-GQ', N'18446', N'Djibouti', N'6401448720')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Surerplistor International ', N'Bridgett Anderson', N'Technical', N'13 Cowley Blvd.', N'Jacksonville', N'PA-AW', N'52902', N'Pitcairn', N'521545-0395')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Surpickor International ', N'Clayton Cox', N'Corporate Customer', N'44 Green Fabien Parkway', N'Philadelphia', N'IN-EU', N'76868', N'Latvia', N'992-613-4327')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Varrobentor  ', N'Vincent Ellison', N'Accounting', N'269 Green Oak Avenue', N'Baltimore', N'SD-WG', N'65551', N'Congo', N'3973581987')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Groweristor  Corp.', N'Herman Cain', N'Sales', N'66 Rocky Cowley Avenue', N'San Diego', N'ME-WS', N'27796', N'Somalia', N'8589594902')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Haptumonantor  ', N'Felipe Chavez', N'Technical', N'223 Rocky Second Road', N'Wichita', N'TX-JA', N'46127', N'Brazil', N'117-153-4039')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Haptumax  ', N'Tabatha Francis', N'Service', N'670 West Milton Avenue', N'Des Moines', N'MI-NM', N'11537', N'Iceland', N'735844-7992')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Adpebover International Corp.', N'Roman Benjamin', N'Accessory Marketing', N'429 White Clarendon Road', N'Glendale', N'MI-ZN', N'41139', N'Hungary', N'4460272279')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endsapollar International Group', N'Ana Carlson', N'Prepaid Customer', N'45 White Hague Boulevard', N'Indianapolis', N'TN-VM', N'42014', N'Guadeloupe', N'8290356779')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Inglibentor  ', N'Nakia Figueroa', N'Customer', N'34 Hague Drive', N'Mesa', N'MN-YI', N'36712', N'France', N'251-9464562')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipjubin  Group', N'Kathleen Montgomery', N'Web', N'41 South Hague St.', N'Riverside', N'NY-UW', N'65696', N'Botswana', N'6755920993')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tuptanistor Direct ', N'Devon English', N'Accounting', N'11 White Oak Freeway', N'Charlotte', N'TN-YX', N'94964', N'Aruba', N'3587164626')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipdiman Direct ', N'Rachelle Hickman', N'Accounting', N'96 Cowley Blvd.', N'Fresno', N'GA-KU', N'92830', N'Mauritius', N'562-9102361')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grobanax Direct Inc', N'Ryan Giles', N'Accounting', N'26 South Rocky Old Way', N'San Antonio', N'NM-OV', N'18765', N'Saint Helena', N'042-978-4191')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwisapedover WorldWide ', N'Jane Arias', N'Service', N'614 South Old St.', N'Fort Wayne', N'NY-FC', N'92199', N'Sierra Leone', N'975-3661423')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rapkilistor Direct Company', N'Martin Warren', N'Accounting', N'22 White Oak Road', N'Phoenix', N'NJ-LI', N'50956', N'Ecuador', N'354-9398808')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klibanicator International Group', N'Audrey Watts', N'Technical', N'11 White Oak Drive', N'Toledo', N'WI-YA', N'54563', N'El Salvador', N'8285733867')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Adrobaquor  ', N'Latasha Stevenson', N'Consumer Customer', N'145 White First Street', N'Raleigh', N'NM-UR', N'17732', N'Belgium', N'555-9655760')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klirobar International Group', N'Steven Holloway', N'Prepaid Customer', N'921 Hague Street', N'St. Louis', N'VA-BC', N'39560', N'Libya', N'567-8546265')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rappebommax International ', N'Felix Cain', N'Accounting', N'16 Cowley St.', N'San Francisco', N'WY-EC', N'19020', N'New Caledonia', N'172-2361708')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Survenupin WorldWide ', N'Kendrick Woods', N'Accounting', N'14 First St.', N'Phoenix', N'OK-HY', N'40581', N'Bhutan', N'712-6019081')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopquestower WorldWide ', N'Natalie Marquez', N'Accounting', N'57 Green Nobel Road', N'Hialeah', N'NE-XQ', N'74567', N'Hong Kong', N'790853-2011')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Infropedax Direct ', N'Claude Harrison', N'Accounting', N'68 Oak Road', N'San Francisco', N'ID-WG', N'45535', N'Kazakhstan', N'146595-0535')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unwerentor  ', N'Gabriel Levy', N'Web', N'10 Milton Boulevard', N'Garland', N'MS-SC', N'65095', N'Trinidad', N'244-173-2798')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winfropanin  ', N'Tabatha Johns', N'Web', N'24 West Fabien Blvd.', N'Lincoln', N'KY-XE', N'58963', N'Uruguay', N'690-4417483')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipglibor  ', N'Juan Landry', N'Service', N'21 North Clarendon Drive', N'Dallas', N'LA-HU', N'13311', N'Bangladesh', N'2287504155')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupdudedentor WorldWide Company', N'Rachael Gamble', N'Prepaid Customer', N'64 White Clarendon Road', N'New Orleans', N'OH-WB', N'93636', N'Argentina', N'796-1597360')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Vareropor Holdings ', N'Derick Osborn', N'Customer', N'81 Rocky Old Blvd.', N'Anaheim', N'CT-WD', N'67292', N'Guatemala', N'680-0840848')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Frotinicator WorldWide Company', N'Ramona Berry', N'Corporate Marketing', N'476 Rocky Oak Avenue', N'Madison', N'AK-JY', N'88425', N'Swaziland', N'3967877201')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supnipommover Direct ', N'Donnie Carter', N'Service', N'17 First Drive', N'Milwaukee', N'IL-UU', N'34452', N'Virgin Islands', N'3995119586')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipnipopistor International ', N'Jessie Obrien', N'Service', N'175 Cowley Avenue', N'Cincinnati', N'OR-UP', N'41094', N'Niger', N'2118608139')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Untanentor Direct ', N'Candice Moses', N'Prepaid Customer', N'774 White New Freeway', N'Nashville', N'MT-EC', N'23313', N'South Korea', N'882-186-2895')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emvenopazz  Group', N'Vicky Lynn', N'Accounting', N'237 Oak Street', N'Honolulu', N'SD-TM', N'13922', N'Burkina Faso', N'290-514-6826')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supvenazz  ', N'Audra Garza', N'Service', N'433 White Oak Street', N'Los Angeles', N'NV-TU', N'76658', N'Malawi', N'472-0243408')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Kliwerpantor Direct ', N'Timothy Mooney', N'Marketing', N'901 South Fabien Road', N'Arlington', N'LA-GU', N'29788', N'Lithuania', N'065-9037300')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thruweranan Direct ', N'Penny Rose', N'Accounting', N'739 West Milton Way', N'Seattle', N'KS-NT', N'84028', N'Brazil', N'360-565-0445')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipwerpantor Direct Company', N'Patrick Franklin', N'Technical', N'305 Hague Parkway', N'Fremont', N'DE-FJ', N'67287', N'Czech Republic', N'1069384458')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Resapantor WorldWide Group', N'Forrest Tucker', N'Accounting', N'413 West White First Parkway', N'Virginia Beach', N'MN-WV', N'16410', N'Eritrea', N'724-7494110')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grobanplin  Company', N'Randy Hutchinson', N'Prepaid Customer', N'42 Green Cowley Avenue', N'Chicago', N'OK-LB', N'60267', N'Estonia', N'4576759711')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipkilover International ', N'Margaret Esparza', N'Prepaid Customer', N'51 North Green Nobel Road', N'Riverside', N'CT-HD', N'79356', N'Libya', N'006801-6012')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rekilex Holdings Company', N'Guillermo Mc Gee', N'Service', N'942 North New Boulevard', N'Denver', N'NV-GE', N'63562', N'Singapore', N'817-876-0679')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipzapantor Direct ', N'Ann Hood', N'Service', N'61 Nobel Road', N'Houston', N'OR-PA', N'28446', N'Malvinas', N'938353-4327')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipfropantor Holdings ', N'Wanda Faulkner', N'Prepaid Customer', N'839 Milton Avenue', N'Tampa', N'LA-PT', N'59973', N'Suriname', N'5527903320')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Intumepentor Direct ', N'Oscar Davis', N'Service', N'60 Oak Blvd.', N'Fremont', N'IL-MX', N'01842', N'Comoros', N'122-325-2821')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grorobegex International ', N'Mitchell Jensen', N'Web', N'71 White New Boulevard', N'Oklahoma', N'SD-LU', N'41645', N'Egypt', N'449441-9225')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endfropex Holdings ', N'Derek Decker', N'Accounting', N'92 Cowley Avenue', N'Madison', N'KY-QB', N'10062', N'Guadeloupe', N'9221003000')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supnipower Direct ', N'Lawanda Koch', N'Technical', N'44 Oak St.', N'Sacramento', N'CO-UK', N'35359', N'Norway', N'879-9467198')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Surnipadistor International Group', N'Jonathon O''Neill', N'Web', N'618 North White Old St.', N'Glendale', N'NV-RR', N'82461', N'Nepal', N'190-063-3421')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emvenplex WorldWide ', N'Omar Parsons', N'Prepaid Customer', N'40 First Drive', N'Columbus', N'HI-FN', N'69615', N'Vatican City', N'430-2374548')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopbanexex International Corp.', N'Terrell Neal', N'Technical', N'18 Second St.', N'Oklahoma', N'NM-AU', N'71171', N'Paraguay', N'912397-2364')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Retinin International Group', N'Myron Haley', N'Service', N'213 White Cowley Boulevard', N'Birmingham', N'CT-AW', N'27352', N'Sweden', N'525418-7105')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Varsipadicator WorldWide Company', N'Teresa Cameron', N'Prepaid Customer', N'49 Green Milton Road', N'New Orleans', N'DE-PS', N'49763', N'Bahamas', N'425-2164558')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Inquestan WorldWide ', N'Shari Gardner', N'Prepaid Customer', N'21 Old Freeway', N'Garland', N'ND-FB', N'75166', N'Côte d''Ivoire', N'963204-8297')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Monkilover  ', N'Holly Huff', N'Technical', N'80 Second Way', N'Hialeah', N'ID-VT', N'28097', N'Afghanistan', N'181-074-3573')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwirobor International Company', N'Jessica Pham', N'Accounting', N'528 Milton Drive', N'Arlington', N'DE-BV', N'30559', N'Libya', N'850183-4735')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cippebor WorldWide ', N'Quentin Powers', N'Prepaid Customer', N'62 Cowley Blvd.', N'Yonkers', N'NH-MQ', N'16322', N'Sri Lanka', N'929-531-1188')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supvenicator Holdings ', N'Josh Mcgrath', N'Sales', N'598 Clarendon Street', N'Los Angeles', N'VA-OD', N'83991', N'Eritrea', N'6202203594')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Haptanor  ', N'Latonya Bowen', N'Accounting', N'175 Green First Way', N'Jacksonville', N'RI-HM', N'90683', N'Mayotte', N'249-154-4496')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thruhuponax International ', N'Jill Fritz', N'Technical Customer', N'51 Cowley Blvd.', N'Portland', N'AZ-RD', N'30514', N'Dominica', N'905-1637118')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Parvenor WorldWide Group', N'Jon Novak', N'Service', N'79 Oak St.', N'Fort Wayne', N'SC-XA', N'03071', N'Qatar', N'0467240803')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trumunover Direct ', N'Patrice Marshall', N'Prepaid Customer', N'138 First Boulevard', N'Fort Worth', N'KS-TA', N'08964', N'Barbados', N'834-208-6015')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emkileficator Holdings ', N'Ramon Spence', N'Consumer Customer', N'73 West Rocky Fabien Blvd.', N'Boston', N'MO-LS', N'45207', N'Armenia', N'9450716672')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klitinexover International ', N'Joanne Gallegos', N'Prepaid Customer', N'45 West White Hague Parkway', N'San Antonio', N'IN-JK', N'03689', N'Malaysia', N'360-471-9647')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supmunommover WorldWide ', N'Kristin Rubio', N'Web', N'768 North Old Street', N'Little Rock', N'IN-FY', N'95642', N'Guinea', N'618-6201179')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Windudar WorldWide Corp.', N'Debra Schmitt', N'Technical', N'31 Nobel Road', N'Phoenix', N'OR-ZF', N'59102', N'Nepal', N'635-9061221')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipjubackax  Inc', N'Roberta Norton', N'Corporate Sales', N'54 Second Parkway', N'Honolulu', N'NV-YS', N'01189', N'French Guiana', N'424-572-0522')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Injubommistor Direct ', N'Meredith Fernandez', N'Web', N'257 Milton Freeway', N'Glendale', N'IN-AO', N'22593', N'Tunisia', N'2915036525')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Superin Direct ', N'Christina Landry', N'International Sales', N'41 First Road', N'Miami', N'SD-YJ', N'73221', N'Anguilla', N'309-9769126')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Monsapackex Holdings ', N'Todd O''Neal', N'Accessory Customer', N'78 North Milton Drive', N'San Jose', N'IA-NN', N'61347', N'El Salvador', N'473116-3947')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupwerepar  ', N'Carl Weber', N'Accounting', N'468 Green Hague Parkway', N'Shreveport', N'MN-DH', N'45601', N'North Korea', N'046-061-4353')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barzapex International Corp.', N'Curtis Mayer', N'Prepaid Customer', N'761 Cowley St.', N'San Jose', N'MT-WH', N'53239', N'American Samoa', N'387-8142499')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Lomdimplax WorldWide ', N'Elena Spencer', N'Accounting', N'926 New Street', N'Baltimore', N'NJ-FW', N'11435', N'Zambia', N'928457-8690')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopwerpollin  Group', N'Larry Castillo', N'Consumer Customer', N'598 First Drive', N'Baton Rouge', N'MN-KK', N'00186', N'South Georgia', N'7535229067')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Suptuman International ', N'Dan Mac Donald', N'Web', N'546 Cowley Boulevard', N'Corpus Christi', N'SD-LW', N'63703', N'Afghanistan', N'671-155-8024')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rappebefentor International Inc', N'Allen Cortez', N'Accounting', N'483 Rocky Milton Freeway', N'Lubbock', N'CO-TT', N'66343', N'Spain', N'214711-7001')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grotumantor International ', N'Daniel Booth', N'Web', N'16 Rocky Oak Blvd.', N'Philadelphia', N'NM-XO', N'61103', N'Mauritius', N'480158-2910')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipdimommex International ', N'Francisco Andrade', N'Accounting', N'783 North Green Second Boulevard', N'Portland', N'NE-DG', N'54461', N'Malawi', N'5087505582')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winsapaquin Holdings Inc', N'Casey Yu', N'Technical', N'816 North Milton Boulevard', N'Columbus', N'ND-MH', N'63553', N'Falklands', N'154905-6236')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Kliwerpin WorldWide Group', N'Tracy Cantu', N'Business Marketing', N'172 White Second Boulevard', N'Birmingham', N'ID-SS', N'56874', N'Nigeria', N'791-6138815')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rappebentor Holdings ', N'Lori Key', N'Accounting', N'197 East New Avenue', N'Arlington', N'NH-DK', N'84927', N'Montserrat', N'6766535447')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Parmunax  ', N'Herman Tate', N'Prepaid Customer', N'348 East First Boulevard', N'St. Petersburg', N'NV-DC', N'26816', N'Indonesia', N'424-5459182')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barpebantor Holdings Inc', N'Lakeisha Rivas', N'Technical', N'19 East Green New Blvd.', N'Long Beach', N'KS-OP', N'50602', N'Iran', N'0809542532')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Surtumover  Inc', N'Gena Massey', N'Prepaid Customer', N'91 Green Nobel Way', N'Jersey', N'NJ-KL', N'59274', N'Hong Kong', N'275640-1174')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tuptumax WorldWide ', N'Wallace Cochran', N'Prepaid Customer', N'144 Green Clarendon Freeway', N'Santa Ana', N'OR-RQ', N'40359', N'Cameroon', N'471-746-8871')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barvenicator  ', N'Alice Velasquez', N'Web', N'799 Hague Street', N'Newark', N'WV-TP', N'49732', N'Bolivia', N'003-161-5887')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Varsipantor International Group', N'Luke Alvarado', N'Technical', N'755 South Clarendon Avenue', N'Seattle', N'PA-FT', N'03613', N'Moldova', N'780430-8116')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Surglibicantor  Company', N'Spencer Rose', N'Technical', N'724 Rocky Fabien Drive', N'Charlotte', N'IL-ED', N'25710', N'Nauru', N'778-186-8506')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Enderin WorldWide ', N'Nicolas Barron', N'Web', N'319 Hague Parkway', N'Louisville', N'WY-HL', N'14352', N'Bulgaria', N'958-0807901')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endjubackex  ', N'Ashley Park', N'Accessory Customer', N'236 Green Second Avenue', N'Oakland', N'TX-FM', N'50097', N'Antarctica', N'0558979289')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rekilollar Holdings ', N'Darrell Fitzgerald', N'Service', N'70 First Boulevard', N'Columbus', N'PA-HZ', N'86706', N'Niue', N'833228-9724')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tuptinentor  ', N'Betty Blevins', N'Technical', N'286 North Hague Street', N'Washington', N'MA-QA', N'62879', N'Syria', N'1743009893')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Frotinexower WorldWide ', N'Maria Harrison', N'Accounting', N'37 White Hague St.', N'Grand Rapids', N'IA-OV', N'63565', N'Nicaragua', N'8003617717')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Renipupistor Holdings Corp.', N'Marilyn Cordova', N'Accounting', N'706 Clarendon Way', N'Detroit', N'WY-TH', N'22904', N'Andorra', N'173270-8273')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Raperedentor  Corp.', N'Kari Fischer', N'Web', N'67 First Road', N'Houston', N'WA-QO', N'39728', N'Malawi', N'424-9625656')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Haptinan International Company', N'Mario Barnes', N'Prepaid Customer', N'89 Green Fabien Avenue', N'Sacramento', N'WA-VE', N'81693', N'Iran', N'5832531986')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupdimackistor  Group', N'Becky Coffey', N'Service', N'11 White Milton Boulevard', N'San Diego', N'ME-QV', N'81905', N'Saint Helena', N'188421-4568')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trupebaquower WorldWide Group', N'Malcolm Jackson', N'Service', N'931 Rocky Old Blvd.', N'Tacoma', N'LA-PK', N'43459', N'Algeria', N'623-9909999')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Upmunaman Holdings ', N'Garrett Gordon', N'Prepaid Customer', N'21 First Blvd.', N'Anaheim', N'HI-XD', N'98516', N'Liberia', N'975676-3785')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipquestefor Direct ', N'Priscilla Brown', N'Accounting', N'336 New Blvd.', N'Dayton', N'AK-EG', N'78227', N'Malvinas', N'784-8661708')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emtinackar International ', N'Matthew Shields', N'Service', N'813 White Fabien Road', N'Hialeah', N'KY-LF', N'93469', N'Uruguay', N'521-798-8528')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klijubonex Holdings ', N'Latisha Thornton', N'Accounting', N'776 First Avenue', N'Glendale', N'NH-DX', N'26088', N'Italy', N'1050473167')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Upwerpplentor International Corp.', N'Ernest Mcfarland', N'Technical', N'25 Second Parkway', N'Little Rock', N'WI-MH', N'02616', N'New Caledonia', N'878-066-7037')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rewerpover WorldWide Corp.', N'Jeannie Moran', N'Technical', N'388 South Cowley Way', N'Lincoln', N'OK-OJ', N'98983', N'Haiti', N'3380210559')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Suppebover WorldWide ', N'Luke Bernard', N'Service', N'914 North White Milton Blvd.', N'Jacksonville', N'WY-PZ', N'67411', N'French Guiana', N'6311785426')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Vartumadover  Inc', N'Rafael Medina', N'Accounting', N'79 South Clarendon Boulevard', N'Washington', N'UT-RI', N'45421', N'Oman', N'0100316618')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipwerpedin Direct Corp.', N'Max Osborn', N'Prepaid Customer', N'66 North Oak Blvd.', N'Omaha', N'MN-PU', N'47463', N'Switzerland', N'507488-6492')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unrobamistor Direct ', N'Jeremiah Beard', N'Service', N'135 Old Avenue', N'Wichita', N'FL-GE', N'80910', N'Ecuador', N'694-8563220')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Revenan  ', N'Ross Galvan', N'Web', N'996 West Milton Way', N'Nashville', N'ME-GT', N'85123', N'Côte d''Ivoire', N'460466-1293')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupzapar Direct Company', N'Reginald Holden', N'Web', N'516 West Milton Street', N'Fort Wayne', N'WV-PA', N'70940', N'Cape Verde', N'538618-9377')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klidudax Holdings ', N'Demetrius Murphy', N'Service', N'75 White Second Road', N'St. Paul', N'KS-WJ', N'30554', N'Ukraine', N'268-040-9243')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rapbanedower Direct ', N'Brent Mayer', N'Accounting', N'27 West Green Nobel Road', N'Colorado', N'MO-RP', N'98047', N'Georgia', N'652935-3778')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Adtumex  ', N'Guy Moyer', N'Service', N'344 North Hague Street', N'Hialeah', N'NC-DY', N'53569', N'Yemen', N'199449-0237')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Suppickex  Group', N'Jami Peck', N'Accounting', N'64 White Old St.', N'Mesa', N'FL-KN', N'95603', N'Tonga', N'475300-9157')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Frocadar International Inc', N'Chrystal Krause', N'Web', N'773 South Oak Parkway', N'Kansas', N'MO-TL', N'31154', N'Nauru', N'2720362693')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Doperower Direct ', N'Susana Dixon', N'Technical', N'31 Old Street', N'Long Beach', N'PA-TI', N'29722', N'Greece', N'797-617-0855')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Windimilazz International ', N'Edith Copeland', N'Technical', N'370 Cowley Drive', N'Little Rock', N'PA-YI', N'73661', N'Norway', N'382306-1091')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Suptinaquazz  Inc', N'Ruth Alexander', N'Prepaid Customer', N'72 Green Cowley Blvd.', N'Santa Ana', N'ME-KJ', N'33836', N'Niger', N'717-9310073')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Invenistor International Inc', N'Jana Graves', N'Service', N'61 Green Hague Blvd.', N'St. Paul', N'MO-RD', N'31055', N'Honduras', N'271332-6366')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Ciprobistor WorldWide Group', N'Lydia Ho', N'Sales', N'78 New Avenue', N'Oakland', N'WA-VE', N'53791', N'Ecuador', N'526-9120645')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tuphupex Direct ', N'Suzanne Hayden', N'Accounting', N'512 Green Old Parkway', N'Lubbock', N'MS-EQ', N'14391', N'Armenia', N'223-3904833')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thrutuman WorldWide ', N'Raymond Allison', N'Prepaid Customer', N'39 East Green First Street', N'Phoenix', N'MT-ZD', N'02029', N'Niue', N'664-8451419')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winpebar Direct Group', N'Darius Porter', N'Consumer Sales', N'319 Second Blvd.', N'Long Beach', N'WY-GV', N'73336', N'Saudi Arabia', N'697-392-5294')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supmunover WorldWide Inc', N'Derrick Brock', N'Service', N'18 Green Fabien Avenue', N'Detroit', N'UT-HZ', N'79511', N'Zimbabwe', N'179-423-8767')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supjubackantor Direct ', N'Eddie Ewing', N'Accounting', N'98 White Nobel Drive', N'Tacoma', N'WI-PE', N'06427', N'Monaco', N'880-4186325')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Insapover International ', N'Lynn Raymond', N'Accounting', N'350 North Cowley Avenue', N'St. Paul', N'LA-FV', N'47134', N'Sierra Leone', N'5403504563')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Zeezapedar WorldWide ', N'Chanda Mahoney', N'Service', N'916 Clarendon Blvd.', N'Austin', N'CT-LP', N'94202', N'Guinea-Bissau', N'534716-9825')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endpickollin  Group', N'Darin Schmidt', N'Web', N'582 South Second Drive', N'Philadelphia', N'NV-PE', N'90148', N'Vietnam', N'097-360-3833')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endwerpadentor  ', N'Vivian Griffin', N'Web', N'84 East Oak Parkway', N'Riverside', N'KS-YS', N'11772', N'French Guiana', N'9452844878')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Upnipower  ', N'Harvey Lynn', N'Technical Customer', N'20 First St.', N'New Orleans', N'GA-VK', N'69309', N'Monaco', N'425-5759338')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Inhupewax Direct Company', N'Monte Sanford', N'Service', N'546 Milton Avenue', N'Lincoln', N'LA-IR', N'38518', N'Bangladesh', N'9825332588')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Hapdimedover Direct Inc', N'Kelley Ellison', N'Service', N'679 Fabien Boulevard', N'San Jose', N'NV-MI', N'43874', N'Malvinas', N'5810201875')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grokiledin  ', N'Max Duncan', N'Technical', N'587 South Nobel Parkway', N'Anchorage', N'IN-EK', N'76611', N'Argentina', N'955651-1999')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grodudentor International ', N'Pablo Durham', N'Web', N'76 South Nobel Drive', N'Austin', N'OR-VC', N'15820', N'Poland', N'997017-6774')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endglibilicator WorldWide Group', N'Lewis Riggs', N'Service', N'943 Cowley Freeway', N'Richmond', N'SD-MS', N'16496', N'Pitcairn', N'667692-0795')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Upnipedentor  ', N'Annette Ritter', N'Technical', N'787 East Clarendon Way', N'Dallas', N'UT-PT', N'39476', N'Colombia', N'1312197823')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supkilower  Inc', N'Lorena Simmons', N'Sales', N'800 New Blvd.', N'Anchorage', N'CT-NH', N'87200', N'Saint Lucia', N'9864149633')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grosipanax  Corp.', N'Julia Miranda', N'Technical', N'84 Green Fabien Freeway', N'Buffalo', N'HI-UV', N'34650', N'Anguilla', N'211257-5694')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unbanepex Holdings ', N'Kim Cabrera', N'Prepaid Customer', N'862 Green Oak Parkway', N'Santa Ana', N'OH-VO', N'55828', N'Belgium', N'878103-9840')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Hapkilopentor  ', N'Dorothy Campbell', N'Web', N'994 Old Blvd.', N'St. Louis', N'AZ-HO', N'61890', N'Kuwait', N'676563-3042')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwitinommax Holdings ', N'Howard Weiss', N'Accounting', N'70 White Second Blvd.', N'Dallas', N'IA-IW', N'65633', N'Eire', N'719-2762809')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwipickilistor Holdings ', N'Christy Kemp', N'Service', N'74 South Hague Way', N'Anchorage', N'AZ-LQ', N'70033', N'Guam', N'407-7092362')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barrobex International Group', N'Jane Pruitt', N'Service', N'65 West Hague Way', N'San Antonio', N'PA-XW', N'71528', N'Israel', N'160-8938173')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thrubanedor  ', N'Nathaniel Gordon', N'Prepaid Customer', N'62 Hague Street', N'Birmingham', N'NY-OY', N'95693', N'Venezuela', N'764-2236212')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwidimin Holdings ', N'Lewis Bird', N'Web', N'80 West First Way', N'Madison', N'HI-NM', N'61001', N'Benin', N'8136774781')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rerobollower Holdings ', N'Shelly Baldwin', N'Service', N'844 Second Boulevard', N'Birmingham', N'AR-CS', N'58703', N'Guernsey', N'635-595-8341')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rerobplar International ', N'Eric Guerrero', N'Service', N'79 Oak Freeway', N'St. Louis', N'VA-SN', N'99018', N'Tajikistan', N'670-6710878')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwiglibazz  ', N'Joyce Flowers', N'Technical', N'976 Green New Drive', N'Portland', N'TX-BG', N'52144', N'Russia', N'441368-8616')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipkilommentor  Group', N'Claude De Leon', N'Web', N'267 Rocky Milton Way', N'Richmond', N'AZ-LT', N'83310', N'Hungary', N'325-667-8164')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupcadan  ', N'Claire Friedman', N'Accounting', N'56 Green Fabien Freeway', N'Akron', N'AR-SY', N'57147', N'Croatia', N'6263179998')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Zeemunupazz Holdings ', N'Billy Flores', N'Corporate Marketing', N'35 Milton Drive', N'Cincinnati', N'NC-OJ', N'46957', N'Qatar', N'055-835-7715')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Hapfropommax  ', N'Elias Church', N'Technical Marketing', N'32 West Green Nobel Blvd.', N'Mesa', N'NC-FO', N'66703', N'Belize', N'293-695-1499')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barmunazz  ', N'Cynthia Durham', N'Technical', N'46 North Hague Boulevard', N'Virginia Beach', N'NY-IM', N'57763', N'Nauru', N'778264-3656')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Klinipepar  ', N'Tamika Rose', N'Service', N'285 Hague Freeway', N'Seattle', N'AK-MC', N'02632', N'Eire', N'591058-1039')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unpebopin Direct ', N'Salvatore Weber', N'Accounting', N'95 Green Milton Street', N'Los Angeles', N'AK-YS', N'13825', N'Liechtenstein', N'345-093-6539')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopkilazz International Inc', N'Jody Forbes', N'Accounting', N'338 Rocky Milton Blvd.', N'Richmond', N'MN-VM', N'34286', N'Finland', N'039-129-2962')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Updimover  ', N'Julius Cole', N'Technical', N'72 East White Nobel Blvd.', N'Louisville', N'SD-VS', N'09477', N'New Zealand', N'224901-6665')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tippebicower Direct Group', N'Jared Willis', N'Customer', N'73 Green Cowley Street', N'Dayton', N'OH-WM', N'97936', N'New Caledonia', N'419-709-1557')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Zeesipinex  Corp.', N'Leonard Kidd', N'Service', N'265 Rocky Oak Parkway', N'Montgomery', N'TX-VF', N'78404', N'Serbia', N'120316-9247')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Adzapar International Corp.', N'Candice Combs', N'Prepaid Customer', N'38 West Rocky Clarendon Drive', N'St. Paul', N'NC-BZ', N'61414', N'Liberia', N'5630061226')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Retumefistor International Corp.', N'Tonia James', N'Service', N'88 South New Avenue', N'Glendale', N'CT-XZ', N'54117', N'Ghana', N'443-351-3577')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Inkilplicator  ', N'Allison Petty', N'Service', N'976 Hague Blvd.', N'Tulsa', N'WV-FG', N'66055', N'Timor-Leste', N'462-4181633')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwituman  ', N'Mike Raymond', N'Technical', N'49 East Green Clarendon Drive', N'Madison', N'MI-SM', N'63584', N'United States', N'189-490-9407')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tiptumaquin  ', N'Melody Dawson', N'Prepaid Customer', N'87 White Milton Way', N'New York', N'RI-NT', N'77764', N'Mozambique', N'428-491-3585')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winvenefazz  Corp.', N'Courtney Petty', N'Service', N'20 Green Cowley Way', N'Milwaukee', N'AZ-OZ', N'23972', N'Barbados', N'727-4625603')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Haptinazz Direct ', N'Melvin Daniel', N'Web', N'27 Clarendon Avenue', N'Fresno', N'CO-XV', N'78511', N'Honduras', N'0018812782')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopzapex Holdings ', N'Marilyn Sheppard', N'Prepaid Customer', N'595 White First Way', N'Hialeah', N'AL-QM', N'68006', N'Ethiopia', N'8057788980')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipmunentor Direct ', N'Krystal Lopez', N'Technical', N'73 Green Milton Drive', N'St. Paul', N'WY-LH', N'11203', N'Estonia', N'897241-8096')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emjubupower  ', N'Chris Howard', N'Technical', N'73 Cowley Way', N'Jackson', N'NV-PH', N'97694', N'Cook Islands', N'789-512-2223')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Upsipower WorldWide ', N'Latisha Norton', N'Prepaid Customer', N'95 Fabien Street', N'Cleveland', N'AL-NF', N'69949', N'Kazakhstan', N'991202-4943')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Retanackover International ', N'Alfredo Mckee', N'Web', N'960 Rocky New Street', N'Norfolk', N'MN-GJ', N'99448', N'Mauritania', N'772-0947637')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tipkilor  ', N'Donald Boyer', N'Web', N'17 Green Oak Avenue', N'Honolulu', N'CA-RW', N'75111', N'New Zealand', N'017-9936581')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Frojubackentor  ', N'Terry Valencia', N'Web', N'801 Green Hague Boulevard', N'New York', N'AZ-EP', N'47084', N'Mauritius', N'569-5099521')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winbanentor WorldWide ', N'Sarah Bell', N'Accounting', N'58 Green Old Drive', N'Cleveland', N'GA-WP', N'41987', N'Tunisia', N'575-3108430')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Froglibex Holdings ', N'Randal Bentley', N'Accounting', N'738 Hague Blvd.', N'Kansas', N'IL-ZB', N'97494', N'Zambia', N'412-1700207')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Untinommicator WorldWide ', N'Sabrina Gardner', N'Web', N'855 Clarendon Road', N'Memphis', N'WI-GD', N'31861', N'Paraguay', N'4628064620')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Lompebazz WorldWide Group', N'Jerry Orr', N'Corporate Marketing', N'46 Hague Boulevard', N'Arlington', N'UT-YU', N'56352', N'Ecuador', N'069821-8788')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupbanegover  ', N'Amanda Rush', N'Technical', N'70 Hague Parkway', N'Aurora', N'MA-SF', N'97505', N'Slovakia', N'002-113-3436')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supdimilan  ', N'Guy Shannon', N'Accounting', N'973 North Rocky Fabien St.', N'Nashville', N'NE-OO', N'58560', N'Thailand', N'550-3331501')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Zeesipopistor Direct ', N'Whitney Travis', N'Accounting', N'66 North Cowley Road', N'St. Louis', N'IL-TP', N'50195', N'Djibouti', N'127331-9265')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Ciptanonar International Corp.', N'Darcy Mc Mahon', N'Marketing', N'588 Rocky New Road', N'New Orleans', N'FL-KX', N'28098', N'Turkey', N'3842757763')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Raptanegex Direct ', N'Charity Le', N'Service', N'19 New Street', N'Fremont', N'CT-CM', N'77632', N'Myanmar', N'502-177-1471')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Endpebegex  Group', N'Vicki Joyce', N'Prepaid Customer', N'85 South Oak St.', N'Oklahoma', N'CO-BY', N'98908', N'Micronesia', N'0782154627')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Hapcadanover  ', N'Yvonne Leon', N'Accounting', N'172 West Green Old Street', N'Fremont', N'UT-GR', N'98173', N'Belarus', N'6778026113')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Hapzapexan Holdings ', N'Evelyn Stark', N'Service', N'753 New Boulevard', N'Mobile', N'KY-MR', N'67111', N'Swaziland', N'793-0893537')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trutanepax International Inc', N'Kristina Sosa', N'Technical', N'812 South Rocky First Boulevard', N'Fort Worth', N'MS-LW', N'56123', N'Virgin Islands', N'4494619429')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emquestopan International ', N'Dwayne Phillips', N'Web', N'548 North White Second Blvd.', N'Stockton', N'ME-BW', N'89953', N'Turkey', N'1015307782')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Bardudan  Group', N'Efrain Dickerson', N'Prepaid Customer', N'13 Fabien St.', N'Omaha', N'NE-JS', N'02576', N'Serbia', N'274-1141786')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Upbanilor Direct Corp.', N'Matthew Austin', N'Technical', N'65 West Hague Avenue', N'Denver', N'KY-XF', N'74119', N'Czech Republic', N'560-3451411')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipcadover  Inc', N'Tonia Odonnell', N'Technical', N'336 Green Second Way', N'Arlington', N'LA-AA', N'84533', N'Italy', N'679-2929540')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rapnipopover  ', N'Leslie Conway', N'Web', N'164 Clarendon Way', N'Toledo', N'KS-RL', N'85657', N'Malawi', N'744177-8169')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trujubackan  ', N'Eddie Chen', N'Corporate Sales', N'142 South White Milton Road', N'Lincoln', N'FL-IC', N'66552', N'Bolivia', N'703386-5335')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emsipupor Holdings Corp.', N'Peter Wood', N'Web', N'46 Hague Street', N'Corpus Christi', N'AZ-FD', N'03536', N'Ecuador', N'895-601-9083')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Parglibar WorldWide ', N'Kari Ochoa', N'Technical', N'551 East Second Avenue', N'Little Rock', N'AR-DH', N'18093', N'Montenegro', N'132-826-8813')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Trunipplicator International ', N'Juan Sandoval', N'Accounting', N'353 West Green Nobel Road', N'Minneapolis', N'KS-NE', N'83634', N'Cameroon', N'7318546920')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Uptinantor WorldWide ', N'Norman Carpenter', N'Technical', N'599 Milton Way', N'Corpus Christi', N'TN-YU', N'84696', N'Guernsey', N'2931095347')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Zeecadimentor  ', N'Gwendolyn Archer', N'Web', N'24 South Rocky Fabien Blvd.', N'Lubbock', N'NM-PN', N'15481', N'India', N'897592-6859')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Adkilin  Inc', N'Candice Melendez', N'Accounting', N'47 First Parkway', N'San Antonio', N'NH-IZ', N'62121', N'Slovenia', N'996-8437441')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emmunan  ', N'Danny Sparks', N'Accounting', N'63 West New Street', N'Tulsa', N'CA-JZ', N'15742', N'Tanzania', N'517-7163711')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Winpebax  Corp.', N'Rusty Andrade', N'Accounting', N'873 South First St.', N'St. Louis', N'GA-RP', N'99207', N'Poland', N'349-6633573')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Cipnipistor International ', N'Amber Aguirre', N'Prepaid Customer', N'44 Green Nobel Freeway', N'Raleigh', N'NM-VR', N'02267', N'Barbados', N'140412-7265')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupdimex  ', N'Tracie Buckley', N'Corporate Marketing', N'211 First Freeway', N'Richmond', N'CO-QH', N'21682', N'Myanmar', N'132-3598717')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Grosapentor International ', N'Neil Howe', N'Accessory Marketing', N'31 Rocky Fabien St.', N'Wichita', N'ID-XU', N'62602', N'Mauritania', N'243874-2159')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barsapazz  ', N'Johnathan Stuart', N'Accounting', N'698 South Fabien Blvd.', N'Mesa', N'TN-EC', N'46202', N'United Kingdom', N'408035-5548')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Dopvenan Holdings Group', N'Orlando Hooper', N'Technical', N'161 Green Milton St.', N'Phoenix', N'NV-VV', N'04119', N'New Caledonia', N'795-289-4818')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Retumadicator Holdings ', N'Arlene Mercer', N'Technical', N'45 South Fabien Freeway', N'New York', N'FL-NZ', N'41807', N'Barbados', N'199893-9897')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unweropistor WorldWide Inc', N'Caleb David', N'Accounting', N'350 West Green Oak Parkway', N'Mesa', N'NE-BP', N'70439', N'Malaysia', N'3362645059')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Supwerantor WorldWide ', N'Glenn Jacobs', N'Accounting', N'208 Hague Drive', N'San Francisco', N'OH-CI', N'93267', N'Pitcairn', N'116556-8618')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Unsipax  ', N'Shelia Meza', N'Technical', N'199 White Cowley Way', N'Garland', N'VT-OW', N'89605', N'Eritrea', N'481-021-5522')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Tupwerpupan Direct ', N'Gilberto Cherry', N'Web', N'63 Rocky First Blvd.', N'Grand Rapids', N'MD-SK', N'10035', N'Sierra Leone', N'733-7237626')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rewerpepor  Group', N'Jeanette Wheeler', N'Technical', N'849 Cowley Blvd.', N'Shreveport', N'ND-HZ', N'61283', N'Argentina', N'655-791-8032')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Thrupickax  Corp.', N'Benjamin Merritt', N'Accounting', N'872 North Rocky Fabien Street', N'Lubbock', N'FL-DG', N'35573', N'Spain', N'0344271522')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rapsipower International Company', N'Jim Fisher', N'Service', N'71 White Hague Street', N'Corpus Christi', N'KS-LI', N'60621', N'Russia', N'495098-8205')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Untinicator  ', N'Gary Marshall', N'Web', N'20 South Old Street', N'Santa Ana', N'FL-LU', N'64623', N'Mauritania', N'781416-3886')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Qwiwerefin WorldWide ', N'Sonja Little', N'Web', N'81 West Rocky Second Parkway', N'Tucson', N'MN-EW', N'13579', N'Mexico', N'268-947-1445')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Rapdimantor Holdings Company', N'Taryn Hendricks', N'Technical', N'58 Green Second St.', N'Tacoma', N'FL-PC', N'93417', N'Paraguay', N'211-335-2343')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Barerantor  ', N'Lesley Walter', N'Service', N'487 White Fabien St.', N'Jacksonville', N'MT-XX', N'80002', N'Germany', N'102-136-2174')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Doptumopor  ', N'Hannah Mc Daniel', N'Service', N'65 White Nobel Boulevard', N'Yonkers', N'IN-SH', N'41544', N'Swaziland', N'971-1638180')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Monfropollan Direct ', N'Herman Reed', N'Service', N'460 Nobel Freeway', N'El Paso', N'GA-EV', N'48916', N'Rwanda', N'5040229501')
GO
INSERT [dbo].[Customers] ( [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone]) VALUES ( N'Emvenistor International ', N'Steven Velasquez', N'Accounting', N'90 White Oak Boulevard', N'Dayton', N'MT-VZ', N'64827', N'Benin', N'261-419-5645')


