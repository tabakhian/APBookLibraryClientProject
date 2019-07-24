using System;
using System.Threading.Tasks;

namespace LibraryManagmentConnectSDK
{
	public class ServerConnection
	{
		public string LibraryAuthCode { get; set; }
		public string UserAuthCode { get; set; }
		public ServerConnection()
		{

		}

		public void SetUser(string authCode)
		{
			UserAuthCode = authCode;
		}
		public void SetLibrary(string authCode)
		{
			LibraryAuthCode = authCode;
		}

		public bool CheckServerAvailability(bool isFirstTime = false)
		{
			bool returnValue = false;
			if (!isFirstTime)
			{
				if (!ConnectionSetting.ConnectedToServer)
				{
					return (false);
				}
			}
			try
			{
				var reply = ConnectionSetting.LibraryManagerClient.ServerAvailable(new HelloRequest { });
				returnValue = reply.IsSuccessfull;
			}
			catch (Exception ex)
			{

			}

			return(returnValue);
		}
		public LibraryRegisterReply LibraryRegister(LibraryRegisterRequest request)
		{
			
			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			LibraryRegisterReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.LibraryRegister(request);
			}
			catch (Exception )
			{

			}

			return (oReply);
		}
		public LibraryEditReply LibraryEdit(LibraryEditRequest request)
		{
			request.AuthCode = LibraryAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			LibraryEditReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.LibraryEdit(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public AddUserReply AddUser(AddUserRequest request)
		{
			request.AuthCode = LibraryAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			AddUserReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.AddUser(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public AddBookReply AddBook(AddBookRequest request)
		{
			request.AuthCode = LibraryAuthCode;
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			AddBookReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.AddBook(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public RemoveBookReply AddBook(RemoveBookRequest request)
		{
			request.AuthCode = LibraryAuthCode;
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			RemoveBookReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.RemoveBook(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public BookDetailReply BookDetail(BookDetailRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			BookDetailReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.BookDetail(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public BookListReply BookList(BookListRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			BookListReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.BookList(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public RentABookReply RentABook(RentABookRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			RentABookReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.RentABook(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public AcceptRentRequestReply AcceptRentRequest(AcceptRentRequestRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			AcceptRentRequestReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.AcceptRentRequest(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public RejectRentRequestReply RejectRentRequest(RejectRentRequestRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			RejectRentRequestReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.RejectRentRequest(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public CancelRentRequestBookReply CancelRentRequestBook(CancelRentRequestBookRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			CancelRentRequestBookReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.CancelRentRequestBook(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public CancelRentBookReply CancelRentBook(CancelRentBookRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			CancelRentBookReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.CancelRentBook(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public ReturnRentedBookReply ReturnRentedBook(ReturnRentedBookRequest request)
		{
			request.UserAuthCode = UserAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			ReturnRentedBookReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.ReturnRentedBook(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public BookRentingSystemListReply BookRentingSystemList(BookRentingSystemListRequest request)
		{
			request.UserAuthCode = UserAuthCode;
			request.AuthCode = LibraryAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			BookRentingSystemListReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.BookRentingSystemList(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
		public BookRentingSystemNotificationCountReply BookRentingSystemNotificationCount(BookRentingSystemNotificationCountRequest request)
		{
			request.UserAuthCode = UserAuthCode;
			request.AuthCode = LibraryAuthCode;

			if (!ConnectionSetting.ConnectedToServer)
			{
				return (null);
			}

			BookRentingSystemNotificationCountReply oReply = null;
			try
			{
				oReply = ConnectionSetting.LibraryManagerClient.BookRentingSystemNotificationCount(request);
			}
			catch (Exception)
			{

			}

			return (oReply);
		}
	}
}
