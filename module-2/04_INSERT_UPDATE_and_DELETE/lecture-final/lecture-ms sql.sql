-- INSERT
-- 1. Add a city to the City table, district 'Ohio'
Insert into City (Name, CountryCode, District, Population)
	Values('Strongsville', 'USA', 'Ohio', 50000)

-- 1a. What is the @@Identity?
Select Max(CityId) from City
Select top 1 * from City order by CityId desc


-- 2. Add 2 more cities to Ohio using one insert statement
Insert into City (Name, CountryCode, District, Population)
	Values('Solon', 'USA', 'Ohio', 60000),
		('Mentor', 'USA', 'Ohio', 55000)

-- 2a. What is the @@Identity?
Select @@IDENTITY


-- 0. Add Klingon to the Language table
	Insert into Language (LanguageName)
	Values ('Klingon')

-- 0a. What is the @@Identity?
select  @@identity -- 458

-- 1. Add Klingon as a spoken language in the USA
Insert CountryLanguage (CountryCode, LanguageId, IsOfficial, Percentage)
	values ('USA', 458, 0, 0.05)

-- 2. Add Klingon as a spoken language in Great Britain


-- UPDATE

-- 0. Update the population of Cleveland to 2020 values (379,233)
Update City
	Set Population = 379233
	Where Name = 'Cleveland' and District = 'Ohio'


-- 1. Update the capital of the USA to Houston
	-- Find the id of Houston
	Select CityId from City where name = 'Houston' and District = 'Texas'
	Select CityId from City where name = 'Washington' and District = 'District of Columbia'

	-- Update the USA row to reference the city id of Houston
	Update Country
		set Capital = 3813
		where Code = 'USA'

	-- Do the same thing using a subquery
	Update Country 
		set Capital = (Select CityId from City where name = 'Houston' and District = 'Texas')
		where Code = 'USA'

	select * from country where code = 'USA'


-- 2. Update the capital of the USA to Washington DC and the head of state
	Update Country 
		set Capital = (Select CityId from City where name = 'Washington' and District = 'District of Columbia'),
			HeadOfState = 'Donald',
			Population = 300000000
		where Code = 'USA'


-- DELETE

-- 0. Delete the newly added Ohio cities
	Delete From City 
	Where name in ('Strongsville', 'Solon', 'Mentor') 

-- 1. Delete English as a spoken language in the USA
	Delete CountryLanguage	
	Where CountryCode = 'USA' And
		LanguageId = ( Select languageId from Language where LanguageName = 'English' )

-- 2. Delete all occurrences of the Klingon language 
	Delete from CountryLanguage 
		Where LanguageId = (Select LanguageId from Language where LanguageName = 'Klingon')
   Delete Language
	Where LanguageName = 'Klingon'

-- REFERENTIAL INTEGRITY

-- 1. Add a city to the City table in the country 'ZZZ'
Insert into City (Name, CountryCode, District, Population)
	Values('Strongsville', 'ZZZ', 'Ohio', 50000)

-- 1. Try just adding Elvish to the country language table.

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

-- 3. Try deleting the country USA. What happens?
Delete Country 
	Where code = 'USA'



-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
Insert CountryLanguage (CountryCode, LanguageId, IsOfficial, Percentage)
	Values('USA', 111, 0, 89.0)


-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'
Update Country
	Set Continent = 'Atlantis'
Where Code = 'USA'


-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
Begin Transaction
	Select * from CountryLanguage
	Delete from CountryLanguage
	Select * from CountryLanguage
Rollback tran

Select * from CountryLanguage




-- 2. Try updating all of the cities to be in the USA and roll it back
Begin Tran
	Update City 
		Set CountryCode = 'USA'
	Select * from city
Commit tran

	Select * from city


-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.


-- LATER: Insert a row to add a single language to all countries

Select * from Language
Insert into Language (LanguageName) values ('Latin')
Select  @@IDENTITY

Insert into CountryLanguage (CountryCode, LanguageId, IsOfficial, Percentage)
	Select Code, 459, 0, 0.01
		From Country



-- Tell me who speaks Latin (459)
Select *
	From Country c
	join CountryLanguage cl on c.Code = cl.CountryCode
	Where cl.LanguageId = 459