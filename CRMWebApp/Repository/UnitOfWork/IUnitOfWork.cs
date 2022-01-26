using Domain.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        ApplicationContext Context { get; }

        Task Commit();

    }
}
