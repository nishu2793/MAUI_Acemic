using AceMicEV.Controls;
using AceMicEV.Views;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace AceMicEV.Views;

public partial class ChargeStatus : BaseViewModel
{
    public ChargeStatus()
    {
       AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

    }
}