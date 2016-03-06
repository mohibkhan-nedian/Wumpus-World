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


namespace wumpus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        mybutton[,] squares = new wumpus.mybutton[4, 4];
        bool Have_Gold = false;
        static int neighbours;
        static int m, n;
        static int goto_another,inbreeze;
        public MainWindow()
        {
            InitializeComponent();
            design();
        }


        void design()
        {
            int x = 500, y = 400;
            int[] sum = new int[12];


            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    squares[i, j] = new mybutton();
                    squares[i, j].Height = 100;
                    squares[i, j].Width = 100;
                    squares[i, j].Margin = new Thickness(x, y, 0, 0);
                    squares[i, j].HorizontalAlignment = HorizontalAlignment.Left;
                    squares[i, j].VerticalAlignment = VerticalAlignment.Top;
                    squares[i, j].Background = new SolidColorBrush(Colors.Gray);
                    squares[i, j].Click += new RoutedEventHandler(Clicks);
                    squares[i, j].FontSize = 50;
                    squares[i, j].Content = i.ToString() + "," + j.ToString();
                    squares[i, j].IsEnabled = false;
                    x += 100;
                    grid.Children.Add(squares[i, j]);
                }
                x = 500;
                y -= 100;
            }
            squares[0, 0].Background = new SolidColorBrush(Colors.Blue);
            squares[0, 0].IsEnabled = true;
            squares[0, 1].IsEnabled = true;
            squares[1, 0].IsEnabled = true;


            squares[0, 1].isbreeze = true;
            squares[0, 2].ispit = true;
            squares[0, 3].isbreeze = true;

            squares[1, 0].isstench = true;

            squares[1, 2].isbreeze = true;

            squares[2, 0].iswumpus = true;

            squares[2, 1].isgold = true; ;
            squares[2, 1].isbreeze = true;
            squares[2, 1].isstench = true;

            squares[2, 2].ispit = true;

            squares[2, 3].isbreeze = true;

            squares[3, 0].isstench = true;

            squares[3, 2].isbreeze = true;

            squares[3, 3].ispit = true;


        }
        void Clicks(object sender, RoutedEventArgs e)
        {
            stench_val.Text = ((mybutton)sender).isstench.ToString();
            breeze_val.Text = ((mybutton)sender).isbreeze.ToString();
            glitter_val.Text = ((mybutton)sender).isgold.ToString();
            wump_val.Text = ((mybutton)sender).iswumpus.ToString();
            pit_val.Text = ((mybutton)sender).ispit.ToString();

            string[] label = ((mybutton)sender).Content.ToString().Split(',');

            int i = int.Parse(label[0]);
            int j = int.Parse(label[1]);
            m = i; n = j;
            if (i == 0 && j == 0)
            {
                if (Have_Gold == true)
                {
                    MessageBox.Show("You Won! Great play.");
                    this.Close();
                }
            }


            if (squares[i, j].isgold == true)
            {
                squares[i, j].Background = new SolidColorBrush(Colors.Yellow);
                MessageBox.Show("You got the Gold. Now surf back safely.");
                pic.Visibility = Visibility.Visible;
                Have_Gold = true;
                score.Text = (int.Parse(score.Text)+100).ToString();
            }

            if (squares[i, j].iswumpus == true)
            {
                squares[i, j].Background = new SolidColorBrush(Colors.Red);
                MessageBox.Show("You lost! As it contains Wumpus.");
                this.Close();
            }

            if (squares[i, j].ispit == true)
            {
                squares[i, j].Background = new SolidColorBrush(Colors.Red);
                MessageBox.Show("You lost! As it contains Pit.");
                this.Close();
            }
            int a = i - 1;
            int b = i + 1;
            int c = j - 1;
            int d = j + 1;

            bool t = false;
            bool f = false;

            if (a >= 0)
                t = true;
            if (c >= 0)
                f = true;

            for (int k = 0; k < 4; k++)
            {
                for (int p = 0; p < 4; p++)
                {
                    squares[k, p].IsEnabled = false;
                }
            }
            if (b < 4)
            {
                squares[i + 1, j].IsEnabled = true;
                neighbours++;
            }
            if (d < 4)
            {
                squares[i, j + 1].IsEnabled = true;
                neighbours++;
            }
            if (t == true)
            {
                squares[a, j].IsEnabled = true;
                neighbours++;
            }
            if (f == true)
            {
                squares[i, c].IsEnabled = true;
                neighbours++;
            }
            score.Text = (int.Parse(score.Text) + 10).ToString();
        }

        private void fire_Click(object sender, RoutedEventArgs e)
        {

            fire.IsEnabled = false;
            score.Text = (int.Parse(score.Text)-10).ToString();
            int a = m - 1;
            int b = m + 1;
            int c = n - 1;
            int d = n + 1;

            bool t = false;
            bool f = false;

            if (a >= 0)
                t = true;
            if (c >= 0)
                f = true;

            if (b < 4)
                if (squares[m + 1, n].iswumpus == true)
                {
                    scream.Visibility = Visibility.Visible;
                    squares[m + 1, n].iswumpus = false;
                    MessageBox.Show("Gr8, You killed the Wumpus.");
                }
            if (d < 4)
                if (squares[m, n + 1].iswumpus == true)
                {
                    scream.Visibility = Visibility.Visible;
                    squares[m, n + 1].iswumpus = false;
                    MessageBox.Show("Gr8, You killed the Wumpus.");
                }
            if (t == true)
                if (squares[a, n].iswumpus == true)
                {
                    scream.Visibility = Visibility.Visible;
                    squares[m, n + 1].iswumpus = false;
                    MessageBox.Show("Gr8, You killed the Wumpus.");
                }
            if (f == true)
                if (squares[m, c].iswumpus == true)
                {
                    scream.Visibility = Visibility.Visible;
                    squares[m, n + 1].iswumpus = false;
                    MessageBox.Show("Gr8, You killed the Wumpus.");
                }
            if (scream.Visibility == Visibility.Collapsed)
            {
                scream.Text = "Wrong Hit! -10 from score";
                scream.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            design();
            score.Text = "0";
            fire.IsEnabled = true;
            scream.Visibility = Visibility.Collapsed;
            scream.Text = "Scream";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            squares[0, 0].Background = new SolidColorBrush(Colors.Gray);
            neighbours--;
           
            int h = 0;
            int i=0, j=0;
            for ( i = 0; i < 4; i++)
            {
                for ( j = 0; j < 4; j++)
                {
                    if (squares[i, j].IsEnabled == true) break;                      
                }
                if (h == 0) break;
            }

            if (squares[i, j].isbreeze == true)
            { i = i + 1; j--; inbreeze = 1; }
            if(inbreeze!=1)
                if (squares[i, j].isstench == true)
                { i = i + 1; j--; }
            squares[i, j].isCurrent = true;
            squares[i, j].Background = new SolidColorBrush(Colors.Blue);

            int a = i - 1;
            int b = i + 1;
            int c = j - 1;
            int d = j + 1;

            bool t = false;
            bool f = false;

            if (a >= 0)
                t = true;
            if (c >= 0)
                f = true;

            for (int k = 0; k < 4; k++)
            {
                for (int p = 0; p < 4; p++)
                {
                    squares[k, p].IsEnabled = false;
                }
            }


           

            if (b < 4)
                squares[i + 1, j].IsEnabled = true;
            if (d < 4)
                squares[i, j + 1].IsEnabled = true;
            if (t == true)
                squares[a, j].IsEnabled = true;
            if (f == true)
                squares[i, c].IsEnabled = true;

            score.Text = (int.Parse(score.Text) + 10).ToString();
        

        }
    }
}
