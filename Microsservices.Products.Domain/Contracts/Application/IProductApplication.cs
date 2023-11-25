using Microsservices.Products.Domain.Contracts.Base;
using Microsservices.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsservices.Products.Domain.Contracts.Application
{
    public interface IProductApplication : IGenericProduct<Produto, string>
    {
    }
}
