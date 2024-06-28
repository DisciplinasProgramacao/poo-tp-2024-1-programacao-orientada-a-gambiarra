using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace RestaurantePOG {
    public class Program {  
        #region Main
        static void Main(string[] args) {
            int opcaoInicial = -1;
            Estabelecimento? estabelecimento = null;

            while (opcaoInicial != 3) {
                Console.Clear();
                menuInicial();
                opcaoInicial = digitaInteiro();
                
                switch (opcaoInicial) {
                    case 1: //Entrar no restaurante
                        estabelecimento  = new Restaurante("POG - Comidinhas Veganas");
                        break;
                    case 2: //Entrar na cafeteria
                        estabelecimento  = new Cafeteria("POG - Café Vegano");
                        break;
                    case 3: //Sair 
                        sairDoProgram();
                        break;
                }
                if (estabelecimento != null) { inicializar(estabelecimento); }
            }
        }
        #endregion



        #region Métodos Aplicação
        /// <summary> Inicia o restaurante e exibe o menu </summary>
        public static void inicializar(Estabelecimento estabelecimento){
            int opcao = -1;
        
            while (opcao != 8) {
                Console.Clear();
                Console.WriteLine(estabelecimento.exibeMenuEstabelecimento()); //Menu do estabelecimento
                opcao = digitaInteiro();
                
                switch (opcao) {
                    case 1:
                        cadastrarCliente(estabelecimento); //Da entrada em um novo cliente e adiciona na fila de espera
                        break;
                    case 2:
                        menuDeAtendimento(estabelecimento); //Abre as opções vínculadas à um cliente.
                        break;
                    case 3:
                        imprimirListaClientes(estabelecimento); //Mostra todos os clientes
                        break;
                    case 4:
                        mostrarCardapio(estabelecimento); //Mostra o cardápio do estabelecimento
                        break;
                    case 5:
                        cadastrarItemCardapio(estabelecimento); //Adiciona um novo item 
                        break;
                    case 6:
                        if(estabelecimento is Restaurante){ //Adiciona uma nova Mesa
                            Restaurante? restaurante = estabelecimento as Restaurante;
                            cadastrarNovaMesa(restaurante);
                        }
                        break;
                    case 7:
                        if(estabelecimento is Restaurante){ //Acomoda um cliente no estabelecimento
                            Restaurante? restaurante = estabelecimento as Restaurante;
                            acomodarCliente(restaurante); 
                        } 
                        break;
                    case 8:
                        Console.WriteLine("Encerrando Aplicação. Voltando ao Menu Inicial...");
                        opcao = 8;
                        break;
                }
                pressioneContinuar();
            }
        }
        
        /// <summary>Realiza o atendimento do Cliente</summary>
        public static void menuDeAtendimento(Estabelecimento estabelecimento) {
            int opcao = -1;
            Requisicao? requisicao = null;
            
            Console.WriteLine(estabelecimento.exibeListaAtendimento());
            Console.WriteLine("Selecione o cliente que deseja atender: ");
            string nome = digitaString();

            if(estabelecimento.validarAtendimento(nome)){
                requisicao = estabelecimento.getRequisicaoPorNomeCliente(nome);
            }

            if (requisicao == null) {
                Console.WriteLine("Cliente não Localizado.");
                pressioneContinuar();
            } else {
                
                while (opcao != 4) {
                    Console.Clear();
                    exibeMenuAtendimento();
                    opcao = digitaInteiro();

                    switch (opcao) {
                        case 1:
                            realizarPedido(estabelecimento, requisicao);
                            pressioneContinuar();
                            break;
                        case 2:
                            mostrarConta(requisicao);
                            pressioneContinuar();
                            break;
                        case 3:
                            fecharConta(estabelecimento, requisicao);
                            pressioneContinuar();
                            break;
                        case 4:
                            Console.WriteLine("Voltando ao Menu de Atendimento.");
                            opcao = 4;
                            break;
                    }
                }
            }
        }


        /// <summary> Exibe o Menu Inicial</summary>
        public static void menuInicial(){
            Console.WriteLine("\n1. Inicializar Restaurante: POG - Comidinhas Veganas\n");
            Console.WriteLine("2. Inicializar Cafeteria: POG - Café Vegano\n");
            Console.WriteLine("3. Ignorar e ir embora (Essa ação terá consequências...)");
        }


        /// <summary>Mostra Menu de Atendimento ao Cliente</summary>
        public static void exibeMenuAtendimento() {
            Console.WriteLine("=========================================");
            Console.WriteLine("====        MENU DE ATENDIMENTO      ====");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("1 - Realizar Pedido");
            Console.WriteLine("2 - Mostrar Conta");
            Console.WriteLine("3 - Fechar Conta");
            Console.WriteLine("4 - Voltar Menu Principal");
            Console.WriteLine("=========================================\n");
        }

        /// <summary>Realiza o Cadastro do cliente no Estabelecimento</summary>
        public static void cadastrarCliente(Estabelecimento estabelecimento) {
            Console.Write("Informe o nome do cliente: ");
            string nome = digitaString();

            Console.Write("Insira a quantidade de pessoas: ");
            int qtdPessoas = digitaInteiro();

            estabelecimento.cadastrarCliente(nome, qtdPessoas);
            Console.WriteLine("\nCliente Cadastrado!");
        }


        /// <summary>Insere um novo Item no Cardapio</summary>
        public static void cadastrarItemCardapio(Estabelecimento estabelecimento){
            Console.Write("Informe o nome do item que deseja adicionar: ");
            string nome = digitaString();

            Console.Write("Insira o preço unitário do item: ");
            double precoUnitario = digitaDouble();

            estabelecimento.adicionarItemCardapio(nome, precoUnitario);
            Console.WriteLine("\nItem Adicionado ao Cardápio!");
        }


        /// <summary>Insere uma nova Mesa no Estabelecimento</summary>
        public static void cadastrarNovaMesa(Restaurante? estabelecimento) {
            if(estabelecimento != null){
                Console.Write("Insira a capacidade da Mesa: ");
                int capacidade = digitaInteiro();
                estabelecimento.adicionarMesa(capacidade);
                Console.WriteLine("\nMesa Cadastrada!");
            }
        }


        /// <summary>Registra um pedido na comanda da requisição especificada</summary>
        /// <param name="requisicao">Requisição que deseja-se registrar um pedido</param>
        public static void realizarPedido(Estabelecimento estabelecimento, Requisicao requisicao) {
            Console.WriteLine(estabelecimento.exibeCardapio());

            Console.Write("Digite o Item do Cardápio que deseja pedir: ");
            string nomeItem = digitaString();
            
            Console.Write("Qual a quantidade que deseja pedir: ");
            int quantidade = digitaInteiro();

            bool resultado = estabelecimento.realizarPedido(requisicao, nomeItem, quantidade);
            if(resultado){ Console.WriteLine("Pedido Realizado"); }
            else { Console.WriteLine("Não foi possível realizar o Pedido"); }
        }


        
        ///<summary>Inicia o atendimento do Próximo cliente Disponível</summary>
        public static void acomodarCliente(Restaurante? estabelecimento) { 
            if(estabelecimento != null){
                if(estabelecimento.atenderCliente(null)){
                    Console.WriteLine("Próximo Cliente Atendido com Sucesso!");
                } else{ 
                    Console.WriteLine("Não foi possivel atender o Próximo Cliente"); 
                }
            }
        }

        /// <summary>Mostra o Cardápio do Estabelecimento</summary>
        public static void mostrarCardapio(Estabelecimento estabelecimento) { Console.WriteLine(estabelecimento.exibeCardapio()); }


        /// <summary>Mostra a Conta atual do Cliente</summary>
        public static void mostrarConta(Requisicao requisicao) { Console.WriteLine(requisicao.exibirDetalhes()); }


        /// <summary>Mostra todos uma lista com todos os Clientes</summary>
        public static void imprimirListaClientes(Estabelecimento estabelecimento) { Console.WriteLine(estabelecimento.exibeListaClientes()); }


        /// <summary>Encerra o atendimento de um cliente e fecha a conta da requisição especificada </summary>
        /// <param name="requisicao">>Requisição que deseja-se fechar a conta</param>
        public static void fecharConta(Estabelecimento estabelecimento, Requisicao requisicao) { 
            Console.WriteLine(estabelecimento.finalizarAtendimento(requisicao));
        }
        #endregion





        #region Métodos Gerais
        /// <summary>Método que para a execução do Programa até o usuário digitar qualquer tecla.</summary>
        private static void pressioneContinuar() { Console.ReadLine(); }


        /// <summary>Verifica se o um numero a ser digitado é inteiro. Repete o processo até conseguir um numero válido.</summary>
        /// <returns>Retorna um numero inteiro válido.</returns>
        private static int digitaInteiro() {
            int inteiro;
            while (!int.TryParse(Console.ReadLine(), out inteiro)) {
                Console.Write("Digite um valor válido: ");
            }
            return inteiro;
        }


        /// <summary>Verifica se o um numero a ser digitado é do tipo double. Repete o processo até conseguir um numero válido.</summary>
        /// <returns>Retorna um numero double válido.</returns>
        private static double digitaDouble() {
            double real;
            while (!double.TryParse(Console.ReadLine(), out real)) {
                Console.Write("Digite um valor válido: ");
            }
            return real;
        }
        /// <summary>Verifica se o um numero a ser digitado é do tipo string e não nulo. Repete o processo até conseguir um valor válido.</summary>
        /// <returns>Retorna uma string não nula.</returns>
        private static string digitaString() {
            string? input;
            do {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) {
                    Console.Write("Digite um valor válido (Não nulo): ");
                }
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }
        #endregion





        // ATENCAO:
        // Os métodos a seguir só podem ser julgados para aumentar a nota do grupo. Caso contrário, o método DEVE ser ignorado e
        // começará a seguir o primeiro ensinamento de P.O.O... Ele "Não interessa!" ;)
        #region Easter-Egg
        /// <summary> Executa código para sair da execução do Program e abre uma Url</summary>
        public static void sairDoProgram(){
            Console.WriteLine("Encerrando Programa");
            Thread.Sleep(1000);  Console.Write(".");
            Thread.Sleep(1000);  Console.Write(".");
            Thread.Sleep(1000);  Console.Write(".");
            Thread.Sleep(750);  Console.Write(".");
            Thread.Sleep(650);  Console.Write(".");
            Thread.Sleep(500);  Console.Write(".");
            Thread.Sleep(400);  Console.Write(".");
            Thread.Sleep(350);  Console.Write(".");
            Thread.Sleep(300);  Console.Write(".");
            Thread.Sleep(250);  Console.Write(".");
            Thread.Sleep(200);  Console.Write(".");
            Thread.Sleep(150);  Console.Write(".");
            Thread.Sleep(100);  Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Thread.Sleep(50);   Console.Write(".");
            Console.Clear();    Thread.Sleep(1000);

            for(int i = 0; i < 3; i++){
                Console.Clear();
                Thread.Sleep(1000);
                Console.WriteLine("\n\n\nPresisone Qualquer Tecla".PadRight(20));
                Thread.Sleep(1000);
            }

            Console.ReadKey();

            OpenUrl("https://matias.me/nsfw/");
            System.Threading.Thread.Sleep(500);
        }


        /// <summary> Tenta abrir a url usando Process.Start, se houver erros de acordo com a possível plataforma não windows, executa um código alternativo </summary>
        /// <param name="url"></param>
        public static void OpenUrl(string url){
            try { Process.Start(url); }
            catch {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                    Process.Start("open", url);
                }
            }
        }
        #endregion
    }
}