using GettingReal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.ViewModels
{
    public class VMFilter
    {
        private Filter _filter;
        private string _filterClass;

        public string FilterClass
        {
            get { return _filterClass; }
            set { _filterClass = value; _filter.Filterclass = _filterClass; }
        }

        public VMFilter(Filter filter)
        {
            FilterClass = filter.Filterclass;
        }

        public Filter GetFilter()
        {
            return this._filter;
        }
    }
}
