using GettingReal.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace GettingReal.Commands
{
    public class NewCustomerCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.AddCustomer();
                mvm.Save();
            }
            else
                throw new ArgumentException("Illegal parameter type");
        }
    }
}
