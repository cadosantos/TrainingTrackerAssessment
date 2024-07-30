BEGIN TRANSACTION

CREATE TABLE Rank
(
	Id INT PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL
)

CREATE TABLE Country
(
	Id INT PRIMARY KEY,
	Name NVARCHAR(30) NOT NULL
)

CREATE TABLE SensorType
(
	Id INT PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL
)

CREATE TABLE SensorManufacturer
(
	Id INT PRIMARY KEY,
	Name NVARCHAR(20) NOT NULL
)

CREATE TABLE Sensor -- It could be an Enum if we are talking about few (e.g: 5) different sensors, and we do not care about the physical devide itself
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	SensorManufacturerId INT NOT NULL,
	SensorTypeId INT NOT NULL,
	FOREIGN KEY (SensorManufacturerId) REFERENCES SensorManufacturer(Id),
	FOREIGN KEY (SensorTypeId) REFERENCES SensorType(Id)
)

CREATE TABLE Soldier
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Name NVARCHAR(100) NOT NULL,
	RankId INT NOT NULL,
	CountryId INT NOT NULL,
	TrainingInfo NVARCHAR(255) NULL,
	SensorId UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (RankId) REFERENCES Rank(Id),
	FOREIGN KEY (CountryId) REFERENCES Country(Id),
	FOREIGN KEY (SensorId) REFERENCES Sensor(Id)
)

CREATE TABLE MapPosition
(
	Id UNIQUEIDENTIFIER PRIMARY KEY,
	Latitude DECIMAL(9,6) NOT NULL,
	Longitude DECIMAL(9,6) NOT NULL,
	SoldierId UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (SoldierId) REFERENCES Soldier(Id)
)

--20240730 2059
ALTER TABLE dbo.MapPosition
ADD CreatedDate datetime NOT NULL;

COMMIT TRANSACTION
