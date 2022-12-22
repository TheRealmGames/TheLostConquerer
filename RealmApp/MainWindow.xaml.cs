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

namespace RealmApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUp();
        }

        public void SetUp()
        {
            double screenheight = SystemParameters.PrimaryScreenHeight;
            double screenwidth = SystemParameters.PrimaryScreenWidth;
            double playgroundheight = screenheight - 295;
            double playgroundwidth = screenwidth - 200;
            playground.Margin = new Thickness(100, 100, 100, 100);
            playground.Height = playgroundheight;
            playground.Width = playgroundwidth;
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Color.FromRgb(50, 50, 50);
            playground.Background = brush;
            Grid[] rows = new Grid[10];

            int gBal = 1000;
            for (int i = 0; i < rows.Length; i++)
            {
                int col = 0;
                rows[i] = new Grid();
                rows[i].Height = playgroundheight / 10;
                ColumnDefinition[] cols = new ColumnDefinition[20];
                Button[] divisions = new Button[20];
                for (int i2 = 0; i2 < cols.Length; i2++)
                {
                    cols[i2] = new ColumnDefinition();
                    cols[i2].Width = new GridLength(playgroundwidth / 20);
                    rows[i].ColumnDefinitions.Add(cols[i2]);
                    for (int i3 = 0; i3 < divisions.Length; i3++)
                    {
                        divisions[i3] = new Button()
                        {
                            Background = brush
                        };
                        divisions[i3].Click += new RoutedEventHandler((object sender, RoutedEventArgs e) =>
                        {
                            Button s = sender as Button;
                            switch (s.Background == Brushes.Red)
                            {
                                case true:
                                    break;
                                case false:
                                    switch (gBal > 1000 || gBal == 1000)
                                    {
                                        case true:
                                            s.Background = Brushes.Red;
                                            gBal -= 1000;
                                            goldLabel.Content = "GOLDS: " + gBal;
                                            break;
                                        case false:
                                            break;
                                    }
                                    break;
                            }
                            
                            
                        });
                        rows[i].Children.Add(divisions[i3]);
                        Grid.SetColumn(divisions[i3], col);
                    }
                    col++;
                }
                playground.Children.Add(rows[i]);
            }

            goldBtn.Background = brush;
            goldBtn.Click += new RoutedEventHandler((object sender, RoutedEventArgs e) =>
            {
                goldLabel.Content = "GOLDS: " + gBal;
                gBal += 500;
            });
        }
    }
}
