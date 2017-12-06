using System;
using System.Collections.Generic;

namespace EXEMPLOCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            string op1;
            do
            {
                
                Console.WriteLine("\nEscolha uma das opções abaixo\n1 - Gerenciar Categorias\n2 - Gerenciar Produtos\n3 - Gerenciar Clientes\n0 - Sair");
                do
                {
                    op1 = Console.ReadLine();
                } while (op1 != "1" && op1 != "2" && op1 != "3" && op1 != "4" && op1 != "5" && op1 != "0");

                switch (op1)
                {
                    case "0": Environment.Exit(0); break;
                    case "1": MenuCategoria(); break;
                }
            } while (op1 != "0");
        }

        private static void MenuCategoria()
        {
            List<Categoria> catlist = new List<Categoria>();
            Categoria cats = new Categoria();
            BancoDados bd = new BancoDados();  
            string op1, op2, liststr;
            int listnum;
            do
            {
                
                Console.WriteLine("\nCATEGORIAS\n1 - Criar\n2 - Alterar\n3 - Excluir\n4 - Pesquisar\n0 - Sair");
                do
                {
                    op1 = Console.ReadLine();
                } while (op1 != "1" && op1 != "2" && op1 != "3" && op1 != "4" && op1 != "5" && op1 != "0");

                switch (op1)
                {
                    case "0": break;
                    case "1": System.Console.Write("\nDigite a Categoria a ser criada: "); 
                              cats.Titulo = Console.ReadLine();
                              bd.AdicionarCategorias(cats); 
                              break;
                    case "2": System.Console.Write("\nDigite o ID da Categoria para a alteração: "); 
                              cats.IdCategoria = Int32.Parse(Console.ReadLine());
                              System.Console.WriteLine("\nDigite o novo nome da Categoria ID "+cats.IdCategoria+" :");
                              cats.Titulo = Console.ReadLine();
                              bd.AtualizarCategorias(cats); 
                              break;
                    case "3": System.Console.Write("\nDigite o ID da Categoria a ser apagado: "); 
                              cats.IdCategoria = Int32.Parse(Console.ReadLine());
                              bd.ApagarCategorias(cats); 
                              break;
                    case "4": System.Console.Write("\nPesquisar por Titulo(1) ou ID(2)?  "); op2 = Console.ReadLine();
                              if(op2 == "1"){
                                  System.Console.Write("Título: ");
                                  liststr = Console.ReadLine();
                                  catlist = bd.ListarCategorias(liststr);
                              }else if(op2 == "2"){
                                  System.Console.Write("ID: ");
                                  listnum = Int32.Parse(Console.ReadLine());                       
                                  catlist = bd.ListarCategorias(listnum);
                              }else{
                                  System.Console.WriteLine("\n\nOpção ERRADA!\n\n");
                                  MenuCategoria();
                              };
                              foreach(Categoria I in catlist){
                                  System.Console.WriteLine("ID: "+I.IdCategoria+"\t"+I.Titulo);
                              }

                              break;
                }
            } while (op1 != "0");
        }
    }
}
