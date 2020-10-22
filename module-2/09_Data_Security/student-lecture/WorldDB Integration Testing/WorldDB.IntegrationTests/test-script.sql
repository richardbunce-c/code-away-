-- Delete all of the data
DELETE FROM countrylanguage;
DELETE From Language;
UPDATE country SET capital = NULL;
DELETE FROM city;
DELETE FROM country;

-- Insert a fake country
INSERT INTO country (Code, Name, Continent, Region, SurfaceArea, IndepYear, Population, 
    LifeExpectancy, GNP, GNPOld, LocalName, GovernmentForm, HeadOfState, Capital, Code2)
    VALUES ('USA', 'United States of America', 'North America', 'Region', 100, null, 100, 
    null, null, null, 'United States of America', 'Government', 'Leader', null, 'US');

-- Insert a fake city
INSERT INTO city (Name, CountryCode, District, Population)
    VALUES ('Joshville', 'USA', 'Iowa', 1);
DECLARE @newCityId int = (SELECT @@IDENTITY);

-- Insert a fake Language
Insert Language (LanguageName) Values ('Zulu');
Declare @newLanguageId int = (Select @@Identity)

-- Insert a fake country language
INSERT INTO countrylanguage (CountryCode, LanguageId, IsOfficial, Percentage)
 VALUES ('USA', @newLanguageId, 1, 100);

-- Assign the fake city to be the capital of the fake country
UPDATE country SET capital = @newCityId;

-- Return the id of the fake city
SELECT @newCityId as newCityId;