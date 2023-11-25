using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Domain.Contracts.Base
{
    public interface IGenericProduct<T, Y>
    {
        void Cadastrar(T entidade);
        void Atualizar(T entidade);
        void Excluir(Y id);
        List<T> Listar();
        List<T> Pesquisar(T entidade);
        T PesquisarPorId(Y id);

    }
}
