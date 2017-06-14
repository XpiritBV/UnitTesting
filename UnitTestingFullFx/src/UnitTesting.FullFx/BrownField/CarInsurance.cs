using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.FullFx.BrownField
{
    public class CarInsurance
    {
        public enum PriceGroup
        {
            Child,
            Junior,
            Senior,
            Adult
        }

        public PriceGroup GetCustomerPriceGroup(int customerID)
        {
            DataLayer dataLayer = new DataLayer();
            dataLayer.OpenConnection();
            Customer customer = dataLayer.GetCustomer(customerID);
            dataLayer.CloseConnection();
            DateTime now = DateTime.Now;
            if (customer.DateOfBirth > now.AddYears(-16))
                return PriceGroup.Child;
            else if (customer.DateOfBirth > now.AddYears(-25))
                return PriceGroup.Junior;
            else if (customer.DateOfBirth < now.AddYears(-65))
                return PriceGroup.Senior;
            else
                return PriceGroup.Adult;
        }
    }

    public class DataLayer
    {
        public void OpenConnection()
        {
            throw new Exception("Unable to connect to a database");
        }

        public Customer GetCustomer(int customerId)
        {
            throw new Exception("Unable to connect to a database");
        }

        public void CloseConnection()
        {
            throw new Exception("Unable to connect to a database");
        }
    }

    public class Customer
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
