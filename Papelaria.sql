-- select * from Clientes


-- TRIGGEEEERRR !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
-- CREATE TRIGGER tr_exibirUltimo ON Clientes AFTER INSERT 
-- AS
-- select top(1) * from Clientes ORDER BY idCliente DESC



-- INSERT INTO Clientes(nomeCliente,email,cpf)
--     values('Gustavo','gustavo@yahoo.com.br','4545454')

-- CREATE TABLE clienteTemp(
--     id int IDENTITY PRIMARY KEY,
--     nome VARCHAR(50),
--     email VARCHAR(100),
--     datacat DATETIME
-- )

-- INSERT INTO clienteTemp(nome,email,datacat)
-- (SELECT UPPER(nomeCliente), lower(email), datacadastro from Clientes)

-- select * from clienteTemp

-- DELETE from clienteTemp

-- TRIGGEEEERRR !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
-- CREATE TRIGGER tr_Transferir ON Clientes AFTER INSERT
-- AS
-- INSERT INTO clienteTemp(nome,email,datacat)
-- (SELECT TOP(1) UPPER(nomeCliente), lower(email), datacadastro from Clientes) order by idCliente desc

-- select * from clienteTemp

-- INSERT INTO Clientes(nomeCliente,email,cpf) values ('Monica','monica@terra.com.br','12121217')


-- ##################################################################################################

-- TRASACTION !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
BEGIN TRANSACTION cadCliente
declare @nome VARCHAR(50);
declare @email VARCHAR(100);
declare @idade int;
set @nome = 'Henrique';
set @email = 'henrique@uol.com.br';
set @idade = 15;
INSERT INTO clienteTemp(nome,email,datacat,idade) values (@nome,@email,GETDATE(),@idade)

IF(@idade<18)
BEGIN
PRINT 'Idade abaixo de 18 anos';
ROLLBACK tran cadCliente;
END
ELSE
BEGIN
PRINT 'Cliente cadastrado';
COMMIT tran cadCliente;
END

