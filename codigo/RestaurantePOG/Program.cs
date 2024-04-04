using System;
using System.Collections.Generic;

namespace RestaurantePOG
{
    public class Program
    {
        #region Região de Variáveis Globais
        static List<Cliente> clientes = new List<Cliente>();
        #endregion

        #region Região dos Métodos do Menu

        /// <summary>
        /// Cadastra cliente em uma lista.
        /// </summary>
        public static void cadastrarCliente()
        {
         
            Console.Write("Favor inserir o nome do cliente: ");
            string nome = Console.ReadLine();

            
            Console.Write("A reserva é para quantas pessoas? ");
            int quantPessoa = int.Parse(Console.ReadLine());

            // Se o usuário inserir um número válido, cria um novo cliente.
            Cliente cliente = new Cliente(nome, quantPessoa);
            clientes.Add(cliente);

            // Exibe as informações do cliente cadastrado na lista criada.
            Console.WriteLine("\n!!!Cliente Cadastrado!!!\n");
            Console.WriteLine(cliente.ToString() + "\n");
           
        }
        /// <summary>
        /// Imprimi a lista de clientes
        /// </summary>
        public static void listarClientes()
        {
            // Usa Stream para Ordena a lista de clientes pelo ID em ordem crescente através do Sort
            clientes.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));

            // Exibe os clientes ordenados
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine(cliente.ToString());
            }
        }

        /// <summary>
        /// Imprimi o menu do restaurante.
        /// </summary>
        /// <returns></returns>
        public static int opMenu()
        {

            Console.WriteLine("======= MENU =======");
            Console.WriteLine("1 - Cadastrar Cliente.");
            Console.WriteLine("2 - Exibir lista de clientes.");
            Console.WriteLine("3 - Sair do programa.");
            
            return int.Parse(Console.ReadLine()); ;

        }

        #endregion

        static void Main(string[] args)
        {
            int op =0;

            do { 
                op = opMenu();
                switch (op) {
                    case 1:
                        cadastrarCliente();
                        break;
                    case 2:
                        Console.WriteLine("==== Lista de Clientes ====");
                        listarClientes();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("Programa Encerrado...");
                        break;
                }
            } while (op != 3);

        }
    }
}
