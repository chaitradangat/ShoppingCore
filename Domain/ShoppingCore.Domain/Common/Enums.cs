using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Common
{
    public enum Units
    {
        Kg, g, L, ml, Nos
    }

    public enum AddressTypeEnum
    {
        Residential, Business, Work, School, Hospital, Garage, ProductGodown, ProductDistributionCenter, CustomerAddress, SellerAddress, ProductAddress
    }

    public enum AutheticationType
    {
        AppDatabase, Facebook, Google, Twitter
    }

    public enum UserRole
    {
        Customer, Seller, PrimeCustomer, PrimeSeller, CustomerSellerBoth
    }
}