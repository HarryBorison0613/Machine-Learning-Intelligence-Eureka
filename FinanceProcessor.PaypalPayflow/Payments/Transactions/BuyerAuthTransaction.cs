#region "Imports"

using FinanceProcessor.PaypalPayflow.Payments.Common.Exceptions;
using FinanceProcessor.PaypalPayflow.Payments.DataObjects;

#endregion

namespace FinanceProcessor.PaypalPayflow.Payments.Transactions
{
	/// <summary>
	/// This abstract class serves as base class for 
	/// Buyer auth transactions.
	/// </summary>
	
	public class BuyerAuthTransaction : BaseTransaction
	{
		#region "Constructors"

		/// <summary>
		/// protected Constructor. This prevents
		/// creation of an empty Transaction object. 
		/// </summary>
		protected BuyerAuthTransaction()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="PayflowConnectionData">Connection credentials object.</param>
		/// <param name="RequestId">Request Id</param>
		protected BuyerAuthTransaction(String TrxType, UserInfo UserInfo, PayflowConnectionData PayflowConnectionData, String RequestId)
			: base(TrxType, UserInfo, PayflowConnectionData, RequestId)
		{
		}
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="TrxType">Transaction type</param>
		/// <param name="UserInfo">User Info object populated with user credentials.</param>
		/// <param name="RequestId">Request Id</param>
		protected BuyerAuthTransaction(String TrxType, UserInfo UserInfo, String RequestId)
			: this(TrxType, UserInfo, null, RequestId)
		{
		}

		#endregion

		#region "Core functions"

		/// <summary>
		/// Generates the transaction request.
		/// </summary>
		internal override void GenerateRequest()
		{
			try
			{
				base.GenerateRequest();
			}
			catch (BaseException)
			{
				throw;
			}
			catch (Exception Ex)
			{
				TransactionException TE = new TransactionException(Ex);
				throw TE;
			}
            //catch
            //{
            //    throw new Exception();
            //}
		}

		#endregion
	}

}