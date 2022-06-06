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
    public class ShellViewModel : Conductor<object>
    {
        // ---------list item instantiation of main classes and addons
        public ShellViewModel()
        {
            Ticket.Add(new TicketModel { Name = "Adult", Description = "Standard seated accomodation for single adult", Price = 19.99 });
            Ticket.Add(new TicketModel { Name = "O.A.P", Description = "Standard seated accomodation for single pensioner", Price = 13.99 });
            Ticket.Add(new TicketModel { Name = "Child", Description = "Standard seated accomodation for single child", Price = 9.99 });
            Ticket.Add(new TicketModel { Name = "Student", Description = "Standard seated accomodation for single student", Price = 14.99});
            AddonPriceList.Add(AMealPrice);
            AddonPriceList.Add(CMealPrice);
            AddonPriceList.Add(VipPrice);
            double sum = AddonPriceList.Sum();
        }

        //------Private varibles used in solution
        private TicketModel _selectedTicket;
        private string  _adultmeal = "";
        private string _childmeal = "";
        private string _vipseat = "";
        private BindableCollection<TicketModel> _ticket = new BindableCollection<TicketModel>();
        private BindableCollection<double> _addonPriceList = new BindableCollection<double>();
        private double _amealprice = 7.00;
        private double _vipprice = 5.00;
        private double _cmealprice = 4.50;



        //DELETE BEFORE SUBMISSION
        private string _firstName ="Tim";
        private string _lastName = "Allen";
        public string FirstName
        {
            get
            { 
                return _firstName; 
            }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(()=> FirstName);
                NotifyOfPropertyChange(()=> FullName);
            }
        }
        public  string LastName
        {
            get 
            {
                return _lastName; 
            }
            set 
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);

            }

        }
        public string FullName
        {
            get { return $"{FirstName } { AdultMeal }"; }

        }

        //------------Created list for main ticket classes
        //Bindable collection in MVVM is essentaily a list
        public BindableCollection<TicketModel> Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        //-------- Constructor for selecting ticket type from combo box
        public TicketModel SelectedTicket
        {
            get
            {
                return _selectedTicket;
            }
            set
            {
                _selectedTicket = value;
                NotifyOfPropertyChange(() => SelectedTicket);
            }
        }
        // get and set constructors for addon string variables
        public string AdultMeal
        {
            get
            {return _adultmeal;}
            set
            {_adultmeal = value;
             NotifyOfPropertyChange(() => AdultMeal);}
        }
        public string ChildMeal
        {
            get
            {return _childmeal;}
            set
            { _childmeal = value;
                NotifyOfPropertyChange(() => ChildMeal);}
        }

        public string VipSeat
        {
            get { return _vipseat; }
            set { _vipseat = value;
                NotifyOfPropertyChange(()=>VipSeat);}
        }

        // --- Get and set constructors for addon prices
        public double AMealPrice
        { get { return _amealprice; } 
          set { _amealprice = value;} }
        public double VipPrice 
        { get { return _vipprice; }set { _vipprice = value; } }
        public double CMealPrice 
        { get { return _cmealprice; }
          set { _cmealprice = value; } 
        }

        // ------------Methods for assigning string and double values to addons when corresponding button pressed
        public void ChildMealAdd(string _childmeal, double _cmealprice)
        {
            ChildMeal = "Sausage, chips & Softdrink";
            CMealPrice = 2.99;
            NotifyOfPropertyChange(() => ChildMeal);
            NotifyOfPropertyChange(()=>CMealPrice);
            NotifyOfPropertyChange(() => AddonPriceList);
            NotifyOfPropertyChange(()=>_addonPriceList);
        }
        public void AdultMealAdd(string _adultmeal, double _amealprice)
        {
            AdultMeal = "Pie, Chips & Pint of Beer";
            AMealPrice = 4.99;
            NotifyOfPropertyChange(() => AdultMeal);
            NotifyOfPropertyChange(()=>AMealPrice);
            NotifyOfPropertyChange(() => AddonPriceList);
        }
        public void VIPSeatadd(string _vipseat, double _vipprice)
        {
            VipSeat = "VIP priority seating";
            VipPrice = 29.99;
            NotifyOfPropertyChange(() => VipSeat);
            NotifyOfPropertyChange(()=>VipPrice);
            NotifyOfPropertyChange(() => AddonPriceList);
        }



        
        // get ans set constructors fro addon price list
        public BindableCollection<double> AddonPriceList
        { 
            get { return _addonPriceList;}
            set { _addonPriceList = value;} 
        }

        
        // ---- method to give sum value of all addon prices when subtotal button clicked 
        public void SubTotalGive(double sum)
        {
            double Subtotal = sum;
            NotifyOfPropertyChange(()=>Subtotal);
            NotifyOfPropertyChange(()=>AddonPriceList);

        }

        //method to remove text from form -DELETE BEFORE SUBMISSION
        public void ClearText(string firstname, string lastname)
        {
            FirstName = " ";
            LastName = "";
        }

        //method to check if text is in form - DELETE BEFORE SUBMISSION
        public bool CanClearText(string firstname, string lastname)
        {

            if (string.IsNullOrWhiteSpace (firstname) && string.IsNullOrWhiteSpace(lastname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //creates seperate view to show current selections. - DELETE BEFORE SUBMISSION
        public void LoadPageOne()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }

    }
}
