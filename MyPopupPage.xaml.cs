using AceMicEV.Views;
using Mopups.Services;

namespace AceMicEV;

public partial class MyPopupPage 
{
	public MyPopupPage(string Status, string OrderId, string PaymentId, string Amount, string Email, string Paymentorderid)
	{
		InitializeComponent();
		lblStatus.Text = Status;
		lblOrderId.Text = OrderId;
		lblPaymentId.Text = PaymentId;
		lblAmount.Text = Amount;
		lblEmail.Text = Email;
		lblPaymentorderid.Text = Paymentorderid;
	}

    private void SuccesFull_Clicked(object sender, EventArgs e)
    {

    }
}
