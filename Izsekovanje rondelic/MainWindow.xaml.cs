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

            DataContext = new Tape();
        }

        /*
         * Konfiguracija NLoga
         */
        // TODO: potrebno prestaviti v config datoteko
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int length = int.Parse(tb_Length.Text);
                int width = int.Parse(tb_Width.Text);
                int xDist = int.Parse(tb_xDistance.Text);
                int yDist = int.Parse(tb_yDistance.Text);
                int r = int.Parse(tb_R.Text);
                int distance = int.Parse(tb_CircleDistance.Text);
                Tape trak = new Tape(length, width, xDist, yDist, r, distance);
                
                CalcRounds calc = new CalcRounds();
                // izpis rezultatov
                tb_Result.Text = calc.GetNoOfRounds(trak).ToString();
                textblock.Text = calc.PrintRoundLocations(trak);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Napaka: "+ex.Message);
            }
        }

        private void tb_yDistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            button_Calculate.IsEnabled = Validation.GetHasError(tb) == true ? false : true;
        }

        private void tb_xDistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            button_Calculate.IsEnabled = Validation.GetHasError(tb) == true ? false : true;
        }

        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            button_Calculate.IsEnabled = Validation.GetHasError(tb) == true ? false : true;
        }

        private void tb_Width_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            button_Calculate.IsEnabled = Validation.GetHasError(tb) == true ? false : true;
        }

        private void tb_R_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            button_Calculate.IsEnabled = Validation.GetHasError(tb) == true ? false : true;
        }

        private void tb_CircleDistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            button_Calculate.IsEnabled = Validation.GetHasError(tb) == true ? false : true;
        }
    }
}
