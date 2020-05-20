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
using NLog;
using NLog.Config;
using NLog.Targets;
using System.ComponentModel;

namespace Izsekovanje_rondelic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();

            ConfigureNlog();

            tb_Width.Text = "50".ToString();
            tb_Length.Text = "100".ToString();
            tb_xDistance.Text = "0".ToString();
            tb_yDistance.Text = "0".ToString();

            tb_R.Text = "5".ToString();
            tb_CircleDistance.Text = "4".ToString();
        }

        private void ConfigureNlog()
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget
            {
                Name = "file",
                FileName = "log.txt",
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}",
            };
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget, "*");
            LogManager.Configuration = config;
        }

        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tape trak = new Tape();
                trak.width = int.Parse(tb_Width.Text);
                trak.length = int.Parse(tb_Length.Text);
                trak.xDistance = int.Parse(tb_xDistance.Text);
                trak.yDistance = int.Parse(tb_yDistance.Text);

                tb_Area.Text = trak.GetArea().ToString();
                tb_netArea.Text = trak.GetNetArea().ToString();

                CalcRounds calc = new CalcRounds();
                calc.r = int.Parse(tb_R.Text);
                calc.distance = int.Parse(tb_CircleDistance.Text);

                tb_Result.Text = calc.GetNoOfRounds(trak).ToString();
                
                textblock.Text = calc.PrintRoundLocations(trak);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Napaka: "+ex.Message);
            }
        }

        private bool isPositive(string s)
        {
            int n;
            int.TryParse(s, out n);
            if (n > 0)
                return true;
            else
                return false;
        }
    }
}
