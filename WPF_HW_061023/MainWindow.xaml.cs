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

namespace WPF_HW_061023
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MonthlyIncomeTextChanged(object sender, TextChangedEventArgs e)
		{
			CalculateMaxCredit();
		}

		private void CreditAmountSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			CalculateMaxCredit();
			DisplayCurrentCredit();
		}

		private void DisplayCurrentCredit()
		{
			double currentCreditAmount = creditAmountSlider.Value;
			currentCreditAmountTextBlock.Text = currentCreditAmount.ToString("C");
		}

		private void CalculateMaxCredit()
		{
			if (double.TryParse(monthlyIncomeTextBox.Text, out double userMonthlyIncome)) {
				double maxCreditAmount = userMonthlyIncome * 5;
				maxCreditAmountTextBlock.Text = maxCreditAmount.ToString("C");

				creditAmountSlider.Maximum = maxCreditAmount;
			} else {
				maxCreditAmountTextBlock.Text = "Некорректный ввод";
			}
		}
	}
}
