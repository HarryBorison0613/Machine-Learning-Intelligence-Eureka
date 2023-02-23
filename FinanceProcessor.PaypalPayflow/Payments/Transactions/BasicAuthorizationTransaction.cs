#region "Imports"

using FinanceProcessor.PaypalPayflow.Payments.DataObjects;

#endregion

namespace FinanceProcessor.PaypalPayflow.Payments.Transactions
{
	/// <summary>
	/// Summary description for BasicAuthorizationTransaction.
	/// </summary>
	internal class BasicAuthorizationTransaction : AuthorizationTransaction
	{
		#region "Constructors"
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Tender"></param>
		/// <param name="Invoice"></param>
		/// <param name="UserInfo"></param>
		/// <param name="PayflowConnectionData"></param>
		/// <param name="RequestId"></param>
		public BasicAuthorizationTransaction (PayPalTender Tender, Invoice Invoice, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId) 
			: base("B" ,UserInfo ,PayflowConnectionData ,Invoice ,Tender   ,RequestId)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Tender"></param>
		/// <param name="Invoice"></param>
		/// <param name="UserInfo"></param>
		/// <param name="RequestId"></param>
		public BasicAuthorizationTransaction (PayPalTender Tender, Invoice Invoice, UserInfo UserInfo, String RequestId) 
			: base("B", UserInfo ,Invoice , Tender ,RequestId)
		{
		}
		#endregion

	}
}
