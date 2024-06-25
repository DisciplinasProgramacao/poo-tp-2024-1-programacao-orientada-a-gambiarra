﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantePOG
{
    internal class Cafeteria : Estabelecimento
    {
        public Cafeteria(string nome) : base(nome)
        {
            this.nome = nome;
        }
        /// <summary>
        /// Registra início do atendimento ao cliente
        /// </summary>
        public override void atenderCliente()
        {
        }
        /// <summary>
        /// Cadasta cliente e cria requisição.
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="qtdPessoas"></param>
        public override void cadastrarCliente(string nome, int qtdPessoas)
        {
            // Gerar uma requisicao com as informações especificadas
            Cliente cliente = new(nome);
            lista_clientes.Add(cliente); // inserir na lista de clientes

            Requisicao requisicao = new Requisicao(cliente, qtdPessoas);
            lista_requisicao.Add(requisicao); // Inserir na lista de requisicoes
            requisicao.registrarEntrada();

            Console.WriteLine("Cliente cadastrado com sucesso!!!");


        }
        /// <summary>
        /// Retorna as requisições de atendimento realizados pelos clientes.
        /// </summary>
        /// <returns></returns>
        public override string exibeListaAtendimento()
        {
            if (lista_requisicao.Count == 0)
            {
                return "Não há registros de atendimento";

            }

            StringBuilder sb = new StringBuilder();
            foreach (var requisicao in lista_requisicao)
            {
                sb.AppendLine(requisicao.exibirDetalhes());

            }
            return sb.ToString();
        }


    }
}
