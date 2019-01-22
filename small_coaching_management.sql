USE master
go
create database small_coaching_management
go
use small_coaching_management
go

create table Teacher
(
TeacherId int identity primary key,
TeacherName varchar(200) unique not null,
Contact varchar(100) unique not null,
Address Varchar(200) not null,
UserName Varchar(200) not null,
UserPassword Varchar(200) not null
)


Create table Class
(
ClassId int identity primary key,
ClassName varchar(200) not null
)

Create table Course
(
CourseId int identity primary key,
CourseName varchar(100) not null,
)


Create Table Schedule
(
ScheduleId int identity primary key,
ClassTime Datetime not null,
Class_Day varchar(10) not null,
TeacherId int not null,
ClassId int not null,
CourseId int not null,
Foreign key (TeacherId) references Teacher(TeacherId),
Foreign key (ClassId) references Class(ClassId),
Foreign key (CourseId) references Course(CourseId)
) 

Create table Student
(
StudentId int identity primary key,
StudentName Varchar(200) not null,
ID int not null,
StudentContact Varchar(100) not null,
StudentAddress Varchar(200) not null,
studentClass Varchar(100) not null,
UserName Varchar(200) not null,
UserPassword Varchar(200) not null,
PamentAmount Varchar(100) not null
)

Create table StudentClass
(
StudentClassId int identity primary key,
StudentId int not null,
ClassId int not null,
Amount int not null,
Foreign key (StudentId) references Student(StudentId),
Foreign key (ClassId) references Class(ClassId)
)

Create table StudentBill
(
StudentBilId  int identity primary key,
BillMonth varchar(50) not null,
Amount int not null,
StudentId int not null,
foreign key (StudentId) references Student(StudentId)
)

Create table Transcetion
(
TransectionId int identity primary key,
TransectionnDate Datetime not null,
StudentBillId int not null,
Foreign key (StudentBillId) references studentBill(StudentBilId)
)

