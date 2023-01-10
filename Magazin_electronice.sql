use master
if DB_ID('Magazin_Electronice') is not null
drop database Magazin_Electronice;
CREATE DATABASE Magazin_Electronice -- creazã baza de date
ON PRIMARY
(
Name = Magazin_Electronice,
FileName = 'D:\sql\Magazin_Electronice.mdf',
size = 10MB, -- KB, Mb, GB, TB
maxsize = unlimited,
filegrowth = 100MB
),
(
Name = Magazin_Electronice2,
FileName = 'D:\sql\Magazin_Electronice2.ndf',
size = 10MB, -- KB, Mb, GB, TB
maxsize = unlimited,
filegrowth = 100MB
)
LOG ON
(
Name = Magazin_ElectroniceLOG,
FileName = 'D:\sql\Magazin_Electronice.ldf',
size = 10MB, -- KB, Mb, GB, TB
maxsize = unlimited,
filegrowth = 100MB
)
go 
use Magazin_Electronice

if OBJECT_ID('Costumer', 'U') is not null
drop table Costumer
go
CREATE TABLE Costumer
(
IDCostumer int IDENTITY(1,1) PRIMARY KEY,
login_name nvarchar(50) NOT NULL,
login_password nvarchar(50) NOT NULL,
email nvarchar(100) NOT NULL,
)





if OBJECT_ID('CategorieProduse', 'U') is not null
drop table CategorieProduse
go
CREATE TABLE CategorieProduse 
(
IDCategorie int IDENTITY(1,1) PRIMARY KEY,
Denumire nvarchar(50) NOT NULL,
)
if OBJECT_ID('Produse', 'U') is not null
drop table Produse
go
CREATE TABLE Produse 
(
IDProdus int IDENTITY(1,1) PRIMARY KEY,
Denumire nvarchar(50) NOT NULL,
IDCategorie int NOT NULL FOREIGN KEY REFERENCES CategorieProduse(IDCategorie),
DescriereProdus nvarchar(50) NOT NULL
)
if OBJECT_ID('Orders', 'U') is not null
drop table Orders
go
CREATE TABLE Orders(
IDOrder int IDENTITY(1,1) PRIMARY KEY,
IDCostumer int NOT NULL FOREIGN KEY REFERENCES Costumer(IDCostumer),
IDProdus int NOT NULL FOREIGN KEY REFERENCES Produse(IDProdus),
DataPlasareComanda date NOT NULL,
Order_quantity int NOT NULL,
)

if OBJECT_ID('Inventar', 'U') is not null
drop table Inventar
go
CREATE TABLE Inventar 
(
IDProdus int NOT NULL FOREIGN KEY REFERENCES Produse(IDProdus),
Cantitate int NOT NULL,
PretUnitar money NOT NULL
)



--if OBJECT_ID('Shipment_Items', 'U') is not null
--drop table Shipment_Items
--go
--CREATE TABLE Shipment_Items(
--IDOrder_items int NOT NULL FOREIGN KEY REFERENCES Order_items(IDOrder_items),
--IDShipments int NOT NULL FOREIGN KEY REFERENCES Shipments(IDShipments)
--)

if OBJECT_ID('Bill', 'U') is not null
drop table Bill
go
CREATE TABLE Bill(
IDOrder int NOT NULL FOREIGN KEY REFERENCES Orders(IDOrder),
Bill_status bit NOT NULL, 
Payment_date date NOT NULL,
Bill_amount money NOT NULL,
DetaliiBill nvarchar(50)
)

