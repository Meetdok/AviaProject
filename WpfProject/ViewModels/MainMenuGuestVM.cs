using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfProject.Pages;
using WpfProject.Tools;
using WpfProject.WebModels;
using WpfProject.Windows;

namespace WpfProject.ViewModels
{
    public class MainMenuGuestVM : BaseTools
    {
        CurrentPageControl currentPageControl;

        public Page CurrentPage
        {
            get => currentPageControl.Page;
        }

        private void CurrentPageControl_PageChanged(object sender, EventArgs e)
        {
            Signal(nameof(CurrentPage));
        }

        private List<Airplane> airplane;
        private List<Flight> flight;
        private List<FlightCompany> flightCompanie;

        public List<Flight> Flight
        {
            get => flight;
            set
            {
                flight = value;

                Signal();
            }
        }

        public List<FlightCompany> FlightCompanie
        {
            get => flightCompanie;
            set
            {
                flightCompanie = value;

                Signal();
            }
        }

        public List<Airplane> Airplane
        {
            get => airplane;
            set
            {
                airplane = value;

                Signal();
            }
        }


        public CommandVM nav_airplanes { get; set; }
        public CommandVM nav_companys { get; set; }        

        public MainMenuGuestVM()
        {

            Task.Run(async () =>
            {
                var json = await HttpApi.GetInstance().Post("Flights", "ListFlights", null);
                Flight = HttpApi.GetInstance().Deserialize<List<Flight>>(json);

                var json2 = await HttpApi.GetInstance().Post("Airplanes", "ListAirplanes", null);
                Airplane = HttpApi.GetInstance().Deserialize<List<Airplane>>(json);

                var json3 = await HttpApi.GetInstance().Post("FlightCompanys", "ListFlightCompanys", null);
                FlightCompanie = HttpApi.GetInstance().Deserialize<List<FlightCompany>>(json);

            });


            currentPageControl = new CurrentPageControl();
            currentPageControl.PageChanged += CurrentPageControl_PageChanged;


            nav_airplanes = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListAirplanes());
            });
            
           nav_companys = new CommandVM(() =>
            {
                currentPageControl.SetPage(new ListCompanys());
            });
        }

    }
}
