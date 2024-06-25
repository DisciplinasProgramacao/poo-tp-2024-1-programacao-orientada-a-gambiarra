using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace RestaurantePOG
{
    public class Program
    {
        #region Global
        public static Estabelecimento restaurante = new Restaurante("POG - Comidinhas Veganas");
        public static Estabelecimento cafeteria = new Cafeteria("POG - Café Vegano");
        #endregion
        static void Main(string[] args)
        {
            menuInicial();
            int opcaoInicial = -1;
            while (opcaoInicial != 3)
            {
                opcaoInicial = digitaInteiro();
                switch (opcaoInicial)
                {
                    case 1: //Entrar no restaurante
                        iniciarRestaurante();
                        int opcao = -1;
                        while (opcao != 8)
                        {
                            exibeMenuPrincipalR(); //Menu do Restaurante
                            opcao = digitaInteiro();
                            switch (opcao)
                            {
                                case 1:
                                    cadastrarCliente(); //Da entrada em um novo cliente e adiciona na fila de espera
                                    break;
                                case 2:
                                    acomodarCliente(); //Acomoda um cliente no restaurante
                                    break;
                                case 3:
                                    menuDoCliente(); //Abre as opções vínculadas à um cliente.
                                    break;
                                case 4:
                                    mostrarCardapio(); //Mostra o cardápio do restaurante
                                    break;
                                case 5:
                                    cadastrarItemCardapio(); //Adiciona um novo item 
                                    break;
                                case 6:
                                    cadastrarNovaMesa(); //Adiciona uma nova Mesa
                                    break;
                                case 7:
                                    imprimirListaClientes(); //Mostra todos os clientes
                                    break;
                                case 8:
                                    Console.WriteLine("Voltando para a rua.");
                                    Console.ReadKey();
                                    opcao = 8;
                                    break;
                            }
                        }
                        break;
                    case 2: //Entrar na cafeteria
                        iniciarCafeteria();
                        int opcao2 = -1;
                        while (opcao2 != 6)
                        {
                            exibeMenuPrincipalC(); //Menu da Cafeteria
                            opcao2 = digitaInteiro();
                            switch (opcao2)
                            {
                                case 1: //cadastrar cliente
                                    break;
                                case 2: //atender cliente
                                    break;
                                case 3: //mostrar cardapio
                                    break;
                                case 4: //incluir item no cardapio
                                    break;
                                case 5: //exibir lista clientes
                                    break;
                                case 6:
                                    Console.WriteLine("Voltando para a rua.");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        break;
                    case 3: //Sair
                        Console.WriteLine("Encerrando Programa...");
                        Console.ReadKey();
                        System.Diagnostics.Process.Start("https://matias.me/nsfw/");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }
        #region Métodos Restaurante
        //Inicializador Restaurante
        public static void iniciarRestaurante()
        {
            Console.Clear();
            restaurante.gerarCardapio(cardapioInicialRestaurante());
            restaurante.gerarMesas(mesasInicialRestaurante());
        }
        /// <summary>Realiza o atendimento do Cliente</summary>
        public static void menuDoCliente()
        {
            int opcao = -1;
            restaurante.exibeListaAtendimento();
            Console.WriteLine("Selecione o cliente que deseja atender: ");
            Requisicao? requisicao = restaurante.getRequisicaoPorCliente(new Cliente(digitaString()));
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
                            realizarPedido(requisicao);
                            break;
                        case 2:
                            mostrarConta(requisicao);
                            break;
                        case 3:
                            fecharConta(requisicao);
                            break;
                    }
                }
            }
        }
        /// <summary> Exibe o menu principal do restaurante </summary>
        public static void exibeMenuPrincipalR()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("====          MENU PRINCIPAL         ====");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Acomodar um Cliente");
            Console.WriteLine("3 - Atender um Cliente");
            Console.WriteLine("4 - Mostrar Cardápio");
            Console.WriteLine("5 - Incluir Item no Cardápio");
            Console.WriteLine("6 - Incluir uma nova Mesa");
            Console.WriteLine("7 - Exibir Lista de Clientes");
            Console.WriteLine("8 - Encerrar Programa.");
            Console.WriteLine("=========================================\n");
        }

        /// <summary>Mostra Menu de Atendimento ao Cliente</summary>
        public static void exibeMenuAtendimento()
        {
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
            Console.WriteLine("=========================================");
            Console.WriteLine("====              CONTA              ====");
            Console.WriteLine("=========================================");
            Console.WriteLine(requisicao.exibirDetalhes());
            Console.WriteLine("=========================================");
        }

        /// <summary>Gera o Cardápio Inicial do Restaurante.</summary>
        /// <returns>Retorna um Objeto do tipo Cardápio com Itens já adicionados.</returns>
        private static Cardapio cardapioInicialRestaurante()
        {
            return new Cardapio().adicionarItem("Moqueca de Palmito", 32.0)
                                 .adicionarItem("Falafel Assado", 20.0)
                                 .adicionarItem("Salada Primavera com Macarrão Konjac", 25.0)
                                 .adicionarItem("Escondidinho de Inhame", 18.0)
                                 .adicionarItem("Strogonoff de Cogumelos", 35.0)
                                 .adicionarItem("Caçarola de legumes", 22.0)
                                 //==========================================================//
                                 .adicionarItem("Água", 3.0)
                                 .adicionarItem("Copo de suco", 7.0)
                                 .adicionarItem("Refrigerante orgânico", 7.0)
                                 .adicionarItem("Cerveja vegana", 9.0)
                                 .adicionarItem("Taça de vinho vegano", 18.0);
        }
        /// <summary>Gera uma Lista de Mesas Iniciais do Restaurante</summary>
        /// <returns>Retorna um Objeto do tipo List<Mesa>.</returns>
        private static List<Mesa> mesasInicialRestaurante()
        {
            return new List<Mesa> { new Mesa(4), new Mesa(4), new Mesa(4), new Mesa(4),
                                    new Mesa(6), new Mesa(6), new Mesa(6), new Mesa(6),
                                    new Mesa(8), new Mesa(8) };
        }
        /// <summary>Realiza o Cadastro do cliente no Estabelecimento</summary>
        public static void cadastrarCliente()
        {
            Console.Clear();
            Console.Write("Informe o nome do cliente: ");
            string nome = digitaString();
            Console.Write("Insira a quantidade de pessoas: ");
            int qtdPessoas = digitaInteiro();
            restaurante.cadastrarCliente(nome, qtdPessoas);
            Console.WriteLine("\nCliente Cadastrado!");
        }
        /// <summary>Insere um novo Item no Cardapio</summary>
        public static void cadastrarItemCardapio()
        {
            Console.Clear();
            Console.Write("Informe o nome do item que deseja adicionar: ");
            string nome = digitaString();
            Console.Write("Insira o preço unitário do item: ");
            double precoUnitario = digitaDouble();
            restaurante.adicionarItemCardapio(nome, precoUnitario);
            Console.WriteLine("\nItem Adicionado ao Cardápio!");
        }
        /// <summary>Insere uma nova Mesa no Estabelecimento</summary>
        public static void cadastrarNovaMesa()
        {
            Console.Clear();
            Console.Write("Insira a capacidade da Meaa: ");
            int qtdPessoas = digitaInteiro();
            restaurante.adicionarMesa(qtdPessoas);
            Console.WriteLine("\nMesa Cadastrada!");
        }
        /// <summary>Registra um pedido na comanda da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se registrar um pedido</param>
        public static void realizarPedidoCafeteria(Requisicao requisicao)
        {
            Console.WriteLine(restaurante.exibeCardapio());
            Console.Write("Digite o Item do Cardápio que deseja pedir: ");
            String item = digitaString();
            Console.Write("Qual a quantidade: ");
            int quant = digitaInteiro();
            restaurante.realizarPedido(requisicao, item, quant);
        }
        ///<summary>Inicia o atendimento do Próximo cliente Disponível</summary>
        public static void acomodarCliente() { restaurante.atenderCliente(); }
        /// <summary>Mostra o Cardápio do Estabelecimento</summary>
        public static void mostrarCardapio() { Console.WriteLine(restaurante.exibeCardapio()); }
        /// <summary>Mostra todos uma lista com todos os Clientes</summary>
        public static void imprimirListaClientes() { Console.WriteLine(restaurante.exibeListaClientes()); }
        /// <summary>Encerra o atendimento de um cliente e fecha a conta da requisição especificada </summary>
        /// <param name="requisicao">>Requisição que deseja-se fechar a conta</param>
        public static void fecharConta(Requisicao requisicao) { restaurante.finalizarAtendimento(requisicao); }
        #endregion

        #region Métodos Cafeteria
        //Inicializador Cafeteria
        public static void iniciarCafeteria()
        {
            Console.Clear();
            cafeteria.gerarCardapio(cardapioInicialCafeteria());
            cafeteria.gerarMesas(mesasInicialCafeteria());
        }
        /// <summary> Exibe o menu principal da cafeteria </summary>
        public static void exibeMenuPrincipalC()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("====          MENU PRINCIPAL         ====");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Atender um Cliente");
            Console.WriteLine("3 - Mostrar Cardápio");
            Console.WriteLine("4 - Incluir Item no Cardápio");
            Console.WriteLine("5 - Exibir Lista de Clientes");
            Console.WriteLine("6 - Encerrar Programa.");
            Console.WriteLine("=========================================\n");
        }
        /// <summary>Gera o Cardápio Inicial da Cafeteria.</summary>
        /// <returns>Retorna um Objeto do tipo Cardápio com Itens já adicionados.</returns>
        private static Cardapio cardapioInicialCafeteria()
        {
            return new Cardapio().adicionarItem("Não de queijo", 5.0)
                                 .adicionarItem("Bolinha de cogumelo", 7.0)
                                 .adicionarItem("Rissole de palmito", 7.0)
                                 .adicionarItem("Coxinha de carne de jaca", 8.0)
                                 .adicionarItem("Fatia de Queijo de caju", 9.0)
                                 .adicionarItem("Biscoito amanteigado", 3.0)
                                 .adicionarItem("Cheesecake de frutas vermelhas", 15.0)
                                 //==========================================================//
                                 .adicionarItem("Água", 3.0)
                                 .adicionarItem("Copo de suco", 7.0)
                                 .adicionarItem("café expresso vegano", 15.0);
        }
        private static List<Mesa> mesasInicialCafeteria()
        {
            return new List<Mesa> { }; //em processo
        }
        #endregion
        #region Métodos Gerais
        /// <summary> Método para o menu inicial de escolha de estabelecimentos </summary>
        public static void menuInicial()
        {
            Console.WriteLine("1. Entrar no restaurante: POG - Comidinhas Veganas");
            Console.WriteLine("2. Entrar na cafeteria: POG - Café Vegano");
            Console.WriteLine("3. Ignorar e ir embora...\n(Essa ação terá consequências...)");
        }
        /// <summary>Método que para a execução do Programa até o usuário digitar qualquer tecla.</summary>
        private static void pressioneContinuar() { Console.ReadLine(); }
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
        #endregion
    }
}