use [C:\USERS\DELL\DESKTOP\DBSD_CW\DBSD_CW\APP_DATA\BRANDBURGERDB.MDF]
go
drop table Hall
go
drop table Orders
go
drop table Phone
go
drop table Manager
go
drop table Cook
go
drop table Menu
go
drop table Staff
go
drop table Address
go
drop table Branch
go

create table Branch (
	branch_id int,
	phone varchar(200),
	constraint pk_branch_branchid primary key(branch_id)
)
go
create table Address (
	branch_id int,
	street nvarchar(200),
	city nvarchar(200),
	zip int,
	constraint pk_address_branchid primary key(branch_id),
	constraint fk_branch_address_branchid foreign key(branch_id)
	references Branch(branch_id)
)
go
create table Hall (
	hall_id int,
	places int,
	branch_id int,
	constraint pk_hall_hallid primary key(hall_id),
	constraint fk_branch_branchid foreign key(branch_id)
	references Branch(branch_id)
)
go
create table Menu (
	menu_id int,
	title nvarchar(200),
	price decimal(10, 2),
	branch_id int,
	constraint pk_menu_menuid primary key(menu_id),
	constraint fk_branch_menu_branchid foreign key(branch_id)
	references Branch(branch_id)
)
go
create table Staff (
	staff_id int,
	first_name nvarchar(200),
last_name nvarchar(200),
	email nvarchar(200),
	salary decimal(10, 2),
married BIT,
photo varbinary(max),
birth_date date,
gender nvarchar(200),
role nvarchar(200),
	branch_id int,
	constraint pk_staff_staffid primary key(staff_id),
	constraint fk_branch_staff_branchid foreign key(branch_id)
	references Branch(branch_id)
)
go
create table Phone (
	staff_id int,
	phone varchar(200),
	constraint pk_phone_staffid_phone primary key(staff_id, phone),
	constraint fk_staff_phone_staffid foreign key(staff_id)
	references Staff(staff_id)
)
go
create table Manager (
	staff_id int,
	name nvarchar(200),
	email nvarchar(200),
	salary decimal(10, 2),
	employee_count int,
	constraint pk_manager_staffid primary key(staff_id),
	constraint fk_staff_manager_staffid foreign key(staff_id)
	references Staff(staff_id)
)
go
create table Cook (
	staff_id int,
	name nvarchar(200),
	email nvarchar(200),
	salary decimal(10, 2),
	cooking_speed int,
	expertise nvarchar(200),
	constraint pk_cook_staffid primary key(staff_id),
	constraint fk_staff_cook_staffid foreign key(staff_id)
	references Staff(staff_id)
)
go
create table Orders (
	order_id int,
	status int,
	menu_item int,
	staff_id int,
	constraint pk_orders_orderid primary key(order_id),
	constraint fk_menu_menuid foreign key(menu_item)
	references Menu(menu_id),
	constraint fk_cook_staffid foreign key(staff_id)
	references Cook(staff_id)
)
go
insert into Branch(branch_id, phone) 
values (1, '12312312'), (2, '52423423')
go
insert into Address(branch_id, street, city, zip)
values (1, 'street 1', 'tashkent', 123456), (2, 'street 2', 'tashkent', 145456)
go
insert into Hall(hall_id, places, branch_id) 
values (1, 12, 1), (2, 20, 2)
go
insert into Menu(menu_id, title, price, branch_id) 
values (1, 'lavash', 22000, 1), (2, 'lavash', 21000, 2), (3, 'burger', 20000, 1)
go
insert into Staff(staff_id, first_name, last_name, email, salary, married, photo, birth_date, gender, role, branch_id) 
values (1, 'John', 'Doe', 'jdoe@mail.com', 2000000, 1, CAST('Image' AS VARBINARY(MAX)), '2020-01-01', 'M', 'Chief', 1), (2, 'Pamela', 'Doe', 'pdoe@mail.com', 2500000, 1, CAST('Image' AS VARBINARY(MAX)), '2020-01-01', 'M', 'Chief', 1),
(3, 'Andy', 'Smith', 'asmith@mail.com', 1000000, 1, CAST('Image' AS VARBINARY(MAX)), '2020-01-01', 'F', 'Chief', 2), (4, 'Michael', 'Jackson', 'mjack@mail.com', 3500000, 0, CAST('Image' AS VARBINARY(MAX)), '2020-01-01', 'M', 'Chief', 2)
go
insert into Phone(staff_id, phone) 
values (1, '12345678'), (1, '76545677'), (3, '3573525324'), (4, '1224546545')
go
insert into Manager(staff_id, name, email, salary, employee_count) 
values (1, 'John Doe', 'jdoe@mail.com', 2000000, 10), (2, 'Pamela Doe', 'pdoe@mail.com', 2500000, 3)
go
insert into Cook(staff_id, name, email, salary, cooking_speed, expertise) 
values (3, 'Andy Smith', 'asmith@mail.com', 1000000,103, 'lavash'), (4, 'Michael Jackson', 'mjack@mail.com', 3500000,200, 'burger')
go
insert into Orders(order_id, status, menu_item, staff_id) 
values (1, 0, 1, 3), (2, 1, 3, 4)
