using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Domain.DTOs
{
    public class StatusProdutoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public StatusProduto ConvertToEntity()
        {
            return new StatusProduto
            {
                Id = this.Id,
                Descricao = this.Descricao,
          
            };
        }

    }
}
