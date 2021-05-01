using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWidgets.DataTypes
{
    class MyImplicitValues
    {
        private Customer _customer;
        private CustomerFilterOne _customerFilterOne;
        private CustomerFilterSecond _customerFilterSecond;
        public MyImplicitValues()
        {
            _customerFilterOne = new CustomerFilterOne
            {
                Id = 1,
                CustomerName = "Bla",
                CustomerTel = "555",
                CustomerAddress = "ISTANBUL"
            };

            _customerFilterSecond = new CustomerFilterSecond { 
                CreatedDate = DateTime.Now, 
                CustomerName = "Blala", 
                IsActive = true, 
                Id = 2, 
                ModifiedDate = DateTime.Now };

            _customer = new Customer {
                CreatedDate=DateTime.Now,
                CustomerAddress="My Address",
                CustomerName="Blabla",
                CustomerTel="444",
                Id=123,
                IsActive=true,
                IsDeleted=false,
                ModifiedDate=DateTime.Now
            };


            #region Stage One - Test
            _customer = _customerFilterOne;
            _customerFilterOne = _customer;
            #endregion

            #region Stage Two - Test
            _customer = _customerFilterSecond;
            _customerFilterSecond = _customer;
            #endregion
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        #region Stage One
        public static implicit operator CustomerFilterOne(Customer customer)
        {
            return new CustomerFilterOne
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerAddress = customer.CustomerAddress,
                CustomerTel = customer.CustomerAddress
            };
        }

        public static implicit operator Customer(CustomerFilterOne customer)
        {
            return new Customer
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerAddress = customer.CustomerAddress,
                CustomerTel = customer.CustomerAddress
            };
        }
        #endregion

        #region Stage Two
        public static implicit operator CustomerFilterSecond(Customer customer)
        {
            return new CustomerFilterSecond
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                IsActive = customer.IsActive,
                CreatedDate = customer.CreatedDate,
                ModifiedDate = customer.ModifiedDate
            };
        }

        public static implicit operator Customer(CustomerFilterSecond customer)
        {
            return new Customer
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                IsActive = customer.IsActive,
                CreatedDate = customer.CreatedDate,
                ModifiedDate = customer.ModifiedDate
            };
        }
        #endregion
    }

    public class CustomerFilterOne
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTel { get; set; }
    }

    public class CustomerFilterSecond
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
