﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCore.Domain.Common
{
    public class Address : IEntity
    {
        public int AddressId { get; set; }

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
    }
}