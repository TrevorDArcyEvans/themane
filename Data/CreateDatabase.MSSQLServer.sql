-- assumes database collation is:
--    Latin1_General_CI_AI


-- drop tables
DROP TABLE IF EXISTS Usage;
DROP TABLE IF EXISTS Contact;
DROP TABLE IF EXISTS Company;

-- create data tables
-- NOTE:  maximum text field lengths is 425 characters because 
--        max index size (on relationship tables) is 1700 bytes (425 = 1700/4)

CREATE TABLE Company
(
  Id NVARCHAR(36) NOT NULL UNIQUE,
  Name NVARCHAR(425) NOT NULL UNIQUE,
  PRIMARY KEY (Id)
);

CREATE TABLE Contact
(
  Id NVARCHAR(36) NOT NULL UNIQUE,
  CompanyId NVARCHAR(36) NOT NULL,
  GivenName TEXT,
  Surname TEXT,
  Email TEXT,
  Password TEXT,
  Role TEXT,
  CONSTRAINT FK_Contact_Company FOREIGN KEY (CompanyId) REFERENCES Company(Id) ON DELETE CASCADE,
  PRIMARY KEY (Id)
);

CREATE TABLE Usage
(
  Id NVARCHAR(36) NOT NULL UNIQUE,
  ContactId NVARCHAR(36) NOT NULL,
  DateTimeUTC DATETIME2,
  InputText TEXT,
  CONSTRAINT FK_Usage_Contact FOREIGN KEY (ContactId) REFERENCES Contact(Id) ON DELETE CASCADE,
  PRIMARY KEY (Id)
);
