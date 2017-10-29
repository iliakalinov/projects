Create table Users 
(
user_id int Not Null,
login varchar(20),
names varchar(50),
passwords varchar(20),
Pasport varchar(20),
money numeric,
status varchar(15),
constraint  user_pk primary key (user_id) 
)
ALTER TABLE Users ADD (UNIQUE (pasport));
ALTER TABLE Users ADD (UNIQUE (login));

--Command
Create table Command 
(
command_id int Not Null,
names varchar(50),
Country varchar(20),
Powers numeric,
constraint  command_pk primary key (command_id) 
);

--Resultmatch

Create table ResultMatch 
(
command_id1 int Not Null,
command_id2 int Not Null,
score1 int,
score2 int,
constraint command_fk1 foreign key (command_id1) REFERENCES Command(command_id),
constraint command_fk2 foreign key (command_id2) REFERENCES Command(command_id)
);

--sportsMan

Create table sportsman 
(
sportsman_id int Not Null,
command_id int Not Null,
names varchar(50),
Position varchar(20),
constraint  sportsman_pk primary key (sportsman_id),
constraint command_fk foreign key (command_id) REFERENCES Command(command_id)
);
--match


Create table match 
(
match_id int Not Null,
command1_id int Not Null,
command2_id int Not Null,
ochki_1 int,
ochki_2 int,
satart_time date,
TimeGame int,
kef1 float (4),
kef2 float(4),
kef3 float(4),
constraint  match_pk primary key (match_id),
constraint command1_fk foreign key (command1_id) REFERENCES Command(command_id),
constraint command2_fk foreign key (command2_id) REFERENCES Command(command_id)
);

--Stavka

Create table Stavka 
(
stavka_id int Not Null,
match_id int Not Null,
user_id int Not Null,
kef int,
times date,
money float,
constraint  stavka_pk primary key (stavka_id),
constraint match_fk foreign key (match_id) REFERENCES match(match_id),
constraint user_fk foreign key (user_id) REFERENCES Users(user_id)
);

--drop table

drop table Stavka;
drop table match;
drop table sportsman;
drop table ResultMatch;
drop table Command;
drop table Users;

--Encrypt

-- odin raz delaem
alter system set encryption key 
authenticated by "s03an92qaz";

--open 
alter system set encryption wallet open authenticated by "s03an92qaz";

alter system set encryption wallet close authenticated by "s03an92qaz";
--encrypt table
alter table Users modify (passwords encrypt);
alter table Users modify (status encrypt);
alter table Command modify (Powers encrypt);

Select * from users;
select * from dba_encrypted_columns;

--sequence
create sequence SqUser start with 1; 
create sequence SqCommand start with 1; 
create sequence SqMatch start with 1; 
create sequence SqSportsman start with 1; 
create sequence SqStavka start with 1; 

drop sequence SqUser; 
drop sequence SqCommand; 
drop sequence SqMatch; 
drop sequence SqSportsman ; 
drop sequence SqStavka ;

  
  SELECT
  username, --Логин
  account_status, --Статус аккаунта
  lock_date --дата блокировки(если пользователь заблокирован)
  FROM dba_users;


