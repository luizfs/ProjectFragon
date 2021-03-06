Create table Profession(
  ProfessionId int not null identity(1,1),
  NameProfession varchar(30) not null
);

create table Customer(
	CustomerId int not null identity(1,1) primary key,
	FirstName varchar(30) not null,
	LastName varchar(100) not null,
	CPF varchar(11) not null,
	BirthDate date not null,
	Age int not null,
	Profession int null
);

INSERT INTO Profession (NameProfession) values ('Developer');
INSERT INTO Profession (NameProfession) values ('Analyst');
INSERT INTO Profession (NameProfession) values ('Manager');
INSERT INTO Profession (NameProfession) values ('Trainee');
INSERT INTO Profession (NameProfession) values ('QA');
