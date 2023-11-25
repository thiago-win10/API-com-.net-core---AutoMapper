using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Domain.DTOs
{
    public class ProdutoDTO
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public StatusProdutoDTO StatusProdutoDTO { get; set; }

        public Produto ConvertToEntity()
        {
            return new Produto
            {
                Id = this.Id,
                Nome = this.Nome,
                Descricao = this.Descricao,
                DataCadastro = this.DataCadastro,
                DataAtualizacao = this.DataAtualizacao,
                StatusProduto = this.StatusProdutoDTO != null ? this.StatusProdutoDTO.ConvertToEntity() : null,
            };
        }
    }
}
