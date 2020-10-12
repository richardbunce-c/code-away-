-- The name and population of all cities in the USA with a population of greater than 1 million people
Select Name, Population
	From City
	Where Population > 1000000 And CountryCode = 'USA'
	

-- The name and population of all cities in China with a population of greater than 1 million people
Select Name, Population
	From City
	Where Population > 1000000 And CountryCode = 'CHN'

-- The name and region of all countries in North or South America
 Select Name, Region
	From Country
	Where Continent IN ('North America', 'South America')

-- The name, continent, and head of state of all countries whose form of government is a monarchy
Select Name, Continent, HeadOfState
	From Country
	Where GovernmentForm LIKE '%Monarchy%'

	-- What government forms are in the table?
	Select Distinct GovernmentForm
		From Country

-- The name, country code, and population of all cities with a population less than one thousand people
Select Name, CountryCode, Population 
	From City
	Where population < 1000


-- The name and region of all countries in North or South America except for countries in the Caribbean
Select Name, Region
	From Country
	Where Continent IN ('North America', 'South America')
		AND Region <> 'Caribbean'

Select Name, Region
	From Country
	Where (Continent = 'North America' OR Continent = 'South America')
		AND Region <> 'Caribbean'

-- The name, population, and GNP of all countries with a GNP greater than $1 trillion dollars and a population of less than 1 billion people

-- The name and population of all cities in Texas that have a population of greater than 1 million people

-- The name and average life expectancy of all countries in southern regions

-- The name and average life expectancy of all countries in southern regions for which an average life expectancy has been provided (i.e. not equal to null)

-- The name, continent, GNP, and average life expectancy of all countries in Africa or Asia that have an average life expectancy of at least 70 years and a GNP between $1 million and $100 million dollars
