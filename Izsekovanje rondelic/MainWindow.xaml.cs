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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Izsekovanje_rondelic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Width.Text = "50".ToString();
            Length.Text = "100".ToString();
            xDistance.Text = "0".ToString();
            txt_yDistance.Text = "0".ToString();

            tb_R.Text = "5".ToString();
            tb_CircleDistance.Text = "4".ToString();
        }

        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tape trak = new Tape();
            trak.width = int.Parse(Width.Text);
            trak.length = int.Parse(Length.Text);
            trak.xDistance = int.Parse(xDistance.Text);
            trak.yDistance = int.Parse(txt_yDistance.Text);

            tb_Area.Text = trak.GetArea().ToString();
            tb_netArea.Text = trak.GetNetArea().ToString();

            CalcRounds calc = new CalcRounds();
            calc.r = int.Parse(tb_R.Text);
            calc.distance = int.Parse(tb_CircleDistance.Text);

            tb_Temp3.Text = calc.GetNoOfRounds(trak).ToString();
        }
    }
}
