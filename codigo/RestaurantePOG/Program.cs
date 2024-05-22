using System;
using System.Collections.Generic;


namespace RestaurantePOG {
    public class Program{

    #region Variavel Global
    Restaurante restaurante = new Restaurante("POG - Comidinhas Veganas");
    #endregion

        static void Main(string[] args) {            
            bool continuar = true;
            int opcao;

            while(continuar) {
                ExibeMenuPrincipal();
                opcao = EscolheOpcao(1, 5);
                Console.Clear();
            
                switch(opcao) {
                    case 1:
                        CadastrarCliente();
                        break;
                    case 2:
                        AtenderCliente();
                        break;
                    case 3:
                        MostrarCardapio();
                        break;
                    case 4:
                        CadastrarItemCardapio();
                        break;
                    case 5:
                        continuar = false;
                        Console.WriteLine("Encerrando Programa...");
                        System.Threading.Thread.Sleep(500);
                        break;
                }
            }
        }

        /// <summary> Exibe o menu principal do restaurante </summary>
        public static void ExibeMenuPrincipal() {
            Console.WriteLine("==============================");
            Console.WriteLine("======= MENU PRINCIPAL ======="); 
            Console.WriteLine("==============================\n");
            Console.WriteLine("1 - Cadastrar Cliente");
            Console.WriteLine("2 - Atender Cliente");
            Console.WriteLine("3 - Mostrar Cardápio");
            Console.WriteLine("4 - Incluir Item no Cardápio");
            Console.WriteLine("5 - Encerrar Programa.\n");
        }

        /// <summary>Mostra Menu de Atendimento ao Cliente</summary>
        public static void ExibeMenuAtendimento() {
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
        private static int EscolheOpcao(int min, int max) {
            bool valido = false;
            int numero;

            while(!valido){
                numero = DigitaInteiro();
                if (numero >= min && numero <= max){ valido = true; }
            }
            return numero;    
        }

        /// <summary>Verifica se o um numero a ser digitado é inteiro. Repete o processo até conseguir um numero válido</summary>
        /// <returns>Retorna um numero inteiro válido</returns>
        private static int DigitaInteiro(){
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
        private static int DigitaDouble(){
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
        public static void CadastrarCliente() {
            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine();
            
            Console.Write("Insira a quantidade de pessoas: ");
            int qtdPessoas = DigitaInteiro();

            //Gera uma nova requisição de um novo cliente.
            Requisicao novaRequisicao = new Requisicao(nome, qtdPessoas);
            restaurante.AdicionarRequisicao(novaRequisicao);
            Console.WriteLine("\nCliente Cadastrado!");     
        }

        /// <summary>Realiza o atendimento do Cliente</summary>
        public static void AtenderCliente() { 
            List<Requisicao> emAtendimento = restaurante.ConsultarEmAtendimento();
            int opcao, contador = 1;
            bool valido = false;
            
            Console.WriteLine("Selecione o cliente que deseja atender: ");
            foreach(Requisicao requisicao in emAtendimento) {
                Console.WriteLine(contador + " - " + requisicao.Cliente.nome);
                contador++;
            }

            opcao = EscolheOpcao(1, emAtendimento.Count());
            Requisicao requisicao = emAtendimento[--opcao];

            Console.Clear();
            while(!valido){
                ExibeMenuAtendimento();
                opcao = EscolheOpcao(1, 3);

                switch(opcao) {
                    case 1:
                        RealizarPedido();
                        break;
                    case 2:
                        MostrarConta(requisicao);
                        break;
                    case 3:
                        FecharConta();
                        break;
                    case 4:
                        valido = false;
                        break;
                }
            }
        }

        /// <summary>Mostra o Cardápio do Restaurante</summary>
        public static void MostrarCardapio() { 
            List<Item> itensCardapio = restaurante.ConsultaItensCardapio();
            int contador = 1;

            foreach(Item item in itensCardapio) {
                Console.WriteLine(contador + " - " + itensCardapio.GetItemCardapio());
            }
        }

        /// <summary>Insere um novo Item no Cardapio</summary>
        public static void CadastrarItemCardapio() {
            Console.Write("Informe o nome do item que deseja adicionar: ");
            string nome = Console.ReadLine();
            
            Console.Write("Insira o preço unitário do item: ");
            int precoUnitario = DigitaDouble();

            //Gera um novo item e adiciona ao cardápio
            Item novoItem = new Item(nome, precoUnitario);
            restaurante.AdicionarItem(novoItem);
            Console.WriteLine("\nItem Adicionado ao Cardápio!");  
        }

        public static void RealizarPedido() {
            MostrarCardapio();
            
        }

        public static void MostrarConta(Requisicao requisicao) {

        }

        public static void FecharConta() {


        }
    }
}
