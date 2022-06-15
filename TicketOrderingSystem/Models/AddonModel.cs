using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOrderingSystem.Models
{
    public abstract class AddonModel:TicketModel
    {
        public abstract override string Description { get;}
        public abstract override double Price { get;}
    }
}
