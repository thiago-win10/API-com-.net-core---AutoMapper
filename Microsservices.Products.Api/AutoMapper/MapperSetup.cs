using AutoMapper;
using Microsservices.Products.Domain.DTOs;
using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsservices.Products.Api.AutoMapper
{
    public class MapperSetup : Profile
    {
        public MapperSetup()
        {
            CreateMap<StatusProdutoDTO, StatusProduto>();
            CreateMap<ProdutoDTO, Produto>();

            CreateMap<StatusProduto, StatusProdutoDTO>();
            CreateMap<Produto, ProdutoDTO>();
        }
    }
}
