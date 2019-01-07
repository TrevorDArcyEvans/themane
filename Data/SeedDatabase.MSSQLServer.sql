INSERT INTO Company (Id, Name) VALUES
('Company02', 'Company02'),
('Company01', 'Company01'),
('Company03', 'Company03'),
('themane'  , 'themane')
GO

INSERT INTO Contact (Id, CompanyId, GivenName, Surname, Email, Password, Role) VALUES
('Contact01', 'Company01', 'Mike01', 'Severs01'    , 'Mike01@Company01.com'  , 'Mike01', 'User'  ),
('Contact02', 'Company02', 'Mike02', 'Severs02'    , 'Mike02@Company02.com'  , 'Mike02', 'User'  ),
('Contact03', 'Company03', 'Mike03', 'Severs03'    , 'Mike03@Company03.com'  , 'Mike03', 'User'  ),
('Admin'    , 'themane'  , 'Admin' , 'Admin'       , 'Admin@themane.com'     , 'Admin' , 'Admin' ),
('trevor'   , 'themane'  , 'Trevor', 'DArcy-Evans' , 'trevor@themane.com'    , 'trevor', 'Admin' ),
('helen'    , 'themane'  , 'Helen' , 'Hey'         , 'helen@themane.com'     , 'helen' , 'Admin' ),
('mandy'    , 'themane'  , 'Mandy' , 'DArcy-Evans' , 'mandy@themane.com'     , 'mandy' , 'Admin' ),
('neil'     , 'themane'  , 'Neil'  , 'Hey'         , 'neil@themane.com'      , 'neil'  , 'Admin' )
 GO

 INSERT INTO Usage(Id, ContactId, DateTimeUTC, InputText) VALUES
('Usage01', 'trevor', '19650715 10:34:09 AM', 'inputtext01'),
('Usage02', 'helen' , '20120618 10:34:09 AM', 'inputtext02'),
('Usage03', 'mandy' , '19631019 12:35:00 AM', 'inputtext03'),
('Usage04', 'neil'  , '20060220 06:03:00 AM', 'inputtext04'),
('Usage05', 'neil'  , '20190107 02:20:00 PM', 'inputtext05')
GO

