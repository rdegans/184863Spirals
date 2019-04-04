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

namespace _184863Spirals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            //starts at second number and labels as starting value, ex doesnt show middle and first one down is shown as starting value
            lblOutput.Content = "";
            int x, y;
            int.TryParse(txtInput.Text.Split(',')[0], out x);
            int.TryParse(txtInput.Text.Split(',')[1], out y);
            int[] xPosition = new int[y - x + 1];
            int[] yPosition = new int[y - x + 1];
            int[] numValues = new int[y - x + 1];
            int[] directionX = new int[4];
            int[] directionY= new int[4];
            directionX[0]= 0;
            directionX[1]= 1;
            directionX[2]= 0;
            directionX[3]= -1;
            directionY[0]= -1;
            directionY[1]= 0;
            directionY[2]= 1;
            directionY[3]= 0;
            int sideLength = 1;
            int sideTimes = 0;
            int side = 0;
            int moveCounter = -1;
            for (int i = 0; i<numValues.Length; i++)
            {
                if (i > 0)
                {
                    xPosition[i] = xPosition[i - 1] + directionX[side % 4];
                    yPosition[i] = yPosition[i - 1] + directionY[side % 4];
                }
                else
                {
                    xPosition[i] = 0;
                    yPosition[i] = 0;
                }
                numValues[i] = x + i;
                moveCounter++;
                if (moveCounter == sideLength)
                {
                    sideTimes++;
                    side++;
                    moveCounter = 0;
                }
                if (sideTimes == 2)
                {
                    sideLength++;
                    sideTimes = 0;
                }
            }
            for (int z = 0; z< numValues.Length; z++)
            {
                lblOutput.Content += numValues[z] + " " + xPosition[z] + " " + yPosition[z] + Environment.NewLine;
            }
        }
    }
}
