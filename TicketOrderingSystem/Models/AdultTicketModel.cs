using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOrderingSystem.Models
{
    public class AdultTicketModel:TicketModel
    {
        public AdultTicketModel()
        {
            Name = "Adult"; 
            Description = "Adult Seated Ticket";
            Price = 19.99;
        }
        public override double Cost()
        {
            return Math.Round(Price, 2, MidpointRounding.AwayFromZero); ;
        }
    }
}
