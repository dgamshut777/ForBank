CREATE TABLE [Users]
(
		Id INT PRIMARY KEY IDENTITY,
		FirstName NVARCHAR(255) not null default '',
		LastName NVARCHAR(255) not null default '',
		Patronymic NVARCHAR(255) not null default '',
		Job NVARCHAR(max) not null default '',
		BirthDate date not null
)
CREATE TABLE [Cards]
(
		Id INT PRIMARY KEY IDENTITY,
		Number NVARCHAR(255) not null default '',
		FullName NVARCHAR(255) not null default '',
		ExpDate VARCHAR(255),
		CVC int,
		UserId int,
		CONSTRAINT FK_Cards_Users_UserId FOREIGN KEY (UserId)
		REFERENCES Users (Id)
		ON DELETE CASCADE
        ON UPDATE CASCADE
)

