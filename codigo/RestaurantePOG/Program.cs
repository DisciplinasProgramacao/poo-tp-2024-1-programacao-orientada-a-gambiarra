using System;
using System.Console;
using System.Collections.Generic;


namespace RestaurantePOG {
    public class Program{

    #region Variavel Global
    //Restaurante restaurante = new Restaurante("POG - Comidinhas Veganas");
    static LinkedList<Cliente> clientes;
    #endregion

        static void Main(string[] args) {
            gerarClientes();
            bool continuar = true;
            int opcao;

            while(continuar) {
                exibeMenuPrincipal();
                opcao = escolheOpcao(1, 5);
                Console.Clear();
            
                switch(opcao) {
                    case 1:
                        cadastrarCliente();
                        break;
                    case 2:
                        atenderCliente();
                        break;
                    case 3:
                        mostrarCardapio();
                        break;
                    case 4:
                        cadastrarItemCardapio();
                        break;
                    case 5:
                        imprimirListaClientes();
                        break;
                    case 6:
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
            Console.WriteLine("2 - Atender Cliente");
            Console.WriteLine("3 - Mostrar Cardápio");
            Console.WriteLine("4 - Incluir Item no Cardápio");
            Console.WriteLine("5 - Exibir Lista de Clientes");
            Console.WriteLine("6 - Encerrar Programa.\n");
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
            int numero;

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
            string input;
            int inteiro;

            while(!valido){ 
                input = Console.ReadLine();
                numerico = int.TryParse(Console.ReadLine());
                if (numerico) { inteiro = int.Parse(input); valido = true; }
                else { Console.Write("Digite um valor valor válido: "); }
            }
            return inteiro;
        }

        /// <summary>Verifica se o um numero a ser digitado é do tipo double. Repete o processo até conseguir um numero válido</summary>
        /// <returns>Retorna um numero double válido</returns>
        private static int digitaDouble(){
            bool numerico, valido = false;
            string input;
            double real;

            while(!valido){ 
                input = Console.ReadLine();
                numerico = double.TryParse(Console.ReadLine());
                if (numerico) { real = double.Parse(input); valido = true; }
                else { Console.Write("Digite um valor valor válido: "); }
            }
            return real;
        }
        
        /// <summary>Realiza o Cadastro do cliente no restaurante</summary>
        public static void cadastrarCliente() {
            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine();
            
            Console.Write("Insira a quantidade de pessoas: ");
            int qtdPessoas = digitaInteiro();

            //Gera uma nova requisição de um novo cliente.
            Requisicao novaRequisicao = new Requisicao(nome, qtdPessoas);
            restaurante.AdicionarRequisicao(novaRequisicao);
            Console.WriteLine("\nCliente Cadastrado!");     
        }

        /// <summary>Realiza o atendimento do Cliente</summary>
        public static void atenderCliente() { 
            List<Requisicao> emAtendimento = restaurante.ConsultarEmAtendimento();
            int opcao, contador = 1;
            bool valido = false;

            Console.WriteLine("Selecione o cliente que deseja atender: ");
            foreach(Requisicao requisicao in emAtendimento) {
                Console.WriteLine(contador + " - " + requisicao.ToString());
                contador++;
            }

            opcao = escolheOpcao(1, emAtendimento.Count());
            Requisicao requisicao = emAtendimento[--opcao];

            Console.Clear();
            while(!valido){
                exibeMenuAtendimento();
                opcao = escolheOpcao(1, 3);

                switch(opcao) {
                    case 1:
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                        realizarPedido();
=======
                        RealizarPedido(requisicao);
>>>>>>> Stashed changes
=======
                        RealizarPedido(requisicao);
>>>>>>> Stashed changes
                        break;
                    case 2:
                        mostrarConta(requisicao);
                        break;
                    case 3:
<<<<<<< Updated upstream
<<<<<<< Updated upstream
                        fecharConta();
=======
                        FecharConta(requisicao);
>>>>>>> Stashed changes
=======
                        FecharConta(requisicao);
>>>>>>> Stashed changes
                        break;
                    case 4:
                        valido = false;
                        break;
                }
            }
        }

        /// <summary>Mostra o Cardápio do Restaurante</summary>
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public static void mostrarCardapio() { 
            List<Item> itensCardapio = restaurante.ConsultaItensCardapio();
=======
        public static void MostrarCardapio() { 
>>>>>>> Stashed changes
=======
        public static void MostrarCardapio() { 
>>>>>>> Stashed changes
            int contador = 1;

            foreach(Item item in restaurante.ConsultaItensCardapio()) {
                Console.WriteLine(contador + " - " + itensCardapio.GetItemCardapio());
            }
        }

        /// <summary>Insere um novo Item no Cardapio</summary>
        public static void cadastrarItemCardapio() {
            Console.Write("Informe o nome do item que deseja adicionar: ");
            string nome = Console.ReadLine();
            
            Console.Write("Insira o preço unitário do item: ");
            int precoUnitario = digitaDouble();

            //Gera um novo item e adiciona ao cardápio
            Item novoItem = new Item(nome, precoUnitario);
            restaurante.AdicionarItem(novoItem);
            Console.WriteLine("\nItem Adicionado ao Cardápio!");  
        }

<<<<<<< Updated upstream
<<<<<<< Updated upstream
        public static void realizarPedido() {
            mostrarCardapio();
            
        }

        public static void mostrarConta(Requisicao requisicao) {

        }

        public static void fecharConta() {


=======
        /// <summary>Registra um pedido na comanda da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se registrar um pedido</param>
        public static void RealizarPedido(Requisicao requisicao) {
            MostrarCardapio();
            ...
        }

        /// <summary>Monstra as informações da Conta da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se exibir as informações da conta</param>
        public static void MostrarConta(Requisicao requisicao) {
            Console.WriteLine("=============================");
            Console.WriteLine("===         CONTA         ==="); 
            Console.WriteLine("=============================");
            ...
            Console.WriteLine("=============================");
        }

=======
        /// <summary>Registra um pedido na comanda da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se registrar um pedido</param>
        public static void RealizarPedido(Requisicao requisicao) {
            MostrarCardapio();
            ...
        }

        /// <summary>Monstra as informações da Conta da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se exibir as informações da conta</param>
        public static void MostrarConta(Requisicao requisicao) {
            Console.WriteLine("=============================");
            Console.WriteLine("===         CONTA         ==="); 
            Console.WriteLine("=============================");
            ...
            Console.WriteLine("=============================");
        }

>>>>>>> Stashed changes
        /// <summary>Encerra o atendimento de um cliente e fecha a conta da requisição especificada </summary>
        /// <param name="requisicao">>Requisição que deseja-se fechar a conta</param>
        public static void FecharConta(Requisicao requisicao) {
            ...
<<<<<<< Updated upstream
>>>>>>> Stashed changes
        }
        /// <summary>
        /// Cria uma lista de clientes.
        /// </summary>
        static void gerarClientes() {
            
            String[] nomes = {"Rafael Bilu", "Zé Ivaldo","Lucas Silva", "Lucas Ramero"
                               , "Alvoro Barreal", "Matheus Pereira", "Juan Dinenno",
                                "Arthur Gomes", "Cássio" };

            foreach (String nome in nomes) {
                Cliente novo = new Cliente(nome);
                clientes.AddLast(novo);
            }
        }
        /// <summary>
        /// Imprimi uma lista de nomes dos clientes.
        /// </summary>
        private static void imprimirListaClientes() {
            foreach(Cliente cliente in clientes) {
                Console.WriteLine(clientes.ToString());
            }
=======
>>>>>>> Stashed changes
        }
    }
}
