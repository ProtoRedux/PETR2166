using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketOrderingSystem.Models
{
    public class AdultMealAddonModel:AddonModel
    {
        public AdultMealAddonModel() 
        {
            Name = "Adult Meal";
            Description = "Pie, Chips & Pint";
            Price = 4.99;
        }

    }
}
