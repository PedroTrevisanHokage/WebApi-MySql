CREATE DATABASE dbCliente;
use dbCliente;

create table cliente(
	id int auto_increment primary key,
    nome varchar(50) not null,
    data_cadastro date not null,
    cpf_cnpj varchar(14) not null,
    data_nascimento date not null,
    tipo char(1) not null,
    telefone varchar(20),
    email varchar(100),
    cep varchar(10),
    logradouro varchar(50),
    numero varchar(10),
    bairro varchar(50),
    complemento varchar(20),
    cidade varchar(40),
    uf char(2)
);

