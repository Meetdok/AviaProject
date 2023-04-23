using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Tools;
using WpfProject.WebModels;

namespace WpfProject.ViewModels
{
    public class ListCompanysVM : BaseTools
    {
        private List<FlightCompany> flightCompany;
        private List<Service> services;

        public List<FlightCompany> FlightCompany
        {
            get => flightCompany;
            set
            {
                flightCompany = value;

                Signal();
            }
        }

        public List<Service> Service
        {
            get => services;
            set
            {
                services = value;

                Signal();
            }
        }

        public ListCompanysVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.Post("FlightCompanies", null, "ListFlightCompanys");
                FlightCompany = HttpApi.Deserialize<List<FlightCompany>>(json);

                var json2 = await HttpApi.Post("Services", null, "ListServices");
                Service = HttpApi.Deserialize<List<Service>>(json);
            });
        }
    }
}
