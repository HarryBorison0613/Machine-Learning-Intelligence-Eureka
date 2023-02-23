#region "Imports"

using FinanceProcessor.PaypalPayflow.Payments.Common.Logging;
using FinanceProcessor.PaypalPayflow.Payments.Common.Utility;

#endregion

namespace FinanceProcessor.PaypalPayflow.Payments.Communication
{
	/// <summary>
	/// Represents transaction receive state.
	/// </summary>
	internal class TransactionReceiveState : ReceiveState
	{
		#region "Constructors"

		/// <summary>
		/// Copy constructor for TransactionReceiveState.
		/// </summary>
		/// <param name="CurrentPaymentState">Current Payment State object.</param>
		public TransactionReceiveState(PaymentState CurrentPaymentState) : base(CurrentPaymentState)
		{
		}

		#endregion		

		#region "Functions"

		/// <summary>
		/// Sets the received response
		/// </summary>
		/// <param name="Response">response</param>
		/// <returns>true if response set, false otherwise.</returns>
		public override bool SetReceiveResponse(String Response)
		{
			bool RetVal = false;
			Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Entered.", PayflowConstants.SEVERITY_DEBUG);
            if (Response == null)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Response = null", PayflowConstants.SEVERITY_WARN);
				RetVal = false;
			}
			else if (Response.Length == 0)
			{
				Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Response.Length = 0", PayflowConstants.SEVERITY_WARN);
				RetVal = false;
			}
			else
			{
				TransactionResponse = Response;
				Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Response = " + TransactionResponse, PayflowConstants.SEVERITY_INFO);
				RetVal = true;
			}

            SetProgressComplete();


			Logger.Instance.Log("PayPal.Payments.Communication.TransactionReceiveState.SetReceiveResponse(String): Exiting.", PayflowConstants.SEVERITY_DEBUG);
			return RetVal;
		}

		#endregion
	}
}