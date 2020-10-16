-- City: Contains all cities in US with > 100,000 people
-- State: Contains the list of US states
-- BTW, 6 states have no cities with > 100K people


-- Give me a list of states, with a count of the number of "large" cities

-- Create the state table
Drop table if exists USState

Create Table USState (
	StateId int not null primary key identity,
	Name nvarchar(64) not null Unique
)

-- Populate the state table from the Country table
Begin Transaction
Insert USState (Name) 
	Select distinct District from City where CountryCode = 'USA'

Insert USState (Name) 
Values 
	('Delaware'),
	('Maine'),
	('North Dakota'),
	('Vermont'),
	('West Virginia'),
	('Wyoming')
Commit Transaction

Drop Table if exists USCity

Create table USCity(
	CityId int not null primary key,
	Name nvarchar(64) not null,
	StateId int not null,
	Population int not null
)

Insert USCity(CityId, Name, StateId, Population)
	Select c.CityId, c.Name, s.StateId, c.Population
		From City c 
		Join USState s on c.District = s.Name
		Where c.CountryCode = 'USA'
