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
    location varchar(100) not null,
    description varchar (1000) null,
    
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

create table comments(
	id int not null auto_increment,
    commentspark_id int not null,
    comment varchar(500) null,
    userid int null,
    
    constraint id_PK primary key(id),
	constraint commentsrecipe_id_FK foreign key(commentspark_id) references park(id),
    constraint userid_FK foreign key(userid) references user(id) 
    
)engine=InnoDB;


insert into Park (id, name, status, location) values (null, "Betterpark Hintertux", 0, "Hintertux");
insert into Park (id, name, status, location) values (null, "Golden Roofpark", 0, "Axamer Lizum");
insert into Park (id, name, status, location) values (null, "Ischgl Snowpark", 0, "Ischgl");
insert into Park (id, name, status, location) values (null, "Kaunertaler Snowpark", 0, "Kaunertal");
insert into Park (id, name, status, location) values (null, "Skylinepark", 0, "Nordkette");
insert into Park (id, name, status, location) values (null, "Penken Park", 0, "Mayrhofen");
insert into Park (id, name, status, location) values (null, "Snowpark Kitzbühel", 0, "Kitzbühel");
insert into Park (id, name, status, location) values (null, "Snowpark Sölden", 0, "Sölden");
insert into Park (id, name, status, location) values (null, "St. Anton Snowpark", 0, "St. Anton");
insert into Park (id, name, status, location) values (null, "Stubaier Zoo", 0, "Stubaier Gletscher");

insert into Comments values (null, 1, "hallo", null);
insert into Comments values (null, 1, "Volle geil", null);

UPDATE Park SET status='1', jumps='7', rails='15', cableways='1' WHERE id = '2';
UPDATE Park SET status='1' WHERE name = 'Penken Park';
UPDATE Park SET status='0' WHERE name = 'Penken Park';
UPDATE Park SET location="Hintertuxer Gletscher" WHERE name = 'Betterpark Hintertux';



select * from User;