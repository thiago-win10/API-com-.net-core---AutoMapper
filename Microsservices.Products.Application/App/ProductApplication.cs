using Microsservices.Products.Domain.Contracts.Application;
using Microsservices.Products.Domain.Contracts.Repositories;
using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Application.App
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _producRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            _producRepository = productRepository;
        }
        public void Atualizar(Produto entidade)
        {
            _producRepository.Atualizar(entidade);
        }

        public void Cadastrar(Produto entidade)
        {
            _producRepository.Cadastrar(entidade);
        }

        public void Excluir(string id)
        {
            _producRepository.Excluir(id);
        }

        public List<Produto> Listar()
        {
            return _producRepository.Listar();
        }

        public List<Produto> Pesquisar(Produto entidade)
        {
            return _producRepository.Pesquisar(entidade);
        }

        public Produto PesquisarPorId(string id)
        {
            return _producRepository.PesquisarPorId(id);
        }
    }
}
