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
            TickName.Add(AdultT);
            TickName.Add(ChildT);
            TickName.Add(OldT);

            double sum = AddonPriceList.Sum();
        }

        //------Private varibles used in solution
        private TicketModel _selectedTicket;
        private string  _adultmeal = "";
        private string _childmeal = "";
        private string _vipseat = "";
        private string _selectedTickName;
        private BindableCollection<TicketModel> _ticket = new BindableCollection<TicketModel>();
        private BindableCollection<double> _addonPriceList = new BindableCollection<double>();
        private BindableCollection<string> _tickName = new BindableCollection<string>(); 
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
                NotifyOfPropertyChange(()=> FullTicket);
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
                NotifyOfPropertyChange(() => FullTicket);
            }
        }
        private string _adultT = "Adult Seat";
        private string _childT = "Child Seat";
        private string _oldT = "O.A.P Seat";

        public string AdultT 
            { 
            get { return _adultT; }
            set { _adultT = value; 
            NotifyOfPropertyChange(()=> AdultT);
            NotifyOfPropertyChange(() => SelectedTickName);
            NotifyOfPropertyChange(() => FullTicket);
            } 
            }

        public string ChildT
        {
            get { return _childT; }
            set { _childT = value;
                NotifyOfPropertyChange(() => ChildT);
                NotifyOfPropertyChange(() => SelectedTickName);
                NotifyOfPropertyChange(() => FullTicket);
            }
        }
        public string OldT { 
            get { return _oldT; }
            set { _oldT = value;
                NotifyOfPropertyChange(() => OldT);
                NotifyOfPropertyChange(() => SelectedTickName);
                NotifyOfPropertyChange(() => FullTicket);
            }
        }


        public string FullTicket
        {
            get { return $"{SelectedTickName}  { AdultMeal } {ChildMeal} {VipSeat}"; }
        }

        //------------Created list for main ticket classes
        //Bindable collection in MVVM is a list
        public BindableCollection<TicketModel> Ticket
        {
            get { return _ticket; }
            set { _ticket = value;}
        }

        public BindableCollection<string> TickName
        {
            get { return _tickName; }
            set { _tickName = value; }
        }

        public string SelectedTickName
        {
            get { return _selectedTickName; }
            set { _selectedTickName = value;
                NotifyOfPropertyChange(() => SelectedTickName);
                NotifyOfPropertyChange(() => TickName);
            }

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
                NotifyOfPropertyChange(()=>FullTicket);
            }
        }       
        // get and set constructors for addon price list
        public BindableCollection<double> AddonPriceList
        { 
            get { return _addonPriceList;}
            set { _addonPriceList = value;
                NotifyOfPropertyChange(() => AddonPriceList);
            } 
        }
        // get and set constructors for addon string variables
        public string AdultMeal
        {
            get
            {return _adultmeal;}
            set
            {_adultmeal = value;
             NotifyOfPropertyChange(() => AdultMeal);
             NotifyOfPropertyChange(() => FullTicket);
            }
        }
        public string ChildMeal
        {
            get
            {return _childmeal;}
            set
            { _childmeal = value;
                NotifyOfPropertyChange(() => ChildMeal);
                NotifyOfPropertyChange(() => FullTicket);
            }
        }

        public string VipSeat
        {
            get { return _vipseat; }
            set { _vipseat = value;
                NotifyOfPropertyChange(()=>VipSeat);
                NotifyOfPropertyChange(() => FullTicket);
                }
        }

        // --- Get and set constructors for addon prices
        public double AMealPrice
        { get { return _amealprice; } 
          set { _amealprice = value;
                NotifyOfPropertyChange(()=>AMealPrice);
                NotifyOfPropertyChange(() => AddonPriceList);
            } 
        
        }
        public double VipPrice 
        { get { return _vipprice; }
            set { _vipprice = value; 
                NotifyOfPropertyChange(() => VipPrice);
                NotifyOfPropertyChange(() => AddonPriceList);
            } 
            
        }


        public double CMealPrice 
        { get { return _cmealprice; }
          set { _cmealprice = value;
                NotifyOfPropertyChange(() => CMealPrice);
                NotifyOfPropertyChange(() => AddonPriceList);
            } 
        }

        // ------------Methods for assigning string and double values to addons when corresponding button pressed
        public void ChildMealAdd()
        {
            ChildMeal = "Sausage, chips & Softdrink";
            CMealPrice = 2.99;
            NotifyOfPropertyChange(() => ChildMeal);
            NotifyOfPropertyChange(()=> CMealPrice);
            NotifyOfPropertyChange(() => AddonPriceList);
            NotifyOfPropertyChange(()=>_addonPriceList);
        }
        public void AdultMealAdd()
        {
            AdultMeal = "Pie, Chips & Pint of Beer";
            AMealPrice = 4.99;
            NotifyOfPropertyChange(() => AdultMeal);
            NotifyOfPropertyChange(()=>AMealPrice);
            NotifyOfPropertyChange(() => AddonPriceList);
        }
        public void VIPSeatadd()
        {
            VipSeat = "VIP priority seating";
            VipPrice = 29.99;
            NotifyOfPropertyChange(() => VipSeat);
            NotifyOfPropertyChange(()=>VipPrice);
            NotifyOfPropertyChange(() => AddonPriceList);
        }



        


        
        // ---- method to give sum value of all addon prices when subtotal button clicked 
        public void SubTotalGive(double sum)
        {
            double Subtotal = sum;
            NotifyOfPropertyChange(()=>Subtotal);
            NotifyOfPropertyChange(()=>AddonPriceList);

        }

        //method to remove text from form -DELETE BEFORE SUBMISSION
        public void ClearText(string firstname, string lastname, string fullname)
        {
            FirstName = "";
            LastName = "";
            AdultMeal = "";
            ChildMeal = "";
            VipSeat = "";
            AMealPrice = 0.00;
            CMealPrice = 0.00;
            VipPrice = 0.00;

        }

        //public bool ChildChecker()
        //{
        //    if (string.SelectedTickName = "Adult")
        //        return true;

        //    else
        //        return false;
        //}

        //method to check if text is in form - DELETE BEFORE SUBMISSION
        //public bool CanClearText(string Firstname, string Lastname)
        //{

        //    if (string.IsNullOrWhiteSpace (Firstname) && string.IsNullOrWhiteSpace(Lastname))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //creates seperate view to show current selections. - DELETE BEFORE SUBMISSION
        public void LoadPageOne()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }

    }
}
