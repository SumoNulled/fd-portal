using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FDPortal.View.UserControls
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
            Loaded += Card_Loaded;
        }

        private async void Card_Loaded(object sender, RoutedEventArgs e)
        {
            int targetNumber = Convert.ToInt32(Number);
            int duration = 400; // Milliseconds
            int incrementInterval = 100; // Milliseconds
            int currentValue = 0;
            int remainingDifference = targetNumber;
            int incrementStep;

            while (currentValue < targetNumber)
            {
                incrementStep = (int)Math.Ceiling((double)remainingDifference / (duration / incrementInterval));
                currentValue += incrementStep;
                if (currentValue > targetNumber)
                    currentValue = targetNumber;

                Number = Convert.ToString(currentValue);
                remainingDifference = targetNumber - currentValue;

                await Task.Delay(incrementInterval);
            }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(Card));

        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(Card));

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(Card));

        public bool IsTechnical
        {
            get { return (bool)GetValue(IsTechnicalProperty); }
            set { SetValue(IsTechnicalProperty, value); }
        }

        public static readonly DependencyProperty IsTechnicalProperty =
            DependencyProperty.Register("IsTechnical", typeof(bool), typeof(Card));
    }
}
