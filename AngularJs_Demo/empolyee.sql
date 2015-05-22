create database Employees
use Employees

create table employee
(
	id varchar(36) not null primary key,
	name varchar(20),
	position nvarchar(50),
	salary float,
	address nvarchar(100),
	email varchar(30)
)

 