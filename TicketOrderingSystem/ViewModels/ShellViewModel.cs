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

        public ShellViewModel()
        {
            Ticket.Add(new TicketModel { Name = "Adult", Description = "Standard seated accomodation for single adult", Price = 19.99 });
            Ticket.Add(new TicketModel { Name = "O.A.P", Description = "Standard seated accomodation for single pensioner", Price = 13.99 });
            Ticket.Add(new TicketModel { Name = "Child", Description = "Standard seated accomodation for single child", Price = 9.99 });
            Ticket.Add(new TicketModel { Name = "Student", Description = "Standard seated accomodation for single student", Price = 14.99});

        }

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
            get { return $"{FirstName } { LastName }"; }

        }

        private BindableCollection<TicketModel> _ticket = new BindableCollection<TicketModel>();
        //Bindable collection in MVVM is essentaily a list
        public BindableCollection<TicketModel> Ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }

        private TicketModel _selectedTicket;

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

        //method to remove text from form
        public void ClearText(string firstname, string lastname)
        {
            FirstName = "";
            LastName = "";
        }

        //method to check if text is in form 
        public bool CanClearText(string firstname, string lastname)
        { 

            if(string.IsNullOrWhiteSpace(firstname) && string.IsNullOrWhiteSpace(lastname))
            {
                return false;
            }
            else 
            {
                return true; 
            }
        }

        //creates seperate view to show current selections.
        public void LoadPageOne()
        {
            ActivateItemAsync(new FirstChildViewModel());
        }

    }
}
