use Dapper1;

create table Book (
BookId int primary key identity(1,1),
Title nvarchar(255) not null,
Price decimal(10,2) not null,
Author nvarchar(255) not null,
Publisher nvarchar(255) not null,
Language nvarchar(50) not null,
PublicationDate date not null
);

insert into Book (Title, Price, Author, Publisher, Language, PublicationDate) values
('The Great Gatsby', 10.99, 'F. Scott Fitzgerald', 'Scribner', 'English', '1925-04-10'),
('To Kill a Mockingbird', 7.99, 'Harper Lee', 'J.B. Lippincott & Co.', 'English', '1960-07-11');