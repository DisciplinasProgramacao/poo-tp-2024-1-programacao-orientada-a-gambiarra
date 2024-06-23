using System;
using System.Text;

namespace RestaurantePOG { 

    /// <summary>
    /// Classe representando a fila de espera do restaurante
    /// </summary>
    public class FilaEspera {
        private LinkedList<Requisicao> requisicoes;

        /// <summary>
        /// Construtor padrão da classe FilaEspera
        /// </summary>
        public FilaEspera() {
            requisicoes = new LinkedList<Requisicao>();
        }

        /// <summary>
        /// Método para adicionar uma requisição à fila de espera.
        /// </summary>
        /// <param name="req">Cliente a ser adicionado à fila</param>
        public void addRequisicao(Requisicao req) {
            requisicoes.AddFirst(req);
        }

        /// <summary>
        /// Método para remover e retornar o próximo cliente da fila de espera
        /// </summary>
        /// <returns>Próximo cliente da fila</returns>
        public Requisicao atenderProximoCliente(int quantPessoas) {
            try {
                Requisicao req = requisicoes.FirstOrDefault(req => req.getQuantidadePessoas() == quantPessoas);
                removerRequisicao(req);
                return req;
            }
            catch {
                return null;
            }
            
        }
        /// <summary>
        /// Método para remover as requisições.
        /// </summary>
        /// <param name="requisicao"></param>
        public void removerRequisicao (Requisicao requisicao) { 
            requisicoes.Remove(requisicao);
        }
        /// <summary>
        /// imprimi a lista de requisições ordenado pela demanda de pessoas da requisição.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            StringBuilder aux = new StringBuilder();
            foreach (var requisicao in requisicoes.OrderBy(req => req.getQuantidadePessoas())) { 
                aux.AppendLine(requisicao.ToString());

            }
            return aux.ToString();
        }

        /// <summary>
        /// Método para verificar se a fila de espera está vazia
        /// </summary>
        /// <returns>True se a fila estiver vazia, False caso contrário</returns>
        public bool estaVazia()
        {
            return requisicoes.Count == 0;
        }
    }
}
