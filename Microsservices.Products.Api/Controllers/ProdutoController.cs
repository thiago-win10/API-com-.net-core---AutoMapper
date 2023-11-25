using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsservices.Products.Domain.Contracts.Services;
using Microsservices.Products.Domain.DTOs;
using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsservices.Products.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProdutoController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("listar")]
        public List<ProdutoDTO> Listar()
        {
            List<Produto> produtos = _productService.Listar();
            List<ProdutoDTO> result = _mapper.Map<List<ProdutoDTO>>(produtos);


            return result;

        }

        [HttpGet]
        [Route("pesquisar/{id}")]
        public ProdutoDTO PesquisarPorId(string id)
        {
            Produto produto = _productService.PesquisarPorId(id);
            ProdutoDTO result = null;

            if (produto != null)
            {
                result = _mapper.Map<ProdutoDTO>(produto);
                result.StatusProdutoDTO = _mapper.Map<StatusProdutoDTO>(produto.StatusProduto);

            }
            return result;
        }

        [HttpPost]
        [Route("cadastrar")]
        public ProdutoDTO Cadastrar([Bind("nome, descricao")] ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);
            produto.Salvar();

            _productService.Cadastrar(produto);
            ProdutoDTO result = PesquisarPorId(produto.Id);

            return result;
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public string Excluir(string id)
        {
            _productService.Excluir(id);
            return "Exclusão efetuada com sucesso";
        }

        [HttpPut]
        [Route("atualizar")]
        public string Atualizar([Bind("id, nome, descricao")] ProdutoDTO produtoDTO)
        {
            Produto produto = _mapper.Map<Produto>(produtoDTO);

            produto.Atualizar();

            _productService.Atualizar(produto);

            return "Atualização efetuada com successo!";
        }

    }
}
