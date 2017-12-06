using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EXEMPLOCRUD
{
    public class BancoDados
    {
        SqlConnection cn;
        SqlCommand comandos;
        SqlDataReader rd;

        public List<Categoria> ListarCategorias(string titulo){
            List<Categoria> lista = new List<Categoria>();
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                cn.Open();

                comandos = new SqlCommand();

                comandos.Connection = cn;

                comandos.CommandType =  CommandType.Text;

                comandos.CommandText = "select * from Categorias where titulo like @vi";
                comandos.Parameters.AddWithValue("@vi",titulo);

                rd = comandos.ExecuteReader();
                
                //Primeiro modo de fazer
                while(rd.Read()){
                    lista.Add(new Categoria{
                            IdCategoria=rd.GetInt32(0),
                            Titulo = rd.GetString(1)
                    });
                }

                //Segundo modo de fazer
                // while(rd.Read()){
                //     Categoria ct = new Categoria(){
                //         IdCategoria = rd.GetInt32(0),
                //         Titulo = rd.GetString(1)
                //     };
                //     lista.Add(ct);
                // }
                
                comandos.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception("Erro ao tentar listar. "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }finally{
                cn.Close();
            }
            return lista;

        }


        public List<Categoria> ListarCategorias(int id){
            List<Categoria> lista = new List<Categoria>();
            try{
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                cn.Open();

                comandos = new SqlCommand();

                comandos.Connection = cn;

                comandos.CommandType =  CommandType.Text;

                comandos.CommandText = "select * from Categorias where idcategoria=@vi";
                comandos.Parameters.AddWithValue("@vi",id);

                rd = comandos.ExecuteReader();
                
                //Primeiro modo de fazer
                while(rd.Read()){
                    lista.Add(new Categoria{
                            IdCategoria=rd.GetInt32(0),
                            Titulo = rd.GetString(1)
                    });
                }

                //Segundo modo de fazer
                // while(rd.Read()){
                //     Categoria ct = new Categoria(){
                //         IdCategoria = rd.GetInt32(0),
                //         Titulo = rd.GetString(1)
                //     };
                //     lista.Add(ct);
                // }

                comandos.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception("Erro ao tentar listar. "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }finally{
                cn.Close();
            }
            return lista;

        }

        public bool AdicionarCategorias(Categoria cat){

            bool rs = false;
            try{
                cn = new SqlConnection();
                cn.ConnectionString=@"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                cn.Open();

                comandos = new SqlCommand();
                //RELACIONAMENTO DA CONEXAO COM O OBJETO RESPONSAVEL PELOS COMANDOS
                comandos.Connection = cn;
                //O primeiro CommandType está dentro do SQLCommands, mas o segundo CommandType está em outra classe chamada Data
                comandos.CommandType =  CommandType.Text;

                //Preparando o comando de inserção
                comandos.CommandText = "insert into Categorias (titulo) values (@vt)";
                //Passando o título para a variavel de inserção.
                comandos.Parameters.AddWithValue("@vt",cat.Titulo);

                //Executando o comando de inserção
                int r = comandos.ExecuteNonQuery();
                if(r > 0)
                    rs = true;
                
                //Limpando variaveis de execução
                comandos.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception("Erro ao tentar cadastrar. "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }finally{
                cn.Close();
            }
            return rs;

        }

        public bool AtualizarCategorias(Categoria cat){

            bool rs = false;
            try{
                cn = new SqlConnection();
                cn.ConnectionString=@"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                cn.Open();

                comandos = new SqlCommand();
                //RELACIONAMENTO DA CONEXAO COM O OBJETO RESPONSAVEL PELOS COMANDOS
                comandos.Connection = cn;
                //O primeiro CommandType está dentro do SQLCommands, mas o segundo CommandType está em outra classe chamada Data
                comandos.CommandType =  CommandType.Text;

                //Preparando o comando de inserção
                comandos.CommandText = "update Categorias set titulo=@vt where idcategoria=@vi";
                //Passando o título para a variavel de inserção.
                comandos.Parameters.AddWithValue("@vt",cat.Titulo);
                comandos.Parameters.AddWithValue("@vi",cat.IdCategoria);

                //Executando o comando de inserção
                int r = comandos.ExecuteNonQuery();
                if(r > 0)
                    rs = true;
                
                //Limpando variaveis de execução
                comandos.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception("Erro ao tentar atualizar. "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }finally{
                cn.Close();
            }
            return rs;

        }

        public bool ApagarCategorias(Categoria cat){

            bool rs = false;
            try{
                cn = new SqlConnection();
                cn.ConnectionString=@"Data Source=.\sqlexpress;Initial Catalog=Papelaria;user id=sa;password=senai@123";
                cn.Open();

                comandos = new SqlCommand();
                //RELACIONAMENTO DA CONEXAO COM O OBJETO RESPONSAVEL PELOS COMANDOS
                comandos.Connection = cn;
                //O primeiro CommandType está dentro do SQLCommands, mas o segundo CommandType está em outra classe chamada Data
                comandos.CommandType =  CommandType.Text;

                //Preparando o comando de inserção
                comandos.CommandText = "delete from Categorias where idcategoria=@vi";
                //Passando o título para a variavel de inserção.
                comandos.Parameters.AddWithValue("@vi",cat.IdCategoria);

                //Executando o comando de inserção
                int r = comandos.ExecuteNonQuery();
                if(r > 0)
                    rs = true;
                
                //Limpando variaveis de execução
                comandos.Parameters.Clear();

            }catch(SqlException se){
                throw new Exception("Erro ao tentar apagar. "+se.Message);
            }catch(Exception ex){
                throw new Exception("Erro inesperado. "+ex.Message);
            }finally{
                cn.Close();
            }
            return rs;

        }
        

    }
}