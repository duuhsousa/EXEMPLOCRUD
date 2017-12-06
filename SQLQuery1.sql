/*CREATE PROCEDURE sp_CadCliente
@nome varchar(50),
@email varchar(100),
@cpf varchar(20)
as
insert into clientes(nomeCliente, email, cpf) 
			 values (@nome,@email,@cpf)

			 */

EXEC sp_CadCliente 'Maria','maria@uol.com.br','1212'

select * from Clientes