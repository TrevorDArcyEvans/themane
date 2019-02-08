INSERT INTO Company (Id, Name) VALUES
('Company02', 'Company02'),
('Company01', 'Company01'),
('Company03', 'Company03'),
('themane'  , 'themane');


-- MD5 hashes from:
--  https://passwordsgenerator.net/md5-hash-generator/
INSERT INTO Contact (Id, CompanyId, GivenName, Surname, Email, Password, Role) VALUES
('Contact01', 'Company01', 'Mike01', 'Severs01'    , 'Mike01@Company01.com'  , '5C4E8FDF0A83BC1650C74BFC05C37D94', 'User'  ), -- Mike01
('Contact02', 'Company02', 'Mike02', 'Severs02'    , 'Mike02@Company02.com'  , '812A53B09DFAB5D69E4338E79166FF43', 'User'  ), -- Mike02
('Contact03', 'Company03', 'Mike03', 'Severs03'    , 'Mike03@Company03.com'  , '5936FD057094EB16C02B2A91D2F28782', 'User'  ), -- Mike03
('Admin'    , 'themane'  , 'Admin' , 'Admin'       , 'Admin@themane.com'     , 'E3AFED0047B08059D0FADA10F400C1E5', 'Admin' ), -- Admin
('trevor'   , 'themane'  , 'Trevor', 'DArcy-Evans' , 'trevor@themane.com'    , 'D801A0B4701F64A0EAE5F71F44F8D83F', 'Admin' ), -- trevor
('helen'    , 'themane'  , 'Helen' , 'Hey'         , 'helen@themane.com'     , '7A2EB41A38A8F4E39C1586649DA21E5F', 'Admin' ), -- helen
('mandy'    , 'themane'  , 'Mandy' , 'DArcy-Evans' , 'mandy@themane.com'     , '006CE4922072B1E7F8B733347FE1A40B', 'Admin' ), -- mandy
('neil'     , 'themane'  , 'Neil'  , 'Hey'         , 'neil@themane.com'      , 'D68E939882371200637D5024B360FC20', 'Admin' ); -- neil
 

 INSERT INTO Usage(Id, ContactId, DateTimeUTC, InputText) VALUES
('Usage01', 'trevor', '1965-07-15 10:34:09.0000000', 'inputtext01'),
('Usage02', 'helen' , '2012-06-18 10:34:09.0000000', 'inputtext02'),
('Usage03', 'mandy' , '1963-10-19 00:35:00.0000000', 'inputtext03'),
('Usage04', 'neil'  , '2006-02-20 06:03:00.0000000', 'inputtext04'),
('Usage05', 'neil'  , '2019-01-07 14:20:00.0000000', 'inputtext05');

