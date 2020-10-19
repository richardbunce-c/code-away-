Use master
GO

Drop Database If Exists ArtDB

Create Database ArtDB

Use ArtDB
Go

Create Table Customer (
	CustomerId int Identity,
	FirstName nvarchar(25) not null,
	LastName nvarchar(30) not null,
	Address nvarchar(max) null,
	Phone varchar(20) null,
	Constraint pk_Customer Primary key (CustomerId)
)

Create table Artist(
	ArtistId int Identity Primary Key,
	FirstName nvarchar(25) not null,
	LastName nvarchar(30) not null
)

Create Table Art(
	ArtId int Primary key Identity,
	Title nvarchar(200) not null,
	ArtistId int not null,
	Price money not null,
	-- CONSTRAINT <name of constraint> FOREIGN KEY (<column in this table>) REFERENCES <referenced table> (<referenced PK column(s)>)
	Constraint fk_Art_Artist Foreign Key (ArtistId) references Artist (ArtistId)
)

Create Table Inventory (
	InventoryId int primary key identity,
	ArtId int not null,
	Quantity int not null default(1),
	Constraint fk_Inventory_Art Foreign Key (ArtId) references Art(ArtId)
)

Create table Purchase(
	PurchaseId int identity,
	CustomerId int not null,
	ArtId int not null,
	PurchaseDate datetime not null Default (getdate()),
	PurchasePrice money not null,
	Constraint pk_Purchase Primary Key (PurchaseId),
	Constraint fk_Purchase_Customer Foreign Key (CustomerId) references Customer(CustomerId),
	Constraint fk_Purchase_Art Foreign Key (ArtId) References Art(ArtId)
)