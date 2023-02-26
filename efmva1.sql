create database efmv1
use efmv1
go

create table  produit (
refp varchar (60) primary key,
designationp varchar (80),
pup float ,
qtestock int,
)
create table fournisseur (
codef varchar (60) primary key,
rsf varchar (80) 
)
create table entree (
nume int identity primary key,
datee datetime ,
qtee int,
refp varchar (60) foreign key references produit (refp),
codef varchar (60) foreign key references fournisseur (codef)
)
alter table entree alter column datee date
