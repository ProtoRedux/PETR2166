using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketOrderingSystem.Models;

namespace TicketOrderingSystem.ViewModels
{
    //created class for intial view model inheriting from caliburn screen parent
    public class ShellViewModel : Screen
    {
        //Private fields used with preset values to enable disabling of buttons and other functions
        private TicketModel _selectedTicket; //Current selected ticket
        private bool _vIPEn = true;
        private bool _coboxEn = true;
        private bool _aMealEn = true;
        private bool _cMealEn = true;
        private bool _finalEn = true;
        private double _total;
        private double _vipPrice = VIPAddonModel.VIPPrice;
        private double _aMealPrice = AdultMealAddonModel.AMealPrice;
        private double _cMealPrice = ChildMealAddonModel.CMealPrice;
        private string _vIPDesc = " ";
        private string _aMealDesc = " ";
        private string _cMealDesc = " ";


        //initilastion of a private Bindable collection to display tickets in combo box
        private BindableCollection<TicketModel> _tickets;

        //initialisation of primary ticket objects for ticket list above. This will take values from the associated classes
        public TicketModel Adult { get; set; } = new AdultTicketModel(); //Adult Ticket Model
        public TicketModel Child { get; set; } = new ChildTicketModel(); //Child Ticket Model   
        public TicketModel Member { get; set; } = new OAPTicketModel(); //OAP Ticket Model

        //Initialsation and encapsulation of bools and double not attached to decorator buttons but other function buttons.
        public bool CoBoxEn
        { 
            get { return _coboxEn; }
            set { _coboxEn = value; 
                NotifyOfPropertyChange(() => CoBoxEn);
                }
        }

        public bool FinalEn
        {
            get { return _finalEn; }
            set { _finalEn = value; 
                NotifyOfPropertyChange(() => FinalEn);
                }
        }
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                NotifyOfPropertyChange(() => Total);
            }
        }

        //initialisation and encapsulation of public prices and descriptions and the boolean to control the associated buttons
        public double VipPrice
        { get { return _vipPrice; }
          set { _vipPrice = value;
                //NotifyOfPropertyChange(() => VipPrice);
              } 
        }
        public bool VIPEn
        {
            get { return _vIPEn; }
            set { _vIPEn = value;
            NotifyOfPropertyChange(()=>VIPEn);}
        }
        public string VIPDesc
        {
            get { return _vIPDesc; }
            set { _vIPDesc = value;
                NotifyOfPropertyChange(() => VIPDesc);
                }
        }
        public double AmealPrice
        { 
            get { return _aMealPrice; }
            set { _aMealPrice = value;
                NotifyOfPropertyChange(()=>AmealPrice);
                }
        }

        public bool AmealEn
        { 
            get { return _aMealEn; } 
            set { _aMealEn = value;
                NotifyOfPropertyChange(() => AmealEn);
                } 
        }

        public string AMealDesc
        {
            get { return _aMealDesc; }
            set { _aMealDesc = value;
                NotifyOfPropertyChange(() => AMealDesc);
                }
        }

        public double CMealPrice 
        {
            get { return _cMealPrice;}
            set { _cMealPrice = value; 
                NotifyOfPropertyChange(()=>CMealPrice);
                }
        }
        public bool CMealEn
        {
            get { return _cMealEn;}
            set { _cMealEn = value;
                NotifyOfPropertyChange(()=>CMealEn) ;
                }
        }
        public string CMealDesc
        {
            get { return _cMealDesc; }
            set { _cMealDesc = value;
                NotifyOfPropertyChange(()=>CMealDesc);
                }
        }

        //public encapsulation of private ticket objects for use in combo box
        public BindableCollection<TicketModel> Tickets
        { 
            get { return _tickets; }
            set 
            { _tickets = value;
                NotifyOfPropertyChange(() => Tickets);
            }
        
        }

        //Constructors for the solution 
        public ShellViewModel() 
        {
            //On load presets the selected ticket field in the combo box to Adult
            _selectedTicket = Adult;
            //Initially sets the price to the selected ticket (default: adult)
            Total = _selectedTicket.Price; 
            //Initialises Ticket BindableCollection
            Tickets = new BindableCollection<TicketModel>(); 
            //Adds the previously created ticket objects to the Bindable collection
            Tickets.Add(Adult); 
            Tickets.Add(Child);
            Tickets.Add(Member);
        }
        //Selected ticket object encapsulation
        public TicketModel SelectedTicket 
        {
            get { return _selectedTicket; } 
            set
            {
                _selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
                NotifyOfPropertyChange(() => Total);
                Subtotal(); 
            }
        }

        // Method attached to add VIP seating button to disbale the button once clicked adject the description to be shown once clicked
        // and add the decorator to the selected ticket
        public void AddVIP()
        {
            VIPEn = false;
            CoBoxEn = false;
            VIPDesc = "Upgraded to VIP seating area";
            SelectedTicket = new VIPAddonModel(SelectedTicket);
        }

        // Method attached to add VIP seating button to disbale the button once clicked adject the description to be shown once clicked
        // and add the decorator to the selected ticket
        public void AddAMeal()
        {
            AmealEn = false;
            CoBoxEn = false;
            AMealDesc = "Addition of adult meal";
            SelectedTicket = new AdultMealAddonModel(SelectedTicket);
        }
        // Method attached to add VIP seating button to disbale the button once clicked adject the description to be shown once clicked
        // and add the decorator to the selected ticket
        public void AddCMeal()
        {
            CMealEn = false;
            CoBoxEn= false;
            CMealDesc = "Addition of child meal";
            SelectedTicket = new ChildMealAddonModel(SelectedTicket);
        }
        //Method designed to recalculate and show the ticket price once decorators are added.
        //The math functions are used to round the result to two decimal places. This is used as doubles and other floating point numbers can be slightly inaccurate
        public void Subtotal ()
        {
            Total = SelectedTicket.Cost();
            Total = Math.Round(Total, 2, MidpointRounding.AwayFromZero);
        }

        //Method created and attached to reset button that will return page to default values
        public void ResetPage()
        {
            SelectedTicket = Adult;
            CoBoxEn = true;
            AmealEn = true;
            CMealEn = true;
            VIPEn = true;
            FinalEn = true;

        }

        //Method to simulate finalising a ticket locks out all buttons preventing further changes until reset method is called to restore page to default.
        public void Purchase()
        {
            CoBoxEn = false;
            AmealEn=false;
            CMealEn=false;
            VIPEn=false;
            FinalEn = false;
        }
    }
}
