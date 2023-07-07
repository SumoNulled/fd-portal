using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.IconPacks;

namespace FDPortal.View.UserControls
{
    /// <summary>
    /// Interaction logic for SidebarButton.xaml
    /// </summary>
    public partial class SidebarButton : UserControl
    {
        public SidebarButton()
        {
            InitializeComponent();
        }

        public PackIconMaterialKind Icon
        {
            get { return (PackIconMaterialKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PackIconMaterialKind), typeof(SidebarButton));

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(SidebarButton));

        private static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(SidebarButton));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Set the IsActive property of the clicked button to true
            IsActive = true;

            // Get the parent StackPanel
            var stackPanel = Parent as StackPanel;
            if (stackPanel != null)
            {
                // Iterate over the child buttons
                foreach (var childButton in stackPanel.Children)
                {
                    if (childButton is SidebarButton button && button != this)
                    {
                        // Set the IsActive property of other buttons to false
                        button.IsActive = false;
                    }
                }
            }
        }
    }
}
