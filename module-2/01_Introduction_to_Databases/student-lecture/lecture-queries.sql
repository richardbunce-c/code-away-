-- SELECT ... FROM
-- Selecting the names for all countries
Select Name from Country

-- Selecting the name and population of all countries
Select Name, Population
From Country

-- Selecting all columns from the city table
Select * 
from City

-- SELECT ... FROM ... WHERE
-- Selecting the cities in Ohio
Select * 
From City
Where District ='Ohio'

-- Selecting countries that gained independence in the year 1776
Select *
From Country
Where IndepYear=1776

-- Selecting countries not in Asia
Select *
From Country
Where Continent != 'Asia'

-- Selecting countries that do not have an independence year
Select *
From Country
Where IndepYear is null
-- Selecting countries that do have an independence year
Select *
From Country
Where IndepYear is not null

-- Selecting countries that have a population greater than 5 million
Select *
From Country
Where Population>5000000


-- SELECT ... FROM ... WHERE ... AND/OR
-- Selecting cities in Ohio and Population greater than 400,000
Select *
From City
Where District = 'Ohio' And Population>400000

-- Selecting country names on the continent North America or South America
Select Name, Continent	
From Country 
Where  Continent = 'North America' or Continent= 'South America'

-- Same thing but using IN
Select Name, Continent
From Country
Where Continent IN ('North America', 'South America')

--Same thing using LIKE
Select Name, Continent
From Country
Where Continent LIKE '%America'

-- SELECTING DATA w/arithmetic
-- Selecting the population, life expectancy, and population per area
--	note the use of the 'as' keyword

Select Name as 'Where are all my peeps at?', population as 'how many peeps total', LifeExpectancy as 'You are gonna die by the age of...', Population/SurfaceArea as 'Peeps per area'
From Country

