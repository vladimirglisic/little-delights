using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;

namespace LittleDelights.Data
{
    public class Context
    {
        public Context()
        {
            Items = new Dictionary<Guid, Item>();
        }

        public Dictionary<Guid, Item> Items { get; }
    }
}
