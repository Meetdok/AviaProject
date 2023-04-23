using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Tools;
using WpfProject.WebModels;

namespace WpfProject.ViewModels
{
    public class ListTicketsVM : BaseTools
    {

        private List<Ticket> ticket;

        public List<Ticket> Ticket
        {
            get => ticket;
            set
            {
                ticket = value;

                Signal();
            }
        }


        public ListTicketsVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("Tickets", null, "ListTickets");
                Ticket = HttpApi.Deserialize<List<Ticket>>(json);
               
            });
        }
    }
}
