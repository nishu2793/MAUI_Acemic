using AceMicEV.Views;
using AceMicEV.Controls;
namespace AceMicEV.Models;

public class AppConstant
{
    public async static Task AddFlyoutMenusDetails()
    {
        AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

        var studentDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(WelcomeScreen)).FirstOrDefault();
        if (studentDashboardInfo != null) AppShell.Current.Items.Remove(studentDashboardInfo);

        var teacherDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(WelcomeScreen)).FirstOrDefault();
        if (teacherDashboardInfo != null) AppShell.Current.Items.Remove(teacherDashboardInfo);

        var adminDashboardInfo = AppShell.Current.Items.Where(f => f.Route == nameof(WelcomeScreen)).FirstOrDefault();
        if (adminDashboardInfo != null) AppShell.Current.Items.Remove(adminDashboardInfo);

        //if
        //{
        //    var flyoutItem = new FlyoutItem()
        //    {
        //        Title = "Dashboard Page",
        //        Route = nameof(WelcomeScreen2),
        //        FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
        //        Items =
        //            {
        //                        new ShellContent
        //                        {
        //                            //Icon = Icons.Dashboard,
        //                            Title = "Admin Dashboard",
        //                            ContentTemplate = new DataTemplate(typeof(WelcomeScreen2)),
        //                        },
        //                        new ShellContent
        //                        {
        //                           // Icon = Icons.AboutUs,
        //                            Title = "Admin Profile",
        //                            ContentTemplate = new DataTemplate(typeof(WelcomeScreen2)),
        //                        },
        //           }
        //    };
        //}
    }
}