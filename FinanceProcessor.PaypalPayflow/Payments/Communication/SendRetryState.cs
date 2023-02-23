namespace FinanceProcessor.PaypalPayflow.Payments.Communication
{
	internal class SendRetryState : RetryState
	{
		public SendRetryState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}
	}
}