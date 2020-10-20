Use master
GO 


Drop Database if Exists ArtDB

Create Database ArtDB

Use ArtDB
GO

Create Table Customer (
	CustomerId int Identity,
	FirstName nvarchar(25)not null,
	LastName nvarchar(25)not null,
	Address nvarchar(max)null,
	Phone varchar(20) null,
	City nvarchar(25)null,
	District nvarchar(25)null,
	PostalCode nvarchar(25)null
	Constraint pk_Customer Primary key (CustomerId)
)

Create Table Artist(
	ArtistId int Identity Primary Key,
	FirstName nvarchar(25)not null,
	LastName nvarchar (25)not null
)

Create Table Art(
	ArtId int Primary Key Identity,
	Title nvarchar(max)not null, 
	ArtistId int not null,
	Price money not null,
	--Contstraint<name of constraint> Foreign Key (<column in this table> References <referenced table>(<referenced PK column(s)>)
	Constraint fk_Art_Artist Foreign Key (ArtistId) references Artist(ArtistId)
)

Create Table Inventory(
	InventoryId int Primary Key Identity,
	ArtId int not null,
	Quantity int not null default(1),
	Constraint fk_Inventory_Art Foreign Key (ArtId) references Art(ArtId)
)

Create Table Purchase(
	PurchaseId int Primary Key Identity,
	CustomerId int not null,
	ArtId int not null,
	PurchaseDate datetime not null default(getdate()),
	PurchasePrice money not null,
	Constraint fk_Purchase_Customer Foreign Key (CustomerId) references Customer(CustomerId),
	Constraint fk_Purchase_Art Foreign Key (ArtId) references Art(ArtId)
)