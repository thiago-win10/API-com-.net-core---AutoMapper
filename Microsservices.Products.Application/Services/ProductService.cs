using Microsservices.Products.Domain.Contracts.Application;
using Microsservices.Products.Domain.Contracts.Services;
using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductApplication _productApplication;
        public ProductService(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }
        public void Atualizar(Produto entidade)
        {
            _productApplication.Atualizar(entidade);
        }

        public void Cadastrar(Produto entidade)
        {
            _productApplication.Cadastrar(entidade);
        }

        public void Excluir(string id)
        {
            _productApplication.Excluir(id);
        }

        public List<Produto> Listar()
        {
            return _productApplication.Listar();
        }

        public List<Produto> Pesquisar(Produto entidade)
        {
            return _productApplication.Pesquisar(entidade);
        }

        public Produto PesquisarPorId(string id)
        {
            return _productApplication.PesquisarPorId(id);
        }
    }
}
