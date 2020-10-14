-- List the "city name, country name" and city population, sorted by country and city population descending

-- List the city name, country name and the percentage of the country's population in the city

-- List the country name and its languages

-- List the country name and its official language

-- List the countries and their capital cities

-- Let's display a list of all countries and their capitals, if they have some.
-- Where are the other 7 rows?

-- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

-- ********* LEFT JOIN ***********
-- A Left join selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.


-- List the countries and their capital cities, but make sure the country is listed even if it has no capital




-- (go play in the dvd store for a while...)



------------------------- More JOINs and UNION -------------------------------------

-- List the cities which are not capitals


-- Can we do this another way?


-- List the city and the country it's a capital of


-- *********** UNION *************

-- How does the population of the largest cities compare with entire countries?
-- Get the name, population, and whether it is a city or a country, order by population descending



-- ***** What if I want to list every city, alongside the capital city for the country this city is in?
 
-- List the city, its country, and the capital city for that country.
SELECT c.name 'City', ctry.name 'Country', cc.name 'Capital City',
	CASE WHEN c.cityid = cc.cityid THEN '***' ELSE '' END AS 'Capital'
FROM city c
	JOIN country ctry ON c.countrycode = ctry.code
	LEFT JOIN city cc ON ctry.capital = cc.cityid
ORDER BY ctry.name, c.name

-- ******** SELF-JOIN ***************
-- An Example of joining a table to itself, AND
-- An Example of joining to columns other than the PK

-- List each US city along with the other cities in that state.
SELECT c.name 'City', c.district 'State', other.name 'Other city'
	FROM city c
	LEFT JOIN city other ON c.district = other.district 
						AND c.countrycode = other.countrycode 
						AND c.cityid <> other.cityid 
						AND c.name < other.name
	WHERE c.countrycode = 'USA'
	ORDER BY c.district, c.name, other.name
