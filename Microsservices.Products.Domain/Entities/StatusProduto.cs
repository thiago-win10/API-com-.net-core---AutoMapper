using Microsservices.Products.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Domain.Entities
{
    public class StatusProduto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public StatusProdutoDTO ConvertToDTO()
        {
            return new StatusProdutoDTO
            {
                Id = this.Id,
                Descricao = this.Descricao
            };
        }
    }
}
