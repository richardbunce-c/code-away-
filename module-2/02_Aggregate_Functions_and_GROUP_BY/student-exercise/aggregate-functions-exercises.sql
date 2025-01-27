﻿-- The following queries utilize the "world" database.
-- Write queries for the following problems. 
-- Notes:
--   GNP is expressed in units of one million US Dollars
--   The value immediately after the problem statement is the expected number 
--   of rows that should be returned by the query.

-- 1. The name and state plus population of all cities in states that border Ohio 
-- (i.e. cities located in Pennsylvania, West Virginia, Kentucky, Indiana, and 
-- Michigan).  
-- The name and state should be returned as a single column called 
-- name_and_state and should contain values such as ‘Detroit, Michigan’.  
-- The results should be ordered alphabetically by state name and then by city 
-- name. 
-- (19 rows)
Select (Name + ', ' + District) name_and_state
From city
Where district in ('Pennsylvania', 'West Virginia', 'Kentucky', 'Indiana', 'Michigan')
Order By District, Name


-- 2. The name, country code, and region of all countries in Africa.  The name and
-- country code should be returned as a single column named country_and_code 
-- and should contain values such as ‘Angola (AGO)’ 
-- (58 rows)
Select (name + ', ' + code) country_and_code, region
From country
Where continent = 'Africa' 



-- 3. The per capita GNP (i.e. GNP multipled by 1000000 then divided by population) of all countries in the 
-- world sorted from highest to lowest. Recall: GNP is express in units of one million US Dollars 
-- (highest per capita GNP in world: 37459.26)
Select ((GNP * 1000000) / (Population+.0001)) as 'highest per capita GNP in world'
From Country
Order By 'highest per capita GNP in world' desc


-- 4. The average life expectancy of countries in South America.
-- (average life expectancy in South America: 70.9461)
Select avg(LifeExpectancy) as 'average life expectancy in South America'
From Country
Where Continent = 'South America'

-- 5. The sum of the population of all cities in California.
-- (total population of all cities in California: 16716706)
Select sum(Population) as 'total population of all cities in California'
From City
Where District ='California'

-- 6. The sum of the population of all cities in China.
-- (total population of all cities in China: 175953614)
Select sum(Population) as 'total population of all cities in China'
From City
Where CountryCode = 'CHN'

-- 7. The maximum population of all countries in the world.
-- (largest country population in world: 1277558000)
Select max(Population) as 'largest country population in world'
From Country

-- 8. The maximum population of all cities in the world.
-- (largest city population in world: 10500000)
Select max(Population) as 'largest city population in world'
From City


-- 9. The maximum population of all cities in Australia.
-- (largest city population in Australia: 3276207)
Select max(Population) as 'largest city population in Australia'
From City
Where CountryCode = 'AUS'


-- 10. The minimum population of all countries in the world.
-- (smallest_country_population in world: 50)
Select min(Population) as 'smallest_country_population in world'
From Country
--Should be zero here?
Where Population>0
--Only way I could get 50

-- 11. The average population of cities in the United States.
-- (avgerage city population in USA: 286955.3795)                       --Spelling mistake on "Average"
Select avg(Cast (Population as float)) as 'average city population in USA'
From City
Where CountryCode = 'USA'
--Don't know why I'm not returning a decimal.


-- 12. The average population of cities in China.
-- (average city population in China: 484720.6997 approx.)
Select avg(Cast (Population as float)) as 'average city population in China'
From City
Where CountryCode = 'CHN'


-- 13. The surface area of each continent ordered from highest to lowest.
-- (largest continental surface area: 31881000, "Asia")
Select sum(SurfaceArea) as 'largest continental surface area', Continent
From Country
Group By Continent
Order By [largest continental surface area] desc


-- 14. The highest population density (population divided by surface area) of all 
-- countries in the world. 
-- (highest population density in world: 26277.7777)
Select max(Population/SurfaceArea) as 'highest population density in world'
From Country


-- 15. The population density and life expectancy of the top ten countries with the 
-- highest life expectancies in descending order. 
-- (highest life expectancies in world: 83.5, 166.6666, "Andorra")
Select Top 10 LifeExpectancy as 'highest life expectancies in world', max(Population/SurfaceArea) as 'population density', Name
From Country
Group By LifeExpectancy, Name
Order By LifeExpectancy desc

-- 16. The difference between the previous and current GNP of all the countries in 
-- the world ordered by the absolute value of the difference. Display both 
-- difference and absolute difference.
-- (smallest difference: 1.00, 1.00, "Ecuador")
Select (GNP-GNPOld)as 'difference', abs(GNP-GNPOld)as 'absolute difference', Name
From Country
Where GNP is not null and GNPOld is not null
Group By Name, GNP, GNPOld
Order by 'absolute difference'

-- 17. The average population of cities in each country (hint: use city.countrycode)
-- ordered from highest to lowest.
-- (highest avg population: 4017733.0000, "SGP")
Select avg(Population) as 'highest avg population', CountryCode
From City
Group by CountryCode
Order by 'highest avg population' desc


	
-- 18. The count of cities in each state in the USA, ordered by state name.
-- (45 rows)
Select count(district) as 'count of cities', district 
From City 
Where CountryCode = 'USA'
Group By District
Order By District


-- 19. The count of countries on each continent, ordered from highest to lowest.
-- (highest count: 58, "Africa")
	Select count(Name) as 'highest count', Continent
	From Country
	Group By Continent
	Order By count(Name) desc

-- 20. The count of cities in each country ordered from highest to lowest.
-- (largest number of  cities ib a country: 363, "CHN")                                   --Spelling Error "ib"
Select count(Name) as 'largest number of cities in a country', CountryCode
From City
Group By CountryCode
Order By count(Name) desc


	
-- 21. The population of the largest city in each country ordered from highest to 
-- lowest.
-- (largest city population in world: 10500000, "IND")
Select max(Population) as 'largest city population in world', CountryCode 
From City
Group By CountryCode
Order By max(Population) desc


-- 22. The average, minimum, and maximum non-null life expectancy of each continent 
-- ordered from lowest to highest average life expectancy. 
-- (lowest average life expectancy: 52.5719, 37.2, 76.8, "Africa")
Select avg(LifeExpectancy), min(LifeExpectancy) as 'lowest average life expectancy', max(LifeExpectancy) as 'highest average life expectancy', Continent
From Country
Where LifeExpectancy is not null
Group By Continent
Order By avg(LifeExpectancy)