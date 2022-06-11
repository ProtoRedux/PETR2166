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
        private bool _vIPEnabled = true;
        private bool _coboxEn = true;
        private bool _aMealEnabled = true;
        private bool _cMealEnabled = true;
        private bool _payEnabled = true;
        private double _total;
        private TicketModel _selectedTicket; //Current selected ticket
        private double _vipPrice = VIPAddonModel.VIPPrice;
        private double _aMealPrice = AdultMealAddonModel.AMealPrice;
        private double _cMealPrice = ChildMealAddonModel.CMealPrice;
        private string _vIPDesc = " ";
        private string _aMealDesc = " ";
        private string _cMealDesc = "  ";


        //initilastion of a private Bindable collection to display tickets in combi box
        private BindableCollection<TicketModel> _tickets;

        //initialisation of primary ticket objects for ticket list above. This will take values from the associated classes
        public TicketModel Adult { get; set; } = new AdultTicketModel(); //Adult Ticket Model
        public TicketModel Child { get; set; } = new ChildTicketModel(); //Child Ticket Model   
        public TicketModel Member { get; set; } = new OAPTicketModel(); //OAP Ticket Model

        //initialisation and encapsulation of public prices and the boolean to control the button

        public bool CoBoxEn
        { 
            get { return _coboxEn; }
            set { _coboxEn = value; 
                NotifyOfPropertyChange(() => CoBoxEn);
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


        public double VipPrice
        { get { return _vipPrice; }
          set { _vipPrice = value;
                //NotifyOfPropertyChange(() => VipPrice);
              } 
        }
        public bool VIPEnabled
        {
            get { return _vIPEnabled; }
            set { _vIPEnabled = value;
            NotifyOfPropertyChange(()=>VIPEnabled);}
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
            //NotifyOfPropertyChange(()=>AmealPrice);
            }
        }

        public bool AmealEnabled
        { 
            get { return _aMealEnabled; } 
            set { _aMealEnabled = value;
                NotifyOfPropertyChange(() => AmealEnabled);
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
                //NotifyOfPropertyChange(()=>CMealPrice);
                }
        }
        public bool CMealEnabled
        {
            get { return _cMealEnabled;}
            set { _cMealEnabled = value;
                NotifyOfPropertyChange(()=>CMealEnabled) ;
                }
        }
        public string CMealDesc
        {
            get { return _cMealDesc; }
            set { _cMealDesc = value;
                NotifyOfPropertyChange(()=>CMealDesc);
                }
        }

        public BindableCollection<TicketModel> Tickets
        { 
            get { return _tickets; }
            set 
            { _tickets = value;
                NotifyOfPropertyChange(() => Tickets);
            }
        
        }

        public ShellViewModel() //Constructor
        {
            _selectedTicket = Adult; //Sets selected ticket field to Adult
            Total = _selectedTicket.Price; //Initially sets the cost to the first ticket selected
            Tickets = new BindableCollection<TicketModel>(); //Initialises Ticket Collection
            Tickets.Add(Adult); //Adds tickets to collection
            Tickets.Add(Child);
            Tickets.Add(Member);
        }
        public TicketModel SelectedTicket //The ticket that is currently selected
        {
            get { return _selectedTicket; } //Returns _ticket field
            set
            {
                _selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
                NotifyOfPropertyChange(() => Total);
                Subtotal(); //Calculates cost on ticket change
            }
        }

        public void AddVIP()
        {
            VIPEnabled = false;
            CoBoxEn = false;
            VIPDesc = "Upgraded to VIP seating area";
            SelectedTicket = new VIPAddonModel(SelectedTicket);
        }

        public void AddAMeal()
        {
            AmealEnabled = false;
            CoBoxEn = false;
            AMealDesc = "Addition of adult meal";
            SelectedTicket = new AdultMealAddonModel(SelectedTicket);
        }

        public void AddCMeal()
        {
            CMealEnabled = false;
            CoBoxEn= false;
            CMealDesc = "Addition of child meal";
            SelectedTicket = new ChildMealAddonModel(SelectedTicket);
        }

        public void Subtotal ()
        {
            Total = SelectedTicket.Cost();
            Total = Math.Round(Total, 2, MidpointRounding.AwayFromZero);
        }

        public void ResetPage()
        {
            SelectedTicket = Adult;
            CoBoxEn = true;
            AmealEnabled = true;
            CMealEnabled = true;
            VIPEnabled = true;

        }

        public void Purchase()
        {
            CoBoxEn = false;
            AmealEnabled=false;
            CMealEnabled=false;
            VIPEnabled=false;
        }
    }
}
