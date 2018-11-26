/****** Script for SelectTopNRows command from SSMS  ******/

-- 01: Custmer base migration
/*
  SET IDENTITY_INSERT [CRM].[Customer] ON

  insert into [CRM].[Customer](Id, [Name]) 
  select ID, Customer from [RIVERDALE_MAINAPP LEGACY].[intranet.dev].[dbo].[Customers]

  SET IDENTITY_INSERT [CRM].[Customer] OFF

  insert into [CRM].[CustomerThridParty]

  */


  --02 Customer ThirdParty ids
  /*
   insert into [CRM].[CustomerThirdPartyAppSetting]([CustomerId], ThirdPartyAppTypeId, ThirdPartyCustomerId) 


  select ID , case when ThirdParty = 'ERPCode' then 'BISERP' else 'SFORCE' end as ThirdPartyAppTypeId, ThirdPartyId as CustomerThirdPartyAppId 
  from (select ID, CONVERT(varchar(20), ERPCode) as ERPCode, CONVERT(varchar(20), SalesforceId) as SalesforceId FROM [RIVERDALE_MAINAPP LEGACY].[intranet.dev].[dbo].[Customers] ) cus
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
  from [RIVERDALE_MAINAPP LEGACY].[intranet.dev].[dbo].[ColorCatalog] 
  

	*/


