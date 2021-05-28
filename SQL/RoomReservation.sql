create database TravelApp

use TravelApp

create table Room (
RoomId int PRIMARY KEY identity(1,1),
RoomName varchar(500),
StatusOfRoom varchar(500),
DateOfJoining date,
DateOfExit date,
ID INT FOREIGN KEY REFERENCES Reservation(ReservationId)
)

create table Room1 (
RoomId int PRIMARY KEY identity(1,1),
RoomName varchar(500),
StatusOfRoom varchar(500),
DateOfJoining date,
DateOfExit date,
Price int not null
)


use TravelApp
select * from dbo.Room1
insert into dbo.Room1 values ('VIP','FREE','2020-06-01','2020-06-05',150)


create table Customer (
CustomerId int PRIMARY KEY identity(1,1),
FirstName varchar(500),
LastName varchar(500),
Phone varchar(500),
Email varchar(500),
City varchar(500),
ID INT FOREIGN KEY REFERENCES Room(RoomId)
)

drop table Customer

Create table Reservation (
ReservationId int PRIMARY KEY identity(1,1),
ReservationName varchar(500),
)

create table VendetTuristike (
VendiId int PRIMARY KEY identity(1,1),
VendiName varchar(500),
VendLokacioni varchar(500),
)

select * from VendetTuristike
insert into dbo.VendetTuristike values ('BOGE','RUGOVE')