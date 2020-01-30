drop Database if exists ParkWebsite;
drop Database ParkWebsite;
create Database ParkWebsite collate utf8_general_ci;

use ParkWebsite;

create table Park (
	id int not null auto_increment,
    name varchar(100) not null,
    length int null,
    jumps int null,
    rails int null,
    cableways int null,
    status int not null, 
    
    constraint id_PK primary key(id)
)engine=InnoDB;

create table User (
	id int not null auto_increment,
    name varchar(100) null,
    lastname varchar(100) not null,
    birthday datetime null,
    isAdmin tinyint not null default 0,
    email varchar(100) not null,
    password varchar(100) not null,
    gender int null,
	username varchar(100) not null unique,
    
    constraint id_PK primary key (id)
)engine=InnoDB;


insert into Park (id, name, status) values (null, "Betterpark Hintertux", 0);
insert into Park (id, name, status) values (null, "Golden Roofpark", 0);
insert into Park (id, name, status) values (null, "Ischgl Snowpark", 0);
insert into Park (id, name, status) values (null, "Kaunertaler Snowpark", 0);
insert into Park (id, name, status) values (null, "Skylinepark", 0);
insert into Park (id, name, status) values (null, "Penken Park", 0);
insert into Park (id, name, status) values (null, "Snowpark Kitzbuehel", 0);
insert into Park (id, name, status) values (null, "Snowpark Soelden", 0);
insert into Park (id, name, status) values (null, "St Anton Snowpark", 0);
insert into Park (id, name, status) values (null, "Stubaier Zoo", 0);

UPDATE Park SET status='1' WHERE name = 'Betterpark Hintertux';
UPDATE Park SET status='1' WHERE name = 'Penken Park';
UPDATE Park SET status='0' WHERE name = 'Penken Park';



    