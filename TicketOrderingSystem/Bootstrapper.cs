using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TicketOrderingSystem.ViewModels;

namespace TicketOrderingSystem
{
    public class Bootstrapper :BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        //override standard OnStartup Command to instead load shellviewmodel
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
