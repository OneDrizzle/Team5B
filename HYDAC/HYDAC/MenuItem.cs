using System;
using System.Collections.Generic;
using System.Text;

namespace HYDAC
{
    public class MenuItem
    {
        private string title;

        public MenuItem(string itemTitle)
        {
            title = itemTitle;
        }

        public string Title
        {
            get { return title;}
        }
    }
}
