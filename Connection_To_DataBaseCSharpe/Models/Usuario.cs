﻿using Connection_To_DataBaseCSharpe.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection_To_DataBaseCSharpe.Models
{
    public class Usuario
    {
        Usuario[] usuarios = new Usuario[] { };
        public Usuario(string nome, int idade, string endereço)
        {
            Nome = nome;
            Idade = idade;
            Endereço = endereço;
        }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Endereço { get; set; }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("##  M E N U  ## ");
            Console.WriteLine("\n");
            Console.WriteLine("# Digite 1 para Adicionar um Usuário");
            Console.WriteLine("# Digite 2 para Exibir os Usuários");
            Console.WriteLine("# Digite 0 para sair");
            int opçãoSelecionada = Convert.ToInt32(Console.ReadLine());

            switch (opçãoSelecionada)
            {
                case 1:
                    AdicionarUsuario();
                    break;
                case 2:
                    ExibirUsuarios();
                    break;
                case 0: break;
            }
        }
            
        public void AdicionarUsuario()
        {
            
            
            
            Console.WriteLine("## ADICIONAR USUÁRIO ##");
            Console.WriteLine("\n");

            

            Console.WriteLine("Digite o Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\n");
            Console.WriteLine("Digite a Idade: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n");
            Console.WriteLine("Digite o endereço");
            string endereço = Console.ReadLine();

            Usuario usuario01 = new Usuario(nome, idade, endereço);
            //------Adicionar Usuario ao DataBase------------------
            try
            {
                //agora precisamos dar um jeito de adicionar o usuario solicitado no método em nosso connection.
                var connection = new Connection();
                
                connection.AdicionarUsuario(usuario01);
                //ok, isso resolve.
                Thread.Sleep(3000);
                Console.WriteLine("Dados do usuario adicionado com Sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           

            //---------------------------------------------------

            

            Thread.Sleep(10000);
            Menu();

        }

        public void ExibirUsuarios()
        {
            Console.Clear();
            Console.WriteLine("## EXIBIR USUARIOS ##");
            Console.WriteLine("\n");

            try
            {
                var connection = new Connection();
                var listaUsuario = connection.ListarUsuarios();

                foreach (var item in listaUsuario)
                {
                    Console.WriteLine($" Nome: {item.Nome}, idade: {item.Idade}, Endereço: {item.Endereço}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
