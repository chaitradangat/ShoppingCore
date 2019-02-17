using ShoppingCore.Application.Interfaces;
using ShoppingCore.Domain.Common;
using ShoppingCore.Domain.Interfaces;

namespace ShoppingCore.Application.ApplicationModels
{
    public class AddressModel : IAppModel
    {
        public IEntity _entity { get; set; }

        public int AddressID { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string AddressLine4 { get; set; }

        public string AddressLine5 { get; set; }

        public string LandMark { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Country { get; set; }

        public string PinCode { get; set; }

        public AddressTypeEnum AddressType { get; set; }

        public int? ProductID { get; set; }

        public int? CustomerID { get; set; }

        public AddressModel()
        {
            _entity = new Address();
        }

        public IAppModel ConvertToAppModel()
        {
            var address = _entity as Address;

            AddressID = address.AddressID;

            AddressLine1 = address.AddressLine1;

            AddressLine2 = address.AddressLine2;

            AddressLine3 = address.AddressLine3;

            AddressLine4 = address.AddressLine4;

            AddressLine5 = address.AddressLine5;

            LandMark = address.LandMark;

            City = address.City;

            District = address.District;

            Country = address.Country;

            PinCode = address.PinCode;

            AddressType = address.AddressType;

            ProductID = address.Product?.ProductID;

            CustomerID = address.Customer?.CustomerID;

            return this;
        }

        public IEntity ConvertToDomainModel()
        {
            var address = _entity as Address;

            address.AddressID = AddressID;

            address.AddressLine1 = AddressLine1;

            address.AddressLine2 = AddressLine2;

            address.AddressLine3 = AddressLine3;

            address.AddressLine4 = AddressLine4;

            address.AddressLine5 = AddressLine5;

            address.LandMark = LandMark;

            address.City = City;

            address.District = District;

            address.Country = Country;

            address.PinCode = PinCode;

            address.AddressType = AddressType;


            if (address.Product != null)
                address.Product.ProductID = ProductID;

            if (address.Customer != null)
                address.Customer.CustomerID = CustomerID;

            return address;

        }
    }
}
