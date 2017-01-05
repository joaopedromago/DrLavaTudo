# DrLavaTudo
### Segue neste arquivo todos sqls feitos durante o teste ###
#### Todos exercícios foram realizados encima do seguinte banco de dados ####

```SQL
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
data_contratacao date not null,
data_execucao date not null,
primary key(id)
);
```

#Exercício 1
### No primeiro exercício, foi pedido uma alteração para que o cliente consiga fazer mais de um serviço por solicitação ###
#### Então referenciei [Chaves Estrangeiras](https://msdn.microsoft.com/pt-br/library/ms189049.aspx) da tabela ordem_de_servico, para que seja possível utilizar a tabela para realizar múltiplo serviços ####
```SQL
alter table ordem_de_servico add foreign key(id_servicos) references servicos(id), add foreign key(id_cliente) references cliente(id);
```
#### Com isso utilizaremos o seguinte [Select](https://msdn.microsoft.com/en-us/library/ms189499.aspx) para selecionar os serviços feitos pelo cliente ####
```SQL
select o.id as ID, c.nome as Cliente, s.nome_servico as Servico, data_contratacao as Contratacao, data_execucao as Execucao
	from ordem_de_servico as o 
		inner join cliente as c on c.id = o.id_cliente
		inner join servicos as s on s.id = o.id_servicos
where o.ID_Cliente = 1;
```
#Exercício 2
### No segundo exercício, foi pedido uma alteração para que fosse possível existir endereços diferentes para cada serviço ###
#### Logo criando uma tabela de endereços seria possível a existência de endereços específicos para cada serviço ####
```SQL
create table Endereco(
ID int auto_increment not null,
endereco_CEP char(8) not null,
endereco_rua varchar(14) not null,
endereco_bairro varchar(14) not null,
endereco_numero int unsigned not null,
endereco_complemento varchar(14),
endereco_cidade varchar(14) not null,
endereco_UF char(2) not null,
primary key(ID)
);
```
#### Basta adicionar a [Chave Estrangeira](https://msdn.microsoft.com/pt-br/library/ms189049.aspx) na tabela ordem_de_servico, e já será possível ligar o serviço com o endereço ####
```SQL
alter table ordem_de_servico add ID_Endereco int not null, add foreign key(ID_Endereco) references Endereco(ID);
```
#Exercício 3
### No exercício 3, foi dado vários desafios de sqls que no quais foram: ###
#### a. Selecione todos os clientes e a quantidade de ordem de serviços ####
```SQL
select c.nome as Cliente, sum(o.id) as Quantidade_Servicos from ordem_de_servico as o inner join cliente as c on c.id = o.id_cliente group by(id_cliente);
```
#### b. Selecione todas as Ordens de Serviços com mais de um serviço ####
```SQL
select * from (select id as Ordem_de_Servico, count(id_servicos) as Quantidade_Servicos from ordem_de_servico group by(id)) as Ordem_de_Servico where Quantidade_Servicos > 1;
```
#### c. Selecione os serviços mais vendidos ####
```SQL
select * from (select id as Ordem_de_Servico, count(id_servicos) as Quantidade_Servicos from ordem_de_servico group by(id)) as Ordem_de_Servico order by Quantidade_Servicos asc;
```
### Para os exercícios abaixo (d, e, f), foi necessario tirar a safe update do sql ###
```SQL
SET SQL_SAFE_UPDATES = 0;
```
#### d. Atualize o valor final de todos os serviços em 12% ####
```SQL
update servicos set valor_final = valor_final*1.14;
```

#### e. Remova a ultima ordem de serviço criada ####
```SQL
delete from ordem_de_servico where data_contratacao = (SELECT * FROM (SELECT MAX(data_contratacao) FROM ordem_de_servico) AS Maior_Data);
```

#### f. Insira um cliente ####
```SQL
insert into cliente (id, nome, email, data_de_nascimento, telefone_celular, telefone_residencial) values ("1", "João Pedro", "zaconou@gmail.com", "1996/12/15", "31997601512", "3134856165");
```

# Banco de Dados Final #
### Completando com todas alterações dos exercícios 2 e 3, o banco de dados final ficará assim ###
```SQL
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
```

### Adicionei alguns valores para serem usados de teste no programa em [C#](https://msdn.microsoft.com/en-us/library/kx37x362.aspx) ###

```SQL
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
```

# ADICIONAL #
### [Select](https://msdn.microsoft.com/en-us/library/ms189499.aspx) usado para listar OS no /api/os ###
```SQL
select 
o.id as Id, o.data_contratacao as Data_contratacao, o.data_execucao as Data_execucao, 
o.id_cliente as Id_cliente, o.id_servicos as Id_servicos, o.id_endereco as Id_endereco,
c.nome as Nome_cliente, s.nome_servico as Nome_servico, c.email as Email_cliente,
c.data_de_nascimento as Data_nasc_cliente, c.telefone_celular as Telefone_celular_cliente,
c.telefone_residencial as Telefone_residencial_cliente, e.endereco_cep as Cep_endereco,
e.endereco_rua as Rua_endereco, e.endereco_bairro as Bairro_endereco, e.endereco_numero as Numero_endereco,
e.endereco_complemento as Complemento_endereco, e.endereco_cidade as Cidade_endereco, e.endereco_UF as Uf_endereco
from ordem_de_servico as o 
inner join cliente as c on c.id = o.id_cliente 
inner join servicos as s on s.id = o.id_servicos
inner join endereco as e on e.id = o.id_endereco;
```

### [Select](https://msdn.microsoft.com/en-us/library/ms189499.aspx) usado para listar Clientes no /api/cliente ###
```SQL
select 
c.id as Id, c.nome as Nome, o.id as Id_os, s.id as Id_Servico, s.nome_servico as Nome_servico
from cliente as c
inner join ordem_de_servico as o on o.id_cliente = c.id
inner join servicos as s on s.id = o.id_servicos;
```

### Criado por:
* João Pedro Ferreira Maciel                     https://github.com/joaopedromago

* [Facebook](https://www.facebook.com/mahjao)
* [LinkedIn](https://www.linkedin.com/nhome/?trk=)
