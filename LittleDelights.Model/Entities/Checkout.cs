﻿using LittleDelights.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public class Checkout : ICheckout
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }

        public virtual Cart Cart { get; set; }

        public void CreateReceipt(ICart cart)
        {
            // create a new checkout in the repository

            throw new NotImplementedException();
        }
    }
}
