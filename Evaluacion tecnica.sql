create database BDTechnicalEvaluation
go
use BDTechnicalEvaluation
go
create table CurrencyAmount(
CodCurrencyAmount int primary key identity,
Amount decimal(15,2)not null,
priceDivisa  decimal(15,2)not null,
AmountExhange decimal(15,2)not null,
originCurrency varchar(30) not null,
CurrencyChange varchar(30) not null,
codUserBuyer int not null,
description varchar(200),
transactionType char(1)not null, 
created_at date,
update_at date,
active int not null default 0
);  

go
create table Currency(
CodCurrency int,
Description varchar(250),
IsoCurrency varchar(10),
Quote decimal(15,9),
Active int 
);
go
insert into Currency (CodCurrency,Description,IsoCurrency,Quote,Active)values(1000,'DOLAR ESTADOUNIDENSE','USD',104.79,0);
insert into Currency (CodCurrency,Description,IsoCurrency,Quote,Active)values(3000,'REAL BRASILEÑO','BRL',5.37,0);