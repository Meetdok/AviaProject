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
                var json = await HttpApi.GetInstance().Post("Tickets", "ListTickets", null);
                Ticket = HttpApi.GetInstance().Deserialize<List<Ticket>>(json);
               
            });
        }
    }
}
