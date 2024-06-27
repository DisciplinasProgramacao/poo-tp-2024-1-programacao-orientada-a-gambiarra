using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
/*

namespace RestaurantePOG
{
    public class AppCafeteria
    {

        #region Global
        public static Estabelecimento restaurante = new Restaurante("POG - Restaurante Comidinhas Veganas");
        public static Estabelecimento cafeteria = new Cafeteria("POG - Cafeteria Comidinhas Veganas");

        #endregion

        static void Main(string[] args)
        {
            int opcao = -1;

            while (opcao != 3)
            {
                exibeMenuInicial();
                opcao = digitaInteiro();

                switch (opcao)
                {
                    case 1:
                        menuDaCafeteria();
                        break;
                    case 2:
                        // menuDoRestaurante();
                        break;
                }
            }


        }
        public static void exibeMenuInicial()
        {
            
            Console.WriteLine("=========================================");
            Console.WriteLine("====    ESCOLHA O ESTABELECIMENTO    ====");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("1 - Cafeteria POG");
            Console.WriteLine("2 - Restaurante POG");
            Console.WriteLine("3 - Encerrar Programa.");
            Console.WriteLine("=========================================\n");
        }

        #region Cafeteria

        public static void exibirMenuDaCafeteria()
        {
            limparTela();
            Console.WriteLine("==========================================");
            Console.WriteLine("=====          MENU PRINCIPAL         ====");
            Console.WriteLine("==========================================\n");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Atender Cliente");
            Console.WriteLine("3 - Mostrar Cardápio");
            Console.WriteLine("4 - Exibir Lista de clientes");
            Console.WriteLine("5 - Exibir Lista de requisições");
            Console.WriteLine("6 - Encerrar Programa.");
            Console.WriteLine("==========================================\n");
        }
        public static void menuDaCafeteria()
        {
            int opcao = -1;

            cafeteria.gerarCardapio(cardapioInicialCafeteria());

            while (opcao != 6) {

                exibirMenuDaCafeteria();
                opcao = digitaInteiro(); ;
                //Console.Clear();

                switch (opcao)
                {
                    case 1:
                        cadastrarClienteCafeteria(); //Da entrada em um novo cliente e adiciona na fila de espera
                        
                        break;
                    case 2:
                        menuDoClienteCafeteria();
                        pressioneContinuar();
                        break;
                    case 3:
                        limparTela();
                        Console.WriteLine(cafeteria.exibeCardapio()); //Mostra o cardápio do restaurante
                        pressioneContinuar();
                        break;
                    case 4:
                        Console.WriteLine(cafeteria.exibeListaClientes()); //Mostra todos os clientes
                        pressioneContinuar();
                        break;
                    case 5:
                        Console.WriteLine(cafeteria.exibeListaAtendimento());
                        pressioneContinuar();
                        break;
                    case 6:
                        Console.WriteLine("Encerrando Programa...");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }
        private static Cardapio cardapioInicialCafeteria()
        {
            return new Cardapio().adicionarItem("Não de queijo", 5.0d)
                                 .adicionarItem("Bolinha de cogumelo", 7.0d)
                                 .adicionarItem("Rissole de palmito", 7.0d)
                                 .adicionarItem("Coxinha de carne de jaca", 8.0d)
                                 .adicionarItem("Fatia de queijo de caju", 9.0d)
                                 .adicionarItem("Biscoito amanteigado", 3.0d)
                                 .adicionarItem("Cheesecake de frutas vermelhas", 15.0d)
                                 //==========================================================//
                                 .adicionarItem("Água", 3.0d)
                                 .adicionarItem("Copo de suco", 7.0d)
                                 .adicionarItem("Café espresso orgânico", 6.0d);

        }
        public static void cadastrarClienteCafeteria() {
            Console.Write("Informe o nome do cliente: ");
            string nome = digitaString();
            cafeteria.cadastrarCliente(nome, 1);
            Console.WriteLine("\nCliente Cadastrado!");
            pressioneContinuar();
        }
        /// <summary>Realiza o atendimento do Cliente</summary>
        public static void menuDoClienteCafeteria()
        {
            int opcao = -1;

            Console.WriteLine("Selecione o cliente que deseja atender: ");
            Requisicao? requisicao = cafeteria.buscarRequisicaoPorCliente(digitaString());

            if (requisicao == null)
            {
                Console.WriteLine("Cliente não Localizado.");
                pressioneContinuar();
            }
            else
            {
                Console.Clear();
                while (opcao != 4)
                {
                    exibeMenuAtendimento();
                    opcao = digitaInteiro();

                    switch (opcao)
                    {
                        case 1:
                            realizarPedidoCafeteria(requisicao);
                            break;
                        case 2:
                            mostrarConta(requisicao);
                            pressioneContinuar();
                            break;
                        case 3:
                            fecharConta(requisicao);
                            pressioneContinuar();
                            break;
                    }
                }
            }
        }

        public static void realizarPedidoCafeteria(Requisicao requisicao)
        {
            Console.WriteLine(cafeteria.exibeCardapio());
            Console.Write("Digite o Item do Cardápio que deseja pedir: ");
            String item = digitaString();
            Console.Write("Qual a quantidade: ");
            int quant = digitaInteiro();

            cafeteria.realizarPedido(requisicao, item, quant);

        }

        public static void exibeMenuAtendimento()
        {
            limparTela();
            Console.WriteLine("=========================================");
            Console.WriteLine("====        MENU DE ATENDIMENTO      ====");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("1 - Realizar Pedido.");
            Console.WriteLine("2 - Mostrar Conta");
            Console.WriteLine("3 - Fechar Conta");
            Console.WriteLine("4 - Voltar Menu Principal");
            Console.WriteLine("=========================================\n");
        }
        /// <summary>Mostra a Conta atual do Cliente</summary>
        public static void mostrarConta(Requisicao requisicao)
        {
            limparTela();
            Console.WriteLine("=========================================");
            Console.WriteLine("====              CONTA              ====");
            Console.WriteLine("=========================================");
            Console.WriteLine(requisicao.exibirDetalhes());
            Console.WriteLine("=========================================");
        }

        /// <summary>Encerra o atendimento de um cliente e fecha a conta da requisição especificada </summary>
        /// <param name="requisicao">>Requisição que deseja-se fechar a conta</param>
        public static void fecharConta(Requisicao requisicao)
        {
            limparTela();
            Console.WriteLine("=========================================");
            Console.WriteLine("====          FECHAR CONTA           ====");
            Console.WriteLine("=========================================");
            Console.WriteLine(cafeteria.finalizarAtendimento(requisicao));
            Console.WriteLine("=========================================");


        }

        #endregion

        #region Métodos Gerais

        /// <summary>Método que para a execução do Programa até o usuário digitar qualquer tecla.</summary>
        private static void pressioneContinuar() { Console.WriteLine("Precione para continuar..."); Console.ReadLine(); }


        /// <summary>Verifica se o um numero a ser digitado é inteiro. Repete o processo até conseguir um numero válido.</summary>
        /// <returns>Retorna um numero inteiro válido.</returns>
        private static int digitaInteiro()
        {
            int inteiro;
            while (!int.TryParse(Console.ReadLine(), out inteiro))
            {
                Console.Write("Digite um valor válido: ");
            }
            return inteiro;
        }


        /// <summary>Verifica se o um numero a ser digitado é do tipo double. Repete o processo até conseguir um numero válido.</summary>
        /// <returns>Retorna um numero double válido.</returns>
        private static double digitaDouble()
        {
            double real;
            while (!double.TryParse(Console.ReadLine(), out real))
            {
                Console.Write("Digite um valor válido: ");
            }
            return real;
        }


        /// <summary>Verifica se o um numero a ser digitado é do tipo string e não nulo. Repete o processo até conseguir um valor válido.</summary>
        /// <returns>Retorna uma string não nula.</returns>
        private static string digitaString()
        {
            string? input;

            do
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Digite um valor válido (Não nulo): ");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        /// <summary>
        /// Limpa tela do console.
        /// </summary>
        public static void limparTela()
        {
            Console.Clear();
        }

        #endregion
    }
}
*/