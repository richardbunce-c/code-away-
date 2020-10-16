-- INSERT
-- 1. Add a city to the City table, district 'Ohio'
Insert into City ( Name, CountryCode, District, Population)
Values ( 'Strongsville', 'USA', 'Ohio', 50000)


-- 1a. What is the @@Identity?
Select max(CityId) from City
Select top 1 * from City order by CityId desc

-- 2. Add 2 more cities to Ohio using one insert statement
Insert into City (Name, CountryCode, District, Population)
Values ('Solon', 'USA', 'Ohio', 60000),
       ('Mentor', 'USA', 'Ohio', 55000)

-- 2a. What is the @@Identity?
Select @@IDENTITY

-- 0. Add Klingon to the Language table
Insert into Language(LanguageName)
Values ('Klingon')

-- 0a. What is the @@Identity?
Select @@IDENTITY  --458

-- 1. Add Klingon as a spoken language in the USA
Insert CountryLanguage (CountryCode, LanguageId, IsOfficial, Percentage)
                 values('USA', 458, 0, 0.05)
-- 2. Add Klingon as a spoken language in Great Britain


-- UPDATE

-- 0. Update the population of Cleveland to 2020 values (379,233)
Update City 
Set Population=379233
Where Name='Cleveland' and District = 'Ohio'

-- 1. Update the capital of the USA to Houston
--Find Id of Houston
Select CityId from city where name='Houston' and district='Texas'
--Update the USA row to reference the city id of Houston
Update Country
set Capital=3796
where Code='USA' 

--Do the same thing using a subquery
Update Country
set Capital=(Select CityId from city where name ='Houston' and district = 'Texas')
where Code='USA' 

select * from country where code = 'USA'

-- 2. Update the capital of the USA to Washington DC and the head of state
Update Country
set capital=(Select CityId from city where name ='Washington' and District = 'District of Columbia'),
HeadOfState='Donald',
Population=300000000
where code ='USA'
-- DELETE

-- 0. Delete the newly added Ohio cities
Delete from City
--Select * from City
	where name in('Strongsville', 'Solon', 'Mentor')

-- 1. Delete English as a spoken language in the USA
Delete CountryLanguage 
where CountryCode='USA' and LanguageId=(select LanguageId from language where LanguageName ='English')

-- 2. Delete all occurrences of the Klingon language 
Delete from CountryLanguage
where LanguageId=(Select LanguageId from Language where LanguageName= 'Klingon')
Delete Language
Where LanguageName='Klingon'

-- REFERENTIAL INTEGRITY



Insert into City ( Name, CountryCode, District, Population)
Values ( 'Strongsville', 'ZZZ', 'Ohio', 50000)


-- 1. Try just adding Elvish to the country language table.

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

-- 3. Try deleting the country USA. What happens?
Delete Country
where code='USA'

-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
Insert CountryLanguage(CountryCode, LanguageId, IsOfficial, Percentage)
	Values('USA', 111, 0, 89.0)

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'
update country
set Continent = 'Atlantis'
where code ='USA'

-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.

-- 2. Try updating all of the cities to be in the USA and roll it back

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.