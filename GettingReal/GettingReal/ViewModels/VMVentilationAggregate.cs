using GettingReal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GettingReal.ViewModels
{
    public class VMVentilationAggregate
    {
        private VentilationAggregate _ventilationAggregate;
        private string _orderNumber;

        public string OrderNumber
        {
            get { return _orderNumber; }
            set { _orderNumber = value; _ventilationAggregate.OrderNumber = _orderNumber; }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; _ventilationAggregate.FileName = fileName; }
        }


        public List<VMFloor> _floorsVM { get; set; }
        public List<VMFilter> _filtersVM { get; set; }
        public List<VMServiceReport> _serviceReports { get; set; }

        public VMVentilationAggregate(VentilationAggregate ventilationAggregate)
        {
            this._ventilationAggregate = ventilationAggregate;

            _floorsVM = new List<VMFloor>();
            foreach (Floor floor in ventilationAggregate.GetListOfFloors())
            {
                _floorsVM.Add(new VMFloor(floor));
            }

            _filtersVM = new List<VMFilter>();
            foreach (Filter filter in ventilationAggregate.GetListOfFilters())
            {
                _filtersVM.Add(new VMFilter(filter));
            }

            _serviceReports = new List<VMServiceReport>();
            foreach (ServiceReport serviceReport in ventilationAggregate.GetListOfServiceReports())
            {
                _serviceReports.Add(new VMServiceReport(serviceReport));
            }

            OrderNumber = ventilationAggregate.OrderNumber;
            FileName = ventilationAggregate.FileName;
        }

        public void AddFloor(VMFloor floorVM)
        {
            _floorsVM.Add(floorVM);
        }


        public VentilationAggregate GetVentilationAggregate()
        {
            return this._ventilationAggregate;
        }
    }
}
