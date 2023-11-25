using Microsoft.EntityFrameworkCore;
using Microsservices.Products.Domain.Contracts.Repositories;
using Microsservices.Products.Domain.Entities;
using Microsservices.Products.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsservices.Products.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDataContext _context;
        public ProductRepository(ProductDataContext context)
        {
            _context = context;
        }
        public void Atualizar(Produto entidade)
        {
            Produto obj = PesquisarPorId(entidade.Id);
            if (obj != null)
            {
                entidade.DataCadastro = obj.DataCadastro;
                entidade.StatusProdutoId = obj.StatusProdutoId;
            }

            _context.Produtos.Update(entidade);
            _context.SaveChanges();
        }

        public void Cadastrar(Produto entidade)
        {
            _context.Produtos.Add(entidade);
            _context.SaveChanges();
        }

        public void Excluir(string id)
        {
            Produto produto = PesquisarPorId(id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
        }

        public List<Produto> Listar()
        {
           return _context.Produtos
                .Include("StatusProduto")
                .AsNoTracking()
                .ToList();
        }

        public List<Produto> Pesquisar(Produto entidade)
        {
            List<Produto> result = new List<Produto>();
            if (!string.IsNullOrEmpty(entidade.Id))
                result.Add(PesquisarPorId(entidade.Id));
            else
            {
                if (!string.IsNullOrEmpty(entidade.Nome))
                {
                   result = _context.Produtos
                        .AsNoTracking()
                        .Where(p => p.Nome.Contains(entidade.Nome, StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                }

                if (!string.IsNullOrEmpty(entidade.Descricao))
                {
                    result = _context.Produtos
                        .AsNoTracking()
                        .Where(p => p.Descricao.Contains(entidade.Descricao, StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                }

                else if (entidade.StatusProdutoId > 0)
                {
                    result = _context.Produtos
                        .AsNoTracking()
                        .Where(p => p.StatusProdutoId == entidade.StatusProdutoId)
                        .ToList();
                }

                else if (entidade.DataCadastro > DateTime.MinValue)
                {
                    string dataFiltro = entidade.DataCadastro.ToString("yyyy-MM-dd");
                    
                    result = _context.Produtos
                        .AsNoTracking()
                        .Where(p => p.DataCadastro.ToString("dd-MM-dd") == dataFiltro)
                        .ToList();
                       
                }

                else if (entidade.DataAtualizacao > DateTime.MinValue)
                {
                    DateTime data = entidade.DataAtualizacao.Date;

                    result = _context.Produtos
                        .AsNoTracking()
                        .Where(p => p.DataAtualizacao.Date == data)
                        .ToList();

                }
            }

            return result;
        }

        public Produto PesquisarPorId(string id)
        {
            return _context.Produtos
                .Include("StatusProduto")
                .AsNoTracking()
                .FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
