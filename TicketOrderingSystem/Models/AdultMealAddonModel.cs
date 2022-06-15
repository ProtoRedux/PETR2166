using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOrderingSystem.Models;

namespace TicketOrderingSystem.Models
{
    public class AdultMealAddonModel : AddonModel
    {
        //created a private readonly ticketmodel the addition of both private and readonly means the fields are locked after initialisation and can't be changed.
        private readonly TicketModel _ticketmodel;
        public AdultMealAddonModel(TicketModel ticketmodel)
        {
            //using this keyword links the current class instance useful for passing information around that is only need for this particular instance.
            this._ticketmodel = ticketmodel;
        }

        // VIP price is held as a static double to prevent the price value from potentially changing once the function finishes.
        public static double AMealPrice { get; } = 5.99;
        // Found during testing that without this override the name shown in the description area will default to an invisable value.  
        public override string Name => _ticketmodel.Name;

        //Overrides the tickets description to append with the upgraded message
        public override string Description => _ticketmodel.Description + " With pie, chips and pint ";

        // found during testing that this override for the existing price must be set or the base ticket value will revert to 0
        public override double Price => _ticketmodel.Price;

        //method to return the original cost of the ticket with the addition of the static double created above.
        public override double Cost()
        {
            return this._ticketmodel.Cost() + AMealPrice;
        }
    }
}
