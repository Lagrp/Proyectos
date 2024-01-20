using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgcm.Dominio.DomainEvents
{
    public static class Events
    {
        public static readonly DomainEvent<PersonCreated> PersonCreated = new DomainEvent<PersonCreated>();
    }
}
