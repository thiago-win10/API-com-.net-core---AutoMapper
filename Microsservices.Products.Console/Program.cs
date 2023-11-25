using Microsservices.Products.Domain.Entities;
using System;

namespace Microsservices.Products.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Olá povo");
            Teste();
            
        }

        static void Teste()
        {
            Produto produto = new Produto();
            produto.Nome = "TV Smart";
            produto.Descricao = "Digital";

            produto.Salvar();

            System.Console.WriteLine($"Id: {produto.Id}, Nome: {produto.Nome}, Descrição: {produto.Descricao}," +
                $"Data Cadastro: `{produto.DataCadastro}, Data Atualização: {produto.DataAtualizacao}");
        }
    }
}
