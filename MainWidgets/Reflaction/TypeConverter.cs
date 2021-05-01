using MainWidgets.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MainWidgets.Reflaction
{
    public static class TypeConverter
    {
        public static TResult Progress<T, TResult>(T model) where TResult:class,new() {

            TResult result = new TResult();
            typeof(T).GetProperties().ToList().ForEach(p => {
                PropertyInfo property = typeof(TResult).GetProperty(p.Name);
                property.SetValue(result, p.GetValue(model));
            });
            return result;
        }
    }

    public class TypeConverterTest {
        public TypeConverterTest()
        {
            CustomerFilterOne customer = new CustomerFilterOne { 
                CustomerAddress="address", 
                CustomerName="mycustomer", 
                CustomerTel="555", 
                Id=1 
            };
            Customer converted_customer = TypeConverter.Progress<CustomerFilterOne, Customer>(customer);
            //...
        }
    }
}
