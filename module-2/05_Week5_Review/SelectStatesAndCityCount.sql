-- List the us states
Select * from usstate

-- List the US Cities
Select * from USCity

-- List the US States, along with each of their "large" cities
--State	City
------	-----
--Ohio	Cleveland
--Ohio	Columbus

Select s.Name State, c.Name City
	From USState s 
	Join USCity c on c.StateId = s.StateId
	Order By State, City

-- Are there some rows missing?  How do we make sure all states are listed
Select s.Name State, c.Name City
	From USState s 
	Left Outer Join USCity c on c.StateId = s.StateId
	Order By State, City


-- List the states and how many "large" cities the state contains

Select s.Name, Count(*)
	From USState s
	Join USCity c on s.StateId = c.StateId
	Group By s.Name
	Order By s.Name

-- What's wrong with this picture?
Select s.Name, Count(c.CityId)
	From USState s
	Left Join USCity c on s.StateId = c.StateId
	Group By s.Name
	Order By s.Name
