-- Tabela Pessoa
CREATE TABLE Pessoa (
    idPessoa INT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) NOT NULL,
    dataNasc DATE NOT NULL,
    genero VARCHAR(10),
    rg VARCHAR(20),
    estadoCivil VARCHAR(20),
    telefone VARCHAR(20),
    cel1 VARCHAR(20),
    cel2 VARCHAR(20),
    cep VARCHAR(10),
    estado VARCHAR(50),
    municipio VARCHAR(100),
    bairro VARCHAR(100),
    endereco VARCHAR(200),
    numeroEndereco VARCHAR(10),
    escolaridade VARCHAR(50),
    grauEscolaridade VARCHAR(50),
    email VARCHAR(100)
);

-- Tabela Cliente
CREATE TABLE Cliente (
    idCliente INT PRIMARY KEY,
    idPessoa INT NOT NULL,
    FOREIGN KEY (idPessoa) REFERENCES Pessoa(idPessoa) ON DELETE CASCADE,
    INDEX fk_cliente_pessoa (idPessoa)
);

-- Tabela Funcionario
CREATE TABLE Funcionario (
    idFuncionario INT PRIMARY KEY,
    idPessoa INT NOT NULL,
    setor VARCHAR(100),
    FOREIGN KEY (idPessoa) REFERENCES Pessoa(idPessoa) ON DELETE CASCADE,
    INDEX fk_funcionario_pessoa (idPessoa)
);

-- Tabela Gerente
CREATE TABLE Gerente (
    idGerente INT PRIMARY KEY,
    idFuncionario INT NOT NULL,
    FOREIGN KEY (idFuncionario) REFERENCES Funcionario(idFuncionario) ON DELETE CASCADE,
    INDEX fk_gerente_funcionario (idFuncionario)
);

-- Tabela Fornecedor
CREATE TABLE Fornecedor (
    idFornecedor INT PRIMARY KEY,
    idPessoa INT NOT NULL,
    FOREIGN KEY (idPessoa) REFERENCES Pessoa(idPessoa) ON DELETE CASCADE,
    INDEX fk_fornecedor_pessoa (idPessoa)
);

-- Tabela Fruta
CREATE TABLE Fruta (
    id INT PRIMARY KEY,
    nome VARCHAR(50) NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    categoria VARCHAR(50),
    unidMedida VARCHAR(50),
    quant INT,
    precoCusto FLOAT,
    precovendaAtac FLOAT,
    precoVendaVarej FLOAT,
    dataCadastro DATE,
    dataValidade DATE
);
