BEGIN
BEGIN TRANSACTION trans1
BEGIN TRY

	CREATE TABLE MSOccupation (
	  ID int primary key identity,
	  Name varchar(255),
	  Occupation varchar(255)
	);

	INSERT INTO MSOccupation (Name,Occupation)
	VALUES 
	('Samantha', 'Doctor'),
	('Julia', 'Actor'),
	('Maria', 'Actor'),
	('Meera', 'Singer'),
	('Ashely', 'Professor'),
	('Ketty', 'Professor'),
	('Christeen', 'Professor'),
	('Jane', 'Actor'),
	('Jenny', 'Doctor'),
	('Priya', 'Singer')
	;

	SELECT * FROM MSOccupation

--ROLLBACK TRANSACTION trans1
COMMIT TRANSACTION trans1

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE()
ROLLBACK TRANSACTION trans1
END CATCH

END
