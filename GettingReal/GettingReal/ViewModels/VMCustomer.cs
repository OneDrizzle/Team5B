﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GettingReal.Models;

namespace GettingReal.ViewModels
{
    public class VMCustomer
    {

        private Customer customer;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; customer.Name = _name; }
        }

        private string _company;

        public string Company
        {
            get { return _company; }
            set { _company = value; customer.Company = _company; }
        }


        public List<VMBuilding> _buildingsVM { get; set; }


        public VMCustomer(Customer customer)
        {
            this.customer = customer;
            _buildingsVM = new List<VMBuilding>();
            foreach (Building building in customer.GetListOfBuildings())
            {
                _buildingsVM.Add(new VMBuilding(building));
            }

            Name = customer.Name;
        }

        public void AddBuilding(VMBuilding buildingVM)
        {
            _buildingsVM.Add(buildingVM);
        }

        public Customer GetCustomer()
        {
            return this.customer;
        }

    }
}
