using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfProject.Tools;
using WpfProject.ViewModels;
using WpfProject.WebModels;

namespace WpfProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AirplanesAdd.xaml
    /// </summary>
    public partial class AirplanesAdd : Window
    {
        public AirplanesAdd()
        {
            InitializeComponent();
            DataContext = new ListAirplanesVM();
        }

        private async void SaveAirplane(object sender, RoutedEventArgs e)
        {
            var json = await HttpApi.Post("Airplanes", "save", new Airplane
            {
                AirplaneTitle = txt_Name.Text,
                Places = int.Parse(txt_Seats.Text),
                Class = new AirplanesClass { ClassName = txt_Class.Text }
            });
            Airplane result = HttpApi.Deserialize<Airplane>(json);

            MessageBox.Show("Сохранилось!");            
        }
    }
}
