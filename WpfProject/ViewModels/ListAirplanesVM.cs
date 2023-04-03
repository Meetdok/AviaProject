using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Tools;
using WpfProject.WebModels;

namespace WpfProject.ViewModels
{
    public class ListAirplanesVM : BaseTools
    {
        private List<Airplane> airplane;
        private List<AirplanesClass> airplanesClasses;

        public List<Airplane> Airplane
        {
            get => airplane;
            set
            {
                airplane = value;

                Signal();
            }
        }

        public List<AirplanesClass> AirplanesClass
        {
            get => airplanesClasses;
            set
            {
                airplanesClasses = value;

                Signal();
            }
        }

        public ListAirplanesVM()
        {
            Task.Run(async () =>
            {
                var json = await HttpApi.GetInstance().Post("Airplanes", "ListAirplanes", null);
                Airplane = HttpApi.GetInstance().Deserialize<List<Airplane>>(json);

                var json2 = await HttpApi.GetInstance().Post("AirplanesClasses", "ListAirplanesClasses", null);
                AirplanesClass = HttpApi.GetInstance().Deserialize<List<AirplanesClass>>(json);
            });
        }
    }
}
