using CurrencyConverter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModel
{
    public class CurrencyConverterViewModel : Notifier
    {
        private decimal euros;

        public decimal Euros
        {
            get { return euros; }
            set
            {
                euros = value;
                OnPropertyChange("Euros");
                OnEurosChanged();
            }
        }

        private decimal converted;

        public decimal Converted
        {
            get { return converted; }
            set
            {
                converted = value;
                OnPropertyChange("Converted");
            }
        }

        private Currency selectedCurrency;

        public Currency SelectedCurrency
        {
            get { return selectedCurrency; }
            set
            {
                selectedCurrency = value;
                OnPropertyChange("SelectedCurrency");
                OnSelectedCurrencyChanged();
            }
        }

        private IEnumerable<Currency> currencies;

        public IEnumerable<Currency> Currencies
        { 
            get { return currencies; }
            set
            {
                currencies = value;
                OnPropertyChange("Currencies");
            }
        }

        private string resultText;

        public string ResultText
        {
            get { return resultText; }
            set
            {
                resultText = value;
                OnPropertyChange("ResultText");
            }
        }

        public CurrencyConverterViewModel()
        {
            Currencies = new Currency[] { new Currency("US Dollar", 1.0M), new Currency("British Pound", 0.75112M) };
        }

        private void OnEurosChanged()
        {
            ComputeConverted();
        }
        private void OnSelectedCurrencyChanged()
        {
            ComputeConverted();
        }

        private void ComputeConverted()
        {
            if (SelectedCurrency == null)
            {
                return;
            }
            Converted = Euros * SelectedCurrency.Rate;
            ResultText = string.Format("Amount in {0}", SelectedCurrency.Title);
        }
    }
}
