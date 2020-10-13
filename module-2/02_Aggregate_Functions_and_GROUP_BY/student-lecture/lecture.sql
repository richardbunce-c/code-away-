-- ORDERING RESULTS

-- Populations of all countries in descending order
Select Name, Population 
From Country
Order By Population desc
--Names of countries and continents in ascending order
Select Name, Continent
From Country
Order By Continent, Name 
-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
Select Top 10 Name, LifeExpectancy
From Country
Order By LifeExpectancy desc, Name
-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
Select Name+',' + District as CityState
From City
Where District  ='California' or district='Oregon' or district= 'Washington'
Order By District, Name
-- Can you do it another way?
Select Concat( Name, ',' , District) as CityState
From City
Where District  in ('California', 'Oregon', 'Washington')
Order By District, Name

-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
Select avg (LifeExpectancy)
From Country


-- Total population in Ohio
select sum(population)
From City 
where countrycode = 'USA' and district = 'Ohio'

-- The surface area of the smallest country in the world
Select min(SurfaceArea) as Minimum, Avg(SurfaceArea)as average, max(SurfaceArea)as largest
From Country
--Or
Select top 1 Name, SurfaceArea
From Country
Order By SurfaceArea 

-- The 10 largest countries in the world
select Top 10 Name, SurfaceArea
From Country
Order by SurfaceArea desc
-- The number of countries who declared independence in 1991
Select Count (*)
From Country
Where indepyear=1991

-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least

-- Average life expectancy of each continent ordered from highest to lowest
Select Continent, Avg(LifeExpectancy)as 'AvgLifeExpectancy'
From Country
Group By Continent 
--Order By AvgLifeExpectancy desc
Order By 2 desc

-- Exclude Antarctica from consideration for average life expectancy
Select Continent, Avg(LifeExpectancy) as 'AvgLifeExpectancy'
From Country
Where Continent<> 'Antarctica'  --Or LifeExpectancy is not null
Group By Continent
Order by AvgLifeExpectancy

-- Sum of the population of cities in each state in the USA ordered by state name
Select District, sum(population) as TotalPopulation, avg(population) as AvgPopulation, Count(*) as NumberOfCities
From City
Where CountryCode = 'USA'
Group by District
Order By District

-- The average population of cities in each state in the USA ordered by state name
Select District, avg(population) as 'avgPopulation'
From City
Where CountryCode = 'USA'
Group By District
Order By district 


-- SUBQUERIES
-- Find the names of cities under a the Head of State 'George W. Bush'


--The Manual Way...
--First, find all the countries that GW heads
Select Name
from Country
where HeadOfState = 'George W. Bush'

--Find the names of the cities in the above countries
Select *
From City
Where CountryCode in ('USA', 'ASM', 'GUM', 'MNP', 'PRI', 'UMI', 'VIR')

--Put the two above queries together into a "Query - SubQuery"
Select *
From City
Where CountryCode in(Select Code
from Country
where HeadOfState = 'George W. Bush')


-- Find the names of cities whose country they belong to has not declared independence yet
Select *
From City
Where CountryCode in (Select Code from Country where IndepYear is null)


-- Select those countries with lower than average life expectancy
Select *
From Country
Where LifeExpectancy<(Select Avg(LifeExpectancy) from Country)


-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
