using System;
using System.Collections.Generic;


namespace RestaurantePOG {
    public class Program{
        static void Main(string[] args) {

            #region Variáveis
            Restaurante restaurante = new Restaurante("POG - Comidinhas Veganas");
            bool continuar = true;
            int opcao;
            #endregion

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
                        IncluirItemCardapio();
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
            Console.WriteLine("1 - Cadastrar Cliente.");
            Console.WriteLine("2 - Atender Cliente.");
            Console.WriteLine("3 - Mostrar Cardápio");
            Console.WriteLine("4 - Incluir Item no Cardápio");
            Console.WriteLine("5 - Encerrar Programa.\n");
            
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

        public static void AtenderCliente() { 
            List<Requisicao> emAtendimento = restaurante.ConsultarEmAtendimento();
            int contador = 1;

            Console.WriteLine("Selecione o cliente que deseja atender: ");
            foreach(Requisicao requisicao in emAtendimento) {
                Console.WriteLine(contador + " - " + requisicao.Cliente.nome);
                contador++;
            }

            opcao = EscolheOpcao(1, emAtendimento.Count());
            Requisicao requisicao = emAtendimento[--opcao];
        }

        public static void MostrarCardapio() { 

        }

        public static void IncluirItemCardapio() {

        }
    }
}
