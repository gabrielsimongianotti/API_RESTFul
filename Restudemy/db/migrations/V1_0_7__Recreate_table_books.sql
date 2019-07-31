CREATE TABLE `books` (
  `id` int(10) auto_increment primary key,
  `Author` longtext,
  `LaunchDate` datetime(6) NOT NULL,
  `Price` decimal(65,2) NOT NULL,
  `Title` longtext
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
