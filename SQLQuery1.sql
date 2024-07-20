create database Demodb;
use Demodb;
CREATE TABLE demo(
    articleID varchar(30) NOT NULL PRIMARY KEY,
    articleName varchar(30) NOT NULL,
);
insert into demo values(1, 'C#');
insert into demo values(2, 'C++');