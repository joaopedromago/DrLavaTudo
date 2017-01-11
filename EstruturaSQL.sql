create database drlavatudo;
use drlavatudo;

create table cliente(
id int not null,
nome varchar(80) not null,
email varchar(80) not null,
data_de_nascimento date not null,
telefone_celular char(11) not null,
telefone_residencial char(11) not null,
primary key(id)
);

create table servicos(
id int auto_increment not null,
nome_servico varchar(80) not null,
valor_final double(9,2) not null,
custo_empresa double(9,2) not null,
primary key(id)
);

create table ordem_de_servico(
id int auto_increment not null,
id_cliente int not null,
id_servicos int not null,
id_endereco int not null,
data_contratacao date not null,
data_execucao date not null,
foreign key(id_cliente) references cliente(id),
foreign key(id_servicos) references servicos(id),
foreign key(id_endereco) references endereco(id),
primary key(id)
);

create table Endereco(
ID int auto_increment not null,
endereco_CEP char(8) not null,
endereco_rua varchar(28) not null,
endereco_bairro varchar(14) not null,
endereco_numero int unsigned not null,
endereco_complemento varchar(14),
endereco_cidade varchar(14) not null,
endereco_UF char(2) not null,
primary key(ID)
);

insert into cliente (id, nome, email, data_de_nascimento, telefone_celular, telefone_residencial) values ("1", "João Pedro", "zaconou@gmail.com", "1996/12/15", "31997601512", "3134856165");
insert into cliente (id, nome, email, data_de_nascimento, telefone_celular, telefone_residencial) values ("2", "Gabriel", "gemail@gmail.com", "1999/02/16", "31997586446", "31134586924");
insert into cliente (id, nome, email, data_de_nascimento, telefone_celular, telefone_residencial) values ("3", "Jax Teller", "jackieboy@samcro.com", "1976/01/08", "31987462546", "3133789865");

insert into servicos(nome_servico, valor_final, custo_empresa) values ("Estagiário", "350", "450");
insert into servicos(nome_servico, valor_final, custo_empresa) values ("Supervisor", "600", "798");
insert into servicos(nome_servico, valor_final, custo_empresa) values ("Motoboy", "987", "1045");

insert into endereco (endereco_CEP, endereco_rua, endereco_bairro, endereco_numero, endereco_complemento, endereco_cidade, endereco_UF) values("31070130", "Porto Seguro", "Nova Vista", "735", "casa", "BH", "MG");
insert into endereco (endereco_CEP, endereco_rua, endereco_bairro, endereco_numero, endereco_complemento, endereco_cidade, endereco_UF) values("31070130", "Roberto de afonso", "Goiania", "432", "Apartamento", "BH", "MG");
insert into endereco (endereco_CEP, endereco_rua, endereco_bairro, endereco_numero, endereco_complemento, endereco_cidade, endereco_UF) values("31070130", "HighwayRoad", "SAMCRO", "987", "casa", "Charming", "CA");

insert into ordem_de_servico (id_cliente, id_servicos, data_contratacao, data_execucao, id_endereco) values("1", "1", "2016/01/01", "2016/01/05", "1");
insert into ordem_de_servico (id_cliente, id_servicos, data_contratacao, data_execucao, id_endereco) values("1", "2", "2016/01/04", "2016/01/15", "2");
insert into ordem_de_servico (id_cliente, id_servicos, data_contratacao, data_execucao, id_endereco) values("3", "3", "2001/02/14", "2014/02/06", "3");
