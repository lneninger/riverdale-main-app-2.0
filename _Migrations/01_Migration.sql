/****** Script for SelectTopNRows command from SSMS  ******/

-- 01: Custmer base migration
/*
  --SET IDENTITY_INSERT [CRM].[Customer] ON

  insert into [CRM].[Company]([CompanyTypeId], [Name], [OLD_CustomerId]) 
  select 'CUS', Customer, ID from [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[Customers]

  --SET IDENTITY_INSERT [CRM].[Customer] OFF

  --insert into [CRM].[CustomerThridParty]

  */


  --02 Customer ThirdParty ids
  /*
   insert into [CRM].[CustomerThirdPartyAppSetting]([CustomerId], ThirdPartyAppTypeId, ThirdPartyCustomerId) 


  select ID , case when ThirdParty = 'ERPCode' then 'BISERP' else 'SFORCE' end as ThirdPartyAppTypeId, ThirdPartyId as CustomerThirdPartyAppId 
  from (select ID, CONVERT(varchar(20), ERPCode) as ERPCode, CONVERT(varchar(20), SalesforceId) as SalesforceId FROM [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[Customers] ) cus
  UNPIVOT  
   (ThirdPartyId FOR ThirdParty IN   
      (ERPCode, SalesforceId)  
	)AS ThirdPartyTable;  

	*/


	--03 Product Colors
  /*
  USE Riverdale
  GO
   insert into [CNF].[ProductColorType](Id, Name, HexCode, IsBasicColor) 

  select ColorCode, ColorDesc, HtmlCode, IsBasic 
  from [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[ColorCatalog] 
  

	*/


		--04 Customer Freightout
  /*
  USE Riverdale
  GO
   insert into [QUOTE].[CustomerFreightout](CustomerId, CustomerFreightoutRateTypeId, Cost, WProtect, SecondLeg, SurchargeHourly, SurchargeYearly, DateFrom, DateTo) 

  select t2.Id, (case when t1.RateType =1 then 'CUBE' ELSE 'BOX' end) CustomerFreightoutRateTypeId, t1.Cost, t1.WProtect, t1.SecondLeg, HSurch, YRSurch, DateFrom, DateTo
  from [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[Delivered] t1
  inner join CRM.Company t2 on t1.Name = t2.Name and t2.CompanyTypeId = 'CUS'

	*/


		--05 Season Categories
  /*
  USE Riverdale
  GO
  SET IDENTITY_INSERT [OPP].[SaleSeasonType] ON

   insert into [OPP].[SaleSeasonType](Id, Name, Description, CreatedAt, CreatedBy, SaleSeasonCategoryTypeId) 

  select ID, Season, '', GETUTCDATE(), 'Seed', (CASE CategoryID WHEN  1 THEN 'EVERYDAY' WHEN 2 THEN 'HOLIDAY' ELSE 'YEARROUND' END) as category
  from [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[Seasons] t1
  
  SET IDENTITY_INSERT [OPP].[SaleSeasonType] OFF

	*/


--06 Location(Origin)
  /*
  USE Riverdale
  GO
  SET IDENTITY_INSERT [CNF].[Location] ON

  --Alpha2Code	Alpha3Code		Name
	--CO			COL			Colombia
	--CR			CRI			Costa Rica
	--EC			ECU			Ecuador
	--US			USA			United States of America

   insert into [CNF].[Location](Id, City, CountryId) 

  select  ID, UPPER(Name), (
  COALESCE((CASE  
  WHEN Name = 'BOGOTA' THEN 170 
  WHEN Name = 'MEDELLIN' THEN 170 
  WHEN Name = 'QUITO' THEN 218 
  WHEN Name = 'LIMA' THEN 604 
  WHEN Name = 'MIAMI' THEN 840 
  WHEN Name = 'ROME' THEN 380 
  WHEN Name = 'AMSTERDAM' THEN 528 
  ELSE NULL END),
  (CASE
  WHEN Name = 'BUENOS AIRES' THEN 188 
  WHEN Name = 'SAN JOSE' THEN 188 
  WHEN Name = 'GUATEMALA' THEN 320 
  WHEN Name = 'SANTO DOMINGO' THEN 214
  WHEN Name = 'CALIFORNIA' THEN 840
  WHEN Name = 'OREGON' THEN 840
  ELSE NULL END)
  )
  ) as countryId
  from [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[Origins] t1
  where Name not like 'do not use'

  SET IDENTITY_INSERT [CNF].[Location] OFF

	*/



	--07 Grower
  /*
  USE Riverdale
  GO
  --SET IDENTITY_INSERT [CRM].[Grower] ON
  insert into [CRM].[Company](CompanyTypeId, Name, Code, OriginId, GrowerTypeId, OLD_GrowerId)
  select  --*, 
  'GWR'
  , Name
  , Short
  , (select TOP 1 Id from [CNF].Location where City=t1.Orig)  as OriginId
  , (CASE 
	WHEN Name Like '%Funza%' AND Orig = 'BOGOTA' THEN 'FUNZABTA'
	ELSE 'THIRD'
	END) as  GrowerTypeId
  , ID
  from [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[Growers] t1
  where LEN(Short) = 2 and Name not like '%test%'
  
  --SET IDENTITY_INSERT [CRM].[Grower] OFF

  */

  --08
  /*
insert into [CRM].[CustomerSettings](CustomerId, DefaultIsDeliver, DefaultIsWet, DefaultDuty, DefaultOther, DefaultRebate)
select t1.Id, COALESCE(t2.Deliver, 0), COALESCE(t2.Wet, 0), t2.Duty, t2.Other, t2.Rebate--, t2.* 
from [riverdale].[CRM].[Company] t1
inner join [RIVERDALEMAINAPP LEGACY].[intranet.dev].[dbo].[Customers] t2 on t1.Name=t2.Customer
where CompanyTypeId = 'CUS'
  
  */