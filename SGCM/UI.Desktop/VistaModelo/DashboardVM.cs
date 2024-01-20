using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sgcm.UI.Desktop.VistaModelo
{
    internal class DashboardVM:NotifyVM
    {
       
        public DashboardVM()
        {
        }
        public ICommand NewAppointmentsCommand => new CommandBase(ExecuteNewAppointmentsCommand);

        
        private void ExecuteNewAppointmentsCommand(object obj)
        {
            MessageBox.Show("NewAppointmentsCommand");
        }

    }
}
