using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        //Declaracion o matricula de interfaces a nivel repositorio
        ICategoryRepository Category { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
