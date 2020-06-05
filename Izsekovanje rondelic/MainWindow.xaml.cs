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
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            ConfigureNlog();
            DataContext = new ViewModel();
            InitializeComponent();
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

                Tape trak = new Tape(length, width, xDist, yDist);
                Round rondelica = new Round(r, distance);

                IRoundsPattern roundsPattern = new TriangularRoundsPattern(trak, rondelica);

                tb_Result.Text = roundsPattern.CalcNoOfRounds().ToString();
                textblock.Text = roundsPattern.PrintRoundLocations();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Napaka: " + ex.Message);
            }
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            button_Calculate.IsEnabled = Validation.GetHasError(tb) == true ? false : true;
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
    }
}
