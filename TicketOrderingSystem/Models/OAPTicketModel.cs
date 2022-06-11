using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOrderingSystem.Models
{
    public class OAPTicketModel:TicketModel
    {
        public OAPTicketModel()
        {
            Name = "Pensioner";
            Description = "Pensioner Seated Ticket";
            Price = 9.99;
        }
        public override double Cost()
        {
            return Math.Round(Price, 2, MidpointRounding.AwayFromZero); ;
        }
    }
}
