


create database librarydb
use librarydb
create table userlogin(user_name varchar(30),password varchar(30))
create table students(student_id int primary key,student_name varchar(40),roll int,department varchar(40))
create table books(book_id int primary key,book_name varchar(40),Author_name varchar(40),book_stock int)
create table issuebook(student_id int references students(student_id),bookid int)
insert into userlogin values('hema','hema@123')
select * from userlogin
select * from students
select * from books
select * from issuebook

