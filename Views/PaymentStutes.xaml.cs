using AceMicEV.Views;
namespace AceMicEV.Views;
public partial class PaymentStutes : ContentPage
{
    public PaymentStutes(string Status, string OrderId, string PaymentId, string Amount, string Email, string Paymentorderid)
    {
        InitializeComponent();

        if (Status == "Complete")
        {
            imgtag.Source = "success.png";
            lblStatus.Text = "Payment Successfull!";
        }
        else
        {
            imgtag.Source = "fail.png";
            lblStatus.Text = "Payment Fail";
        }

        lblStatus.Text = Status;
            lblOrderId.Text = OrderId;
            lblPaymentId.Text = PaymentId;
            lblAmount.Text = Amount;
            lblEmail.Text = Email;
            lblPaymentorderid.Text = Paymentorderid;
    }

    private double width = 0;
    private double height = 0;
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (width != this.width || height != this.height)
        {
            this.width = width;
            this.height = height;
            outerStack2.WidthRequest = width;
            outerStack2.HeightRequest = height;
        }
    }

    private void successlicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MapPage());
    }
}