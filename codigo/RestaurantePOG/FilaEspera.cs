﻿using System;

namespace RestaurantePOG { 

    /// <summary>
    /// Classe representando a fila de espera do restaurante
    /// </summary>
    public class FilaEspera
    {
        private Queue<Cliente> clientes;

        /// <summary>
        /// Construtor padrão da classe FilaEspera
        /// </summary>
        public FilaEspera()
        {
            clientes = new Queue<Cliente>();
        }

        /// <summary>
        /// Método para adicionar um cliente à fila de espera
        /// </summary>
        /// <param name="cliente">Cliente a ser adicionado à fila</param>
        public void AdicionarCliente(Cliente cliente)
        {
            clientes.Enqueue(cliente);
        }

        /// <summary>
        /// Método para remover e retornar o próximo cliente da fila de espera
        /// </summary>
        /// <returns>Próximo cliente da fila</returns>
        public Cliente ProximoCliente()
        {
            return clientes.Dequeue();
        }

        /// <summary>
        /// Método para verificar se a fila de espera está vazia
        /// </summary>
        /// <returns>True se a fila estiver vazia, False caso contrário</returns>
        public bool EstaVazia()
        {
            return clientes.Count == 0;
        }
    }
}