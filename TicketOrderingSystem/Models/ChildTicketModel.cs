using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOrderingSystem.Models
{
    public class ChildTicketModel: TicketModel
    {
        public ChildTicketModel()
        {
            Name = "Child";
            Description = "Child Seated Ticket";
            Price = 13.99;
        }
        public override double Cost()
        {
         return Math.Round(Price, 2, MidpointRounding.AwayFromZero); 
        }
    }
}
