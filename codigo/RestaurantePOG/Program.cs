using System;
using System.Collections.Generic;


namespace RestaurantePOG {
    public class Program{

    #region Variavel Global
    public static Restaurante restaurante = new("POG - Comidinhas Veganas");
    
    
    #endregion

        static void Main(string[] args) {
            Cardapio cardapio = new Cardapio();
            cardapio.gerarItens();
            bool continuar = true;
            int opcao;

            while(continuar) {
                exibeMenuPrincipal();
                opcao = escolheOpcao(1, 7);
                Console.Clear();
            
                switch(opcao) {
                    case 1:
                        cadastrarCliente(); //Da entrada em um novo cliente e adiciona na fila de espera
                        break;
                    case 2:
                        iniciaAtendimento(); //Tentar atender um sujeito
                        break;
                    case 3:
                        atenderCliente(); //Registrar um pedido de um sujeito em atendimento
                        break;
                    case 4:
                        mostrarCardapio(); //Mostra o cardápio do restaurante
                        break;
                    case 5:
                        cadastrarItemCardapio(); //Adiciona um novo item 
                        break;
                    case 6:
                        imprimirListaClientes();
                        break;
                    case 7:
                        continuar = false;
                        Console.WriteLine("Encerrando Programa...");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }

        /// <summary> Exibe o menu principal do restaurante </summary>
        public static void exibeMenuPrincipal() {
            Console.WriteLine("==============================");
            Console.WriteLine("======= MENU PRINCIPAL ======="); 
            Console.WriteLine("==============================\n");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Iniciar Atendimento");
            Console.WriteLine("3 - Atender Cliente");
            Console.WriteLine("4 - Mostrar Cardápio");
            Console.WriteLine("5 - Incluir Item no Cardápio");
            Console.WriteLine("6 - Exibir Lista de Clientes");
            Console.WriteLine("7 - Encerrar Programa.\n");
        }

        /// <summary>Mostra Menu de Atendimento ao Cliente</summary>
        public static void exibeMenuAtendimento() {
            Console.WriteLine("==============================");
            Console.WriteLine("====== MENU ATENDIMENTO ======"); 
            Console.WriteLine("==============================\n");
            Console.WriteLine("1 - Realizar Pedido.");
            Console.WriteLine("2 - Mostrar Conta");
            Console.WriteLine("3 - Fechar Conta");
            Console.WriteLine("4 - Voltar Menu Principal");
        }

        /// <summary>Método que solicita que o usuário digite um valor numérico e verifica se o mesmo é um valor que está dentro de um intervalo especificado</summary>
        /// <param name="min">Valor mínimo dentro do intervalo</param>
        /// <param name="max">Valor maximo dentro do intervalo</param>
        /// <returns>retorna a opçãpo selecionada em um numero inteiro</returns>
        private static int escolheOpcao(int min, int max) {
            bool valido = false;
            int numero = 0;

            while(!valido){
                numero = digitaInteiro();
                if (numero >= min && numero <= max){ valido = true; }
            }
            return numero;    
        }

        /// <summary>Verifica se o um numero a ser digitado é inteiro. Repete o processo até conseguir um numero válido</summary>
        /// <returns>Retorna um numero inteiro válido</returns>
        private static int digitaInteiro(){
            bool numerico, valido = false;
            int inteiro = 0;
            string? input;
            
            while(!valido){ 
                input = Console.ReadLine();
                numerico = int.TryParse(input, out inteiro);
                if (numerico) { valido = true; }
                else { Console.Write("Digite um valor valor válido: "); }
            }
            return inteiro;
        }

        /// <summary>Verifica se o um numero a ser digitado é do tipo double. Repete o processo até conseguir um numero válido</summary>
        /// <returns>Retorna um numero double válido</returns>
        private static double digitaDouble(){
            bool numerico, valido = false;
            double real = 0.00;
            string? input;

            while(!valido){ 
                input = Console.ReadLine();
                numerico = double.TryParse(input, out real);
                if (numerico) { valido = true; }
                else { Console.Write("Digite um valor valor válido: "); }
            }
            return real;
        }
        
        /// <summary>Realiza o Cadastro do cliente no restaurante</summary>
        public static void cadastrarCliente() {
            Console.Write("Informe o nome do cliente: ");
            string? nome = Console.ReadLine();
            
            Console.Write("Insira a quantidade de pessoas: ");
            int qtdPessoas = digitaInteiro();

            //Gera uma nova requisição de um novo cliente.
            Requisicao novaRequisicao = new(nome, qtdPessoas);
            restaurante.adicionarRequisicao(novaRequisicao);
            restaurante.adicionaFilaEspera(novaRequisicao);
            Console.WriteLine("\nCliente Cadastrado!");
        }

        /// <summary>Muda o status de um cliente na Fila de espera para um cliente em atendimento (Associa uma mesa, registra Hora e muda o status)</summary>
        public static void iniciaAtendimento(){
            bool valido = false;
            int opcao;

            Console.WriteLine(restaurante.exibeListaEspera());
            Console.WriteLine("Selecione o Cliente que deseja atender: ");
            opcao = escolheOpcao(1, restaurante.getTamanhoLista("Espera"));
            
            Requisicao requisicao = restaurante.getRequisicao(--opcao);

            valido = restaurante.estahAptoAtendimento(requisicao);

            if (valido){ restaurante.atenderCliente(requisicao); }
            else { Console.WriteLine("Não é possível atender esse cliente."); }
        }

        /// <summary>Realiza o atendimento do Cliente</summary>
        public static void atenderCliente() { 
            bool valido = false;
            int opcao;

            Console.WriteLine("Selecione o cliente que deseja atender: ");
            restaurante.exibeListaAtendimento();
            opcao = escolheOpcao(1, restaurante.getTamanhoLista("Atendimento"));
            
            Requisicao requisicao = restaurante.getRequisicao(--opcao);

            Console.Clear();
            while(!valido){
                exibeMenuAtendimento();
                opcao = escolheOpcao(1, 4);

                switch(opcao) {
                    case 1:
                        realizarPedido(requisicao);
                        break;
                    case 2:
                        mostrarConta(requisicao);
                        break;
                    case 3:
                        fecharConta(requisicao);
                        break;
                    case 4:
                        valido = false;
                        break;
                }
            }
        }

        /// <summary>Mostra o Cardápio do Restaurante</summary>
        public static void mostrarCardapio() { Console.WriteLine(restaurante.exibeCardapio()); }

        public static void imprimirListaClientes(){ Console.WriteLine(restaurante.exibeListaClientes()); }

        /// <summary>Insere um novo Item no Cardapio</summary>
        public static void cadastrarItemCardapio() {
            Console.Write("Informe o nome do item que deseja adicionar: ");
            string? nome = Console.ReadLine();
            
            Console.Write("Insira o preço unitário do item: ");
            double precoUnitario = digitaDouble();

            //Gera um novo item e adiciona ao cardápio
            Item novoItem = new(nome, precoUnitario);
            restaurante.adicionarItem(novoItem);
            Console.WriteLine("\nItem Adicionado ao Cardápio!");  
        }

        /// <summary>Registra um pedido na comanda da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se registrar um pedido</param>
        public static void realizarPedido(Requisicao requisicao) {
            int opcaoCardapio;

            Console.WriteLine(restaurante.exibeCardapio());
            Console.Write("Digite o Item do Cardápio que deseja pedir: ");
            opcaoCardapio = escolheOpcao(1, restaurante.getTamanhoLista("Cardapio"));

            restaurante.realizarPedido(requisicao, opcaoCardapio);
        }

        /// <summary>Monstra as informações da Conta da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se exibir as informações da conta</param>
        public static void mostrarConta(Requisicao requisicao) {
            Console.WriteLine("=============================");
            Console.WriteLine("===         CONTA         ==="); 
            Console.WriteLine("=============================");
             Console.WriteLine(requisicao.exibirDetalhes());
            Console.WriteLine("=============================");
        }

        /// <summary>Encerra o atendimento de um cliente e fecha a conta da requisição especificada </summary>
        /// <param name="requisicao">>Requisição que deseja-se fechar a conta</param>
        public static void fecharConta(Requisicao requisicao) {
            restaurante.finalizarAtendimento(requisicao);
        }
    }
}
