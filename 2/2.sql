CREATE DATABASE iPayTest

GO

USE iPayTest

BEGIN
BEGIN TRANSACTION trans1
BEGIN TRY

	CREATE TABLE Students (
	  ID int primary key identity,
	  Name varchar(255)
	);

	CREATE TABLE Friends (
	  ID int primary key identity,
	  Friend_ID int
	);

	CREATE TABLE Packages (
	  ID int primary key identity,
	  Salary decimal(18,2)
	);

	INSERT INTO Students (Name)
	VALUES ('Ashley'), ('Samantha'), ('Julia'), ('Scarlet');

	INSERT INTO Friends (Friend_ID)
	VALUES (2), (3), (4), (1);

	INSERT INTO Packages (Salary)
	VALUES (15.20), (10.06), (11.55), (12.12);

	SELECT s.Name
	FROM Students s
	JOIN Friends f ON s.ID = f.ID
	JOIN Packages p1 ON s.ID = p1.ID
	JOIN Packages p2 ON f.Friend_ID = p2.ID
	WHERE p2.Salary > p1.Salary
	ORDER BY p2.Salary;

--ROLLBACK TRANSACTION trans1
COMMIT TRANSACTION trans1

END TRY
BEGIN CATCH

SELECT ERROR_MESSAGE()
ROLLBACK TRANSACTION trans1
END CATCH

END
