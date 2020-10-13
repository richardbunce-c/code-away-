-- ORDERING RESULTS

-- Populations of all countries in descending order
Select Name, Population
From Country
Order By Population Desc

--Names of countries and continents in ascending order
Select Name, Continent
From Country
order by Continent, Name

-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
Select Top 10 Name, LifeExpectancy
From Country
Order by LifeExpectancy desc


-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
Select Name + ', ' + District As CityState
From City
Where District = 'California' OR District = 'Oregon' OR District = 'Washington'
Order By District, Name

-- Can you do it another way?
Select CONCAT(Name, ', ', District) As CityState
From City
Where District IN ('California', 'Oregon', 'Washington')
Order By District, Name


-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
Select Avg(LifeExpectancy)
From Country

-- Total population of all cities in Ohio
Select Sum(Population)
From City
Where CountryCode = 'USA' And District = 'Ohio'

-- The surface area of the smallest country in the world
Select Min(SurfaceArea) As Minimum, Avg(SurfaceArea) As Average, Max(SurfaceArea) As Maximum
From Country

-- OR --
Select Top 1 Name, SurfaceArea
From Country
Order By SurfaceArea asc

-- The 10 largest countries in the world
Select Top 10 Name, SurfaceArea
From Country
Order By SurfaceArea desc


-- The number of countries who declared independence in 1991
Select Count(*)
From Country
Where IndepYear = 1991


-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least

-- Average life expectancy of each continent ordered from highest to lowest
Select Continent, Avg(LifeExpectancy) As AvgLifeExpectancy
From Country
Group By Continent
Order By AvgLifeExpectancy Desc

-- Exclude Antarctica from consideration for average life expectancy
Select Continent, Avg(LifeExpectancy) As AvgLifeExpectancy
From Country
Where LifeExpectancy is not null
Group By Continent
--Having Avg(LifeExpectancy) Is not Null
Order By AvgLifeExpectancy Desc

-- Sum of the population of cities in each state in the USA ordered by state name
Select District, Sum(Population) As TotalPopulation, Avg(Population) As AveragePopulation, Count(*) As NumberOfCities
From City
Where CountryCode = 'USA'
Group By District
Order By District

-- The average population of cities in each state in the USA ordered by state name
-- (see above query)

-- SUBQUERIES
-- Find the names of cities under the Head of State 'George W. Bush'

-- THE MANUAL WAY...
-- First, find all of the countries that GW heads
Select Code
From Country 
Where HeadOfState = 'George W. Bush'

-- Find the names of the cites in the above countries
Select *
From City 
Where CountryCode IN('USA', 'ASM', 'GUM', 'MNP', 'PRI', 'UMI', 'VIR')

-- Put the two above queries together into a "Query - subquery"
Select *
From City 
Where CountryCode IN(
	Select Code
		From Country 
		Where HeadOfState = 'George W. Bush')
Order By Name


-- Find the names of cities whose country they belong to has not declared independence yet

	-- Find the countries who are not independent
	--Select * from Country where IndepYear is null

	Select * 
		From City
		Where CountryCode in (Select Code from Country where IndepYear is null)

-- Select those countries with lower than average life expectancy
Select Avg(LifeExpectancy) From Country

Select * 
	from Country
	Where LifeExpectancy < 66.4860361116426

Select * 
	from Country 
	Where LifeExpectancy < (Select Avg(LifeExpectancy) From Country)



-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)
Select * from city where name = 'Arlington'


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
