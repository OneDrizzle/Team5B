using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.ViewModels
{
    public class ItemSelectionEventArgs : EventArgs
    {
        public object SelectedItem { get; set; }

        public ItemSelectionEventArgs(object selectedItem)
        {
            SelectedItem = selectedItem;
        }
    }
}
