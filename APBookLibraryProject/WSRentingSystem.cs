using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
	public partial class WSRentingSystem : BaseAuthenticatedDataForm
	{
		public WSRentingSystem()
		{
			InitializeComponent();
		}

		private void WSRentingSystem_Load(object sender, EventArgs e)
		{
			FillDataMethod();
		}

		public void FillDataMethod()
		{
			LibraryManagmentConnectSDK.BookRentingSystemListReply oReply =
				libraryManagerConnection.BookRentingSystemList(new LibraryManagmentConnectSDK.BookRentingSystemListRequest { });
			if (oReply == null || !oReply.IsSuccessfull)
			{
				MessageBox.Show("An Error Occured in Get Books Lists From The Server, Try Again ! \n With Error Message : "
					+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Get Books List Error!", MessageBoxButtons.OK);
				this.Close();
				return;
			}

			var newRequests = oReply.NewRentRequestList.ToList();
			List<object[]> newRequestsGridVireData = new List<object[]>();
			foreach (var item in newRequests)
			{
				var row = new object[] {
					Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(item.BookImageData.ToByteArray())), 40, 40),
					item.BookName,
					item.UserFullName,
					item.UserLibraryName,
					item.Time,
					item.Context,
					"Accept",
					"Reject",
					item.RentRequestCode,
				};

				newRequestsGridVireData.Add(row);
			}

			foreach (var item in newRequestsGridVireData)
			{
				gridviewRentingRequest.Rows.Add(item);
			}

			/////////////////////////

			var leasedBooks = oReply.BookRentedList.ToList();
			List<object[]> leasedBooksGridViewData = new List<object[]>();
			foreach (var item in leasedBooks)
			{
				var row = new object[] {
					Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(item.BookImageData.ToByteArray())), 40, 40),
					item.BookName,
					item.UserFullName,
					item.UserLibraryName,
					item.Time,
					"Cancel",
					item.RentCode,
				};

				leasedBooksGridViewData.Add(row);
			}

			foreach (var item in leasedBooksGridViewData)
			{
				gridviewLeasedBooks.Rows.Add(item);
			}


			var rentedBooks = oReply.RentedBookList.ToList();
			List<object[]> rentedBooksGridViewData = new List<object[]>();
			foreach (var item in rentedBooks)
			{
				var row = new object[] {
					Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(item.BookImageData.ToByteArray())), 40, 40),
					item.BookName,
					item.BookLibraryName,
					item.Time,
					"Return",
					item.RentCode,
				};

				rentedBooksGridViewData.Add(row);
			}

			foreach (var item in rentedBooksGridViewData)
			{
				gridViewRentedBooks.Rows.Add(item);
			}

		}

		public void FillDataMethodAsync()
		{
			System.Threading.Thread.Sleep(700);

			LibraryManagmentConnectSDK.BookRentingSystemListReply oReply =
				libraryManagerConnection.BookRentingSystemList(new LibraryManagmentConnectSDK.BookRentingSystemListRequest { });
			if (oReply == null || !oReply.IsSuccessfull)
			{				
				return;
			}

			Invoke(new Action(() =>
			{
				gridviewRentingRequest.Rows.Clear();
				gridviewLeasedBooks.Rows.Clear();
				gridViewRentedBooks.Rows.Clear();
			}));

			var newRequests = oReply.NewRentRequestList.ToList();
			List<object[]> newRequestsGridVireData = new List<object[]>();
			foreach (var item in newRequests)
			{
				var row = new object[] {
					Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(item.BookImageData.ToByteArray())), 40, 40),
					item.BookName,
					item.UserFullName,
					item.UserLibraryName,
					item.Time,
					item.Context,
					"Accept",
					"Reject",
					item.RentRequestCode,
				};

				
				newRequestsGridVireData.Add(row);
			}

			foreach (var item in newRequestsGridVireData)
			{
				Invoke(new Action(() =>
				{
					gridviewRentingRequest.Rows.Add(item);
				}));
			}

			/////////////////////////

			var leasedBooks = oReply.BookRentedList.ToList();
			List<object[]> leasedBooksGridViewData = new List<object[]>();
			foreach (var item in leasedBooks)
			{
				var row = new object[] {
					Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(item.BookImageData.ToByteArray())), 40, 40),
					item.BookName,
					item.UserFullName,
					item.UserLibraryName,
					item.Time,
					"Cancel",
					item.RentCode,
				};

				leasedBooksGridViewData.Add(row);
			}

			foreach (var item in leasedBooksGridViewData)
			{
				Invoke(new Action(() =>
				{
					gridviewLeasedBooks.Rows.Add(item);
				}));
			}


			var rentedBooks = oReply.RentedBookList.ToList();
			List<object[]> rentedBooksGridViewData = new List<object[]>();
			foreach (var item in rentedBooks)
			{
				var row = new object[] {
					Infrastructure.ImageUtils.GetThumbnailByImageObject(Image.FromStream(new System.IO.MemoryStream(item.BookImageData.ToByteArray())), 40, 40),
					item.BookName,
					item.BookLibraryName,
					item.Time,
					"Return",
					item.RentCode,
				};

				rentedBooksGridViewData.Add(row);
			}

			foreach (var item in rentedBooksGridViewData)
			{
				Invoke(new Action(() =>
				{
					gridViewRentedBooks.Rows.Add(item);
				}));
			}

		}

		private void GridviewRentingRequest_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 6)
			{
				string strSelectedRequestId = gridviewRentingRequest.Rows[e.RowIndex].Cells[8].Value.ToString();
				var result = MessageBox.Show("Are You Sure You Wana Accept This Book Rent Request ?", "Accept The Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					LibraryManagmentConnectSDK.AcceptRentRequestReply oReply =
						libraryManagerConnection.AcceptRentRequest(new LibraryManagmentConnectSDK.AcceptRentRequestRequest { RentRequestId = strSelectedRequestId });
					if (oReply == null || !oReply.IsSuccessfull)
					{
						MessageBox.Show("An Error Occured in Accept Rent Request , Try Again ! \n With Error Message : "
							+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Accept Rent Request Error!", MessageBoxButtons.OK);
						return;
					}

					gridviewRentingRequest.Rows.RemoveAt(e.RowIndex);
				}			
			}
			else if (e.ColumnIndex == 7)
			{
				string strSelectedRequestId = gridviewRentingRequest.Rows[e.RowIndex].Cells[8].Value.ToString();
				var result = MessageBox.Show("Are You Sure You Wana Reject This Book Rent Request ?", "Reject The Request", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					GetRejectResponse oContextForm =
						   new GetRejectResponse();
					oContextForm.ParretForm = this;
					oContextForm.RequestId = strSelectedRequestId;
					oContextForm.RequestIndex = e.RowIndex;
					oContextForm.ShowDialog();
				}		
			}
		}

		public void GetRejectionContextResult(string strContext, string requestId, int requestIndex)
		{
			LibraryManagmentConnectSDK.RejectRentRequestReply oReply =
						libraryManagerConnection.RejectRentRequest(new LibraryManagmentConnectSDK.RejectRentRequestRequest { RentRequestId = requestId,ResponseContext = strContext });
			if (oReply == null || !oReply.IsSuccessfull)
			{
				MessageBox.Show("An Error Occured in Reject Rent Request , Try Again ! \n With Error Message : "
					+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Reject Rent Request Error!", MessageBoxButtons.OK);
				return;
			}

			gridviewRentingRequest.Rows.RemoveAt(requestIndex);
		}

		private void GridviewLeasedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 5)
			{
				string strSelectedRentId = gridviewLeasedBooks.Rows[e.RowIndex].Cells[6].Value.ToString();
				var result = MessageBox.Show("Are You Sure You Wana Cancel And Get back This Book ?", "Cancel The Rent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					LibraryManagmentConnectSDK.CancelRentBookReply oReply =
						libraryManagerConnection.CancelRentBook(new LibraryManagmentConnectSDK.CancelRentBookRequest { RentId = strSelectedRentId });
					if (oReply == null || !oReply.IsSuccessfull)
					{
						MessageBox.Show("An Error Occured in Cancel And Get back Rent, Try Again ! \n With Error Message : "
							+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Cancel And Get back Error!", MessageBoxButtons.OK);
						return;
					}

					gridviewLeasedBooks.Rows.RemoveAt(e.RowIndex);
				}
			}		
		}

		private void GridViewRentedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 4)
			{
				string strSelectedRentId = gridViewRentedBooks.Rows[e.RowIndex].Cells[5].Value.ToString();
				var result = MessageBox.Show("Are You Sure You Wana This Book Back To The Library ?", "Return Book", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					LibraryManagmentConnectSDK.ReturnRentedBookReply oReply =
						libraryManagerConnection.ReturnRentedBook(new LibraryManagmentConnectSDK.ReturnRentedBookRequest { RentId = strSelectedRentId });
					if (oReply == null || !oReply.IsSuccessfull)
					{
						MessageBox.Show("An Error Occured in Return Book, Try Again ! \n With Error Message : "
							+ (oReply == null ? "Couldnt Get Response From Server" : ((Domain.Enums.ResponseErrorType)oReply.ErrorType).ToString()), "Return Book Error!", MessageBoxButtons.OK);
						return;
					}

					gridViewRentedBooks.Rows.RemoveAt(e.RowIndex);
				}
			}
		}

		private void WSRentingSystem_Activated(object sender, EventArgs e)
		{
			System.Threading.Thread oFillThread = new System.Threading.Thread(FillDataMethodAsync);
			oFillThread.Start();
		}
	}
}
