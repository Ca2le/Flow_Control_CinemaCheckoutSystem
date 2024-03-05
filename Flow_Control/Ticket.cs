using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flow_Control
{
    public class Ticket
    {
        private int price;
        public string AgeCategory { get; set; }

        public Ticket(int age)
        {
            this.price = GeneratePriceBasedOnAge(age);
        }

        public int Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = GeneratePriceBasedOnAge(value);
            }
        }

        private int GeneratePriceBasedOnAge(int age)
        {
            if ((int)AgeGroup.Junior <= age && (int)AgeGroup.Adult > age )
            {
                AgeCategory = "Junior";
                return (int)PriceRange.Junior;
            }
            if ((int)AgeGroup.Adult <= age && (int)AgeGroup.Senior > age)
            {
                AgeCategory = "Vuxen";
                return (int)PriceRange.Adult;
            }
            if ((int)AgeGroup.Senior <= age && (int)AgeGroup.SeniorExclusive > age)
            {
                AgeCategory = "Senior";
                return (int)PriceRange.Senior;
            }
            else
            {
                AgeCategory = "V.I.P.";
                return (int)PriceRange.Free;
            }
        }
    }

    internal enum PriceRange
    {
        Junior = 80,
        Adult = 120,
        Senior = 90,
        Free = 0
    }
    internal enum AgeGroup
    {
        Junior = 5,
        Adult = 20,
        Senior = 65,
        SeniorExclusive = 100,
    }
}
