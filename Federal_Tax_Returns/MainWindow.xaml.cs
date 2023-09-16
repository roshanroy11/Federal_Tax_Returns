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

namespace Federal_Tax_Returns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double Tax_Rate;
        double Dependent;
        double Gross_Income, Mortgage_Interest, Total = 0
            , Chartiable_Deduction, Tax, Total_Tax_Rate, Tax_Refund;
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
           txtFirst_Name.Clear();
           txtLast_Name.Clear();
           txtSocial_Security_Number.Clear();
           txtGross_Income.Clear();
           txtCharitable_Deduction.Clear();
           txtMortgage_Interest.Clear();
           txtTax_Already_Paid.Clear();
           txtOwe_or_Refund.Text = "";
           txtTax_Refund.Text = "";
           txtTax_Owe.Text = "";
           radSingle.IsChecked = true;
           radMarried.IsChecked = false;
           radMarriage_Filing_Separately.IsChecked = false;
           radHead_of_Household.IsChecked = false;
           cboNo_of_Dependents.SelectedIndex = 0;
        }

        private void txtFirst_Name1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtLast_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSocial_Security_Number_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void radHead_of_Household_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cboFilling_Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtCharitable_Deduction_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtMortgage_InterestTextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string f_name = txtFirst_Name.Text;
            string l_name = txtLast_Name.Text;
            string ssn = txtSocial_Security_Number.Text;
            string no_of_Dep = cboNo_of_Dependents.Text;
            string gross_inc = txtGross_Income.Text;
            string charity_Deduct = txtCharitable_Deduction.Text;
            string mort_interest = txtMortgage_Interest.Text;
            string tax_alr_paid = txtTax_Already_Paid.Text;
           

                if (string.IsNullOrEmpty(f_name) || !IsAlphabetic(f_name))
                {
                    MessageBox.Show("Please Enter a Valid First Name ");
                    return;
                }

                if(string.IsNullOrEmpty(l_name) || !IsAlphabetic(l_name))
                {
                    MessageBox.Show("Please Enter a Valid Last Name ");
                    return;
                }

                if (string.IsNullOrEmpty(ssn))
                {
                    MessageBox.Show("Please Enter your SSN");
                }
                else if (ssn.Length !=9 || !IsNumeric(ssn))
                {
                    MessageBox.Show("Please Enter a Valid 9-Digit SSN");
                }

                if (string.IsNullOrEmpty(no_of_Dep))
                {
                    MessageBox.Show("Please Select the Number of Dependents");
                }

                if (string.IsNullOrEmpty(gross_inc) || !IsNumeric(gross_inc))
                {
                    MessageBox.Show("Please Enter a Valid Gross Income Amount");
                    return;
                }

                if (string.IsNullOrEmpty(charity_Deduct) || !IsNumeric(charity_Deduct))
                {
                    MessageBox.Show("Please Enter a Valid Charitable Deduction Amount");
                    return;
                }

                if (string.IsNullOrEmpty(mort_interest) || !IsNumeric(mort_interest))
                {
                    MessageBox.Show("Please Enter a Valid Mortgage Interest Amount");
                    return;
                }

                if (string.IsNullOrEmpty(tax_alr_paid) || !IsNumeric(tax_alr_paid))
                {
                    MessageBox.Show("Please Enter a Valid Tax Already Paid Amount");
                    return;
                }

            Gross_Income = Convert.ToInt32(gross_inc);
            gross_inc = Gross_Income.ToString("C");
            Chartiable_Deduction = Convert.ToInt32(charity_Deduct);
            charity_Deduct = Chartiable_Deduction.ToString("C");
            Mortgage_Interest = Convert.ToInt32(mort_interest);
            mort_interest = Mortgage_Interest.ToString("C");

            {
                if (cboNo_of_Dependents.SelectedIndex == 0)
                {
                    Dependent = 0 * 5000;
                }

                else if (cboNo_of_Dependents.SelectedIndex == 1)
                {
                    Dependent = 1 * 5000;
                }

                else if (cboNo_of_Dependents.SelectedIndex == 2)
                {
                    Dependent = 2 * 5000;
                }

                else if (cboNo_of_Dependents.SelectedIndex == 3)
                {
                    Dependent = 3 * 5000;
                }

                else if (cboNo_of_Dependents.SelectedIndex == 4)
                {
                    Dependent = 4 * 5000;
                }

                else if (cboNo_of_Dependents.SelectedIndex == 5)
                {
                    Dependent = 5 * 5000;
                }
            }


            {
                if (radSingle.IsChecked == true)
                {
                    Tax_Rate = 0.25;
                }
                else if (radMarried.IsChecked == true)
                {
                    Tax_Rate = 0.18;
                }
                else if (radMarriage_Filing_Separately.IsChecked == true)
                {
                    Tax_Rate = 0.22;
                }
                else if (radHead_of_Household.IsChecked == true)
                {
                    Tax_Rate = 0.20;
                }
            }

            Total = (Gross_Income - Dependent - Chartiable_Deduction - Mortgage_Interest);
            Total_Tax_Rate = Total * Tax_Rate;
            Tax = Total_Tax_Rate - Convert.ToInt32(tax_alr_paid);
            tax_alr_paid = Total_Tax_Rate.ToString("C");

            if (Tax > 0) 
            {
                txtOwe_or_Refund.Text = "Owe";
                txtTax_Owe.Text = Tax.ToString("C");
                txtTax_Refund.Text = "0";
            }
            else
            {
                Tax_Refund = -(Tax);
                txtOwe_or_Refund.Text = "Refund";
                txtTax_Owe.Text = "0";
                txtTax_Refund.Text = Tax_Refund.ToString("C");

            }

        }

        private bool IsAlphabetic(string input)
        {
            return input.All(char.IsLetter);
        }
        private bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }
    }
}
