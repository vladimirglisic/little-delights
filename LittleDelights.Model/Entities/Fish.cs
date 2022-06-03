using LittleDelights.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Model.Entities
{
    public class Fish : Item
    {
        public Fish(DateTime capturedOn)
        {
            CapturedOn = capturedOn;
            StartPrice = Constants.StartPrice.Fish;
        }

        public DateTime CapturedOn { get; }

        public override decimal GetPrice(DateTime now)
        {
            throw new NotImplementedException();
        }
    }
}
