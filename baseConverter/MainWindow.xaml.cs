using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace baseConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double n;
        double b;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void convertButton_Click(object sender, RoutedEventArgs e) // TO DO: Use A->F to convert to up to hexadecimal base (16) -- A=10, B=11, C=12, D=13, E=14, F=15
        {                                                                   //       Convert back into base 10 from base n. Convert letters into binary and/or hexadecimal.
            try
            {
                b = Convert.ToInt32(bTextBox.Text);
                n = Convert.ToInt32(nTextBox.Text);
                if (b >= 2 && b <= 9)
                {
                    if (System.Math.Abs(n) <= b)
                        oTextBox.Text = n.ToString();
                    else if (n > 0)
                        oTextBox.Text = convertNum(n, 0, b, 0).ToString();
                    else if (n < 0)
                        oTextBox.Text = (-1 * convertNum(-n, 0, b, 0)).ToString();
                }
                else
                    oTextBox.Text = "Please enter a base anywhere from 2 to 9.";
            }
            catch
            {
                oTextBox.Text = "Please only enter valid arguments!";
            }
            
        }
        private double convertNum(double n, double i, double b, int power)
        {
            while (exponent(b, power) <= n)
            {
                power++;
            }
            power--;
            i += exponent(10, power);
            n -= exponent(b, power);
            if (n < b)
            {
                i += n;
                n -= n;
            }
            else if (n == b)
            {
                i += 10;
                n -= 10;
            }
            else if (n > b)
                i = convertNum(n, i, b, 0);
            return i;
        }
        private double exponent(double b, int exp)
        {
            double temp = b;
            if (exp >= 2)
            {
                for (int i = 2; i < exp; i++)
                {
                    temp = temp * b;
                }
            }
            else if (exp == 0)
                temp = 1;
            return temp;
        }
        private int abs(int a)
        {
            if (a >= 0)
                return a;
            else
                return -a;
        }

        private void nTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (nTextBox.Text == "Number")
                nTextBox.Text = "";
        }

        private void nTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (nTextBox.Text == "")
                nTextBox.Text = "Number";
        }

        private void bTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (bTextBox.Text == "Base")
                bTextBox.Text = "";
        }

        private void bTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (bTextBox.Text == "")
                bTextBox.Text = "Base";
        }
    }
}