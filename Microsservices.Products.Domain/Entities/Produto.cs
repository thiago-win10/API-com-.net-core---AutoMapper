using Microsservices.Products.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Domain.Entities
{
    public class Produto
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public StatusProduto StatusProduto { get; set; }
        public int StatusProdutoId { get; set; }

        public ProdutoDTO ConvertToDTO()
        {
            return new ProdutoDTO
            {
                Id = this.Id,
                Nome = this.Nome,
                Descricao = this.Descricao,
                DataCadastro = this.DataCadastro,
                DataAtualizacao = this.DataAtualizacao,
                StatusProdutoDTO = this.StatusProduto != null ?  this.StatusProduto.ConvertToDTO() : null,
            };
        }

        public void Salvar()
        {
            if (string.IsNullOrEmpty(this.Nome))
                throw new Exception("Nome não pode ser nulo");

            if (string.IsNullOrEmpty(this.Descricao))
                throw new Exception("Descrição  não pode ser nulo");

            Id = Guid.NewGuid().ToString();
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
            StatusProdutoId = 1;
        }

        public void Atualizar()
        {
            DataAtualizacao = DateTime.Now;
        }

        public void Excluir()
        {
            DataAtualizacao = DateTime.Now;
            StatusProdutoId = 2;
        }
    }
}
