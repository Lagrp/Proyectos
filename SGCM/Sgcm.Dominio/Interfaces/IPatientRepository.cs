using Sgcm.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgcm.Dominio.Interfaces
{
    public interface IPatientRepository: IBaseRepositoryAsync<Patient>
    {
    }
}
