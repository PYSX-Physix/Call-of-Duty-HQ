using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Call_of_Duty_HQ.Views;

public partial class Popup : Window
{
    public bool IsQuestion;

    public Popup()
    {
        InitializeComponent();
        if (IsQuestion == true)
        {
            //TODO: Add some booleans to make use of the popup window more modular
        }
    }
}