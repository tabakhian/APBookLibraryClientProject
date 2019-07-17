using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APBookLibraryProject
{
	public partial class WSReadBook : BaseAuthenticatedDataForm
	{
		public class Item
		{
			public Item() { }

			public string Value { set; get; }
			public string Text { set; get; }
		}

		public float FontSize { get; set; }
		public string FontFamily { get; set; }
		public FontStyle FontStyle { get; set; }
		public string BookAllText { get; set; }
		public int CurrentPageNumber { get; set; }
		public System.Collections.Generic.List<string> BookPages { get; set; }


		public WSReadBook()
		{
			BookPages = new List<string>();
			CurrentPageNumber = 1;
			BookAllText = string.Empty;
			InitializeComponent();
		}
		public void setBook(string bookText)
		{
			BookAllText = bookText;
		}

		private void WSReadBook_Load(object sender, EventArgs e)
		{
			List<Item> FontSizeItems = new List<Item>();
			FontSizeItems.Add(new Item() { Text = "Big Font", Value = "16" });
			FontSizeItems.Add(new Item() { Text = "Medium Font", Value = "14" });
			FontSizeItems.Add(new Item() { Text = "Small Font", Value = "12" });
			FontSizeItems.Add(new Item() { Text = "Micro Font", Value = "10" });

			comboFontSize.DataSource = FontSizeItems;
			comboFontSize.DisplayMember = "Text";
			comboFontSize.ValueMember = "Value";
			comboFontSize.SelectedIndex = 1;
			FontSize = float.Parse(comboFontSize.SelectedValue.ToString());
			////////////////////////

			List<Item> FontFamilyItems = new List<Item>();
			FontFamilyItems.Add(new Item() { Text = "Microsoft Sans Serif", Value = "Microsoft Sans Serif" });
			FontFamilyItems.Add(new Item() { Text = "B Yekan", Value = "B Yekan" });
			FontFamilyItems.Add(new Item() { Text = "B Zar", Value = "B Zar" });
			FontFamilyItems.Add(new Item() { Text = "Arial", Value = "Arial" });
			FontFamilyItems.Add(new Item() { Text = "Segoe UI", Value = "Segoe UI" });


			comboFontFamily.DataSource = FontFamilyItems;
			comboFontFamily.DisplayMember = "Text";
			comboFontFamily.ValueMember = "Value";
			comboFontFamily.SelectedIndex = 1;
			FontFamily = comboFontFamily.SelectedValue.ToString();
			////////////////////////

			List<Item> FontStyleItems = new List<Item>();
			FontStyleItems.Add(new Item() { Text = "Regular", Value = "0" });
			FontStyleItems.Add(new Item() { Text = "Bold", Value = "1" });
			FontStyleItems.Add(new Item() { Text = "Italic", Value = "2" });
			FontStyleItems.Add(new Item() { Text = "UnderLine", Value = "4" });
			FontStyleItems.Add(new Item() { Text = "Strikeout", Value = "8" });


			ComboFontStyle.DataSource = FontStyleItems;
			ComboFontStyle.DisplayMember = "Text";
			ComboFontStyle.ValueMember = "Value";
			ComboFontStyle.SelectedIndex = 0;
			FontStyle = (FontStyle)int.Parse(ComboFontStyle.SelectedValue.ToString());

			txtBookText.Font = new System.Drawing.Font(FontFamily, FontSize, FontStyle);

			AnalyseText(BookAllText, (int)FontSize);
			CurrentPageNumber = 1;
			txtBookText.Text = BookPages[CurrentPageNumber - 1].ToString();
			txtPageCount.Text = BookPages.Count().ToString();
			txtGotoPage.Text = "1";
		}

		private void ComboFontFamily_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((comboFontFamily.SelectedValue as String) == null)
			{
				return;
			}
			FontFamily = comboFontFamily.SelectedValue.ToString();
			txtBookText.Font = new System.Drawing.Font(FontFamily, FontSize, FontStyle);
		}

		private void ComboFontSize_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((comboFontSize.SelectedValue as String) == null)
			{
				return;
			}

			int intLengthSearch = (int)(txtBookText.Text.Count() / 10);
			int intStartSearch = (int)(txtBookText.Text.Count() / 2) - (int)(intLengthSearch / 2);

			string strForSearchText =
				txtBookText.Text.Substring(intStartSearch, intLengthSearch);

			//////////////////////////

			FontSize = float.Parse(comboFontSize.SelectedValue.ToString());
			txtBookText.Font = new System.Drawing.Font(FontFamily, FontSize, FontStyle);
			AnalyseText(BookAllText, (int)FontSize);
			txtPageCount.Text = BookPages.Count().ToString();
			/////////////////////////

			int intPageNumberSearchInNewPages =
				BookPages.FindIndex(Current => Current.Contains(strForSearchText));

			CurrentPageNumber = intPageNumberSearchInNewPages + 1;
			txtGotoPage.Text = CurrentPageNumber.ToString();
			txtBookText.Text = BookPages[CurrentPageNumber - 1].ToString();
		}

		private void ComboFontStyle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((ComboFontStyle.SelectedValue as String) == null)
			{
				return;
			}
			FontStyle = (FontStyle)int.Parse(ComboFontStyle.SelectedValue.ToString());
			txtBookText.Font = new System.Drawing.Font(FontFamily, FontSize, FontStyle);
		}

		private void AnalyseText(string strAllText, int fontSize)
		{
			int intApproximatePageCharCount = 1000;
			if (fontSize == 10)
			{
				intApproximatePageCharCount = 1400;
			}
			else if (fontSize == 12)
			{
				intApproximatePageCharCount = 1200;
			}
			else if (fontSize == 14)
			{
				intApproximatePageCharCount = 1000;
			}
			else if (fontSize == 16)
			{
				intApproximatePageCharCount = 800;
			}

			BookPages.Clear();

			int Start = 0, Finish;
			Finish = Start + intApproximatePageCharCount;
			bool IsLastPage = false;
			while (!IsLastPage)
			{
				if (Finish > strAllText.Length)
				{
					if (strAllText.Length == 0)
					{
						Finish = 0;
						BookPages.Add(String.Empty);
						break;
					}
					else
					{
						Finish = strAllText.Length - 1;
					}
					IsLastPage = true;
				}

				while (strAllText[Finish] != '\n' && strAllText[Finish] != ' ')
				{
					Finish = Finish - 1;
				}

				BookPages.Add(strAllText.Substring(Start, Finish - Start));

				Start = Finish + 1;
				Finish = Start + intApproximatePageCharCount;
			}

		}

		private void TxtGotoPage_TextChanged(object sender, EventArgs e)
		{
			int PageNumber = 1;
			if (!int.TryParse(txtGotoPage.Text, out PageNumber))
			{
				MessageBox.Show("Please Enter The Page Number in Number Format!", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CurrentPageNumber = 1;
				txtGotoPage.Text = "1";
				txtBookText.Text = BookPages[CurrentPageNumber - 1].ToString();
				return;
			}

			if (!(1 <= PageNumber) || !(PageNumber <= BookPages.Count))
			{
				MessageBox.Show("Please Enter The Page Number Between 0 and " + BookPages.Count.ToString(), "Page Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				CurrentPageNumber = 1;
				txtGotoPage.Text = "1";
				txtBookText.Text = BookPages[CurrentPageNumber - 1].ToString();
				return;
			}

			CurrentPageNumber = PageNumber;
			txtBookText.Text = BookPages[CurrentPageNumber - 1].ToString();
		}

		private void BtnNextPage_Click(object sender, EventArgs e)
		{
			if (CurrentPageNumber < BookPages.Count())
			{
				CurrentPageNumber++;
				txtBookText.Text = BookPages[CurrentPageNumber - 1].ToString();
				txtGotoPage.Text = CurrentPageNumber.ToString();
			}
		}

		private void BtnLastPage_Click(object sender, EventArgs e)
		{
			if (CurrentPageNumber > 1)
			{
				CurrentPageNumber--;
				txtBookText.Text = BookPages[CurrentPageNumber - 1].ToString();
				txtGotoPage.Text = CurrentPageNumber.ToString();
			}
		}

		private void BtnExportPDF_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Due To The CopyRight Laws You Cant Print o Export The Book You Rent!", "Error In Exporting!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;

			try
			{
				//string strPath = String.Empty;

				//saveFileDialog1.Title = "select PDF Path";
				//saveFileDialog1.Filter = "PDF Files (*.pdf;* .XPDF;*) | * .PDF ;*.XPDF ";
				//saveFileDialog1.DefaultExt = ".pdf";
				//DialogResult result = saveFileDialog1.ShowDialog();
				//if (result == DialogResult.OK)
				//{
				//	strPath = saveFileDialog1.FileName;
				//}
				//else
				//{
				//	MessageBox.Show("An Error occrued in Selecting PDF Path ! try agin !", "Error In Selecting Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//	return;
				//}

				//using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
				//{
				//	Document document = new Document(PageSize.A4, 10, 10, 10, 10);

				//	PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
				//	document.Open();

				//	Paragraph paragraph = new Paragraph();
				//	paragraph.SpacingBefore = 10;
				//	paragraph.SpacingAfter = 10;
				//	paragraph.Alignment = Element.ALIGN_RIGHT;
				//	paragraph.Font = FontFactory.GetFont(FontFamily, FontSize);
				//	paragraph.Add(BookAllText);
				//	document.Add(paragraph);

				//	document.Close();

				//	byte[] bytes = memoryStream.ToArray();
				//	memoryStream.Close();

				//	var file = new FileStream(strPath, FileMode.Create);
				//	file.Write(bytes, 0, bytes.Count());
				//	file.Dispose();
				//	memoryStream.Dispose();
				//}


				//int yPoint = 0;
				//PdfDocument pdf = new PdfDocument();
				//pdf.Info.Title = Book.Name;

				//foreach (var item in BookPages)
				//{
				//	PdfPage pdfPage = pdf.AddPage();
				//	XGraphics graph = XGraphics.FromPdfPage(pdfPage);
				//	XFont font = new XFont(FontFamily, FontSize, (XFontStyle)FontStyle);

				//	graph.DrawString(item, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
				//	yPoint = yPoint + 40;
				//	//line = readFile.ReadLine();
				//	//if (line == null)
				//	//{
				//	//	break; // TODO: might not be correct. Was : Exit While
				//	//}
				//	//else
				//	//{
				//	//	graph.DrawString(line, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
				//	//	//yPoint = yPoint + 40;
				//	//}
				//}

				//pdf.Save(strPath);
				//Process.Start(strPath);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void BtnExportToWord_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Due To The CopyRight Laws You Cant Print o Export The Book You Rent!", "Error In Exporting!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;

			try
			{
				string strPath = String.Empty;

				saveFileDialog1.Title = "Select Word Path";
				saveFileDialog1.Filter = "PDF Files (*.docx;*) | * .DOCX ";
				saveFileDialog1.DefaultExt = ".docx";
				DialogResult result = saveFileDialog1.ShowDialog();
				if (result == DialogResult.OK)
				{
					strPath = saveFileDialog1.FileName;
				}
				else
				{
					MessageBox.Show("An Error occrued in Selecting Word Path ! try agin !", "Error In Selecting Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
				winword.ShowAnimation = false;
				winword.Visible = false;
				object missing = System.Reflection.Missing.Value;

				Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
				document.Paragraphs.Format.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
				document.Paragraphs.Format.ReadingOrder = WdReadingOrder.wdReadingOrderRtl;

				Microsoft.Office.Interop.Word.Paragraph paraMadkhalCount = document.Content.Paragraphs.Add(ref missing);
				object styleHeading1Out = "Normal";
				paraMadkhalCount.Range.set_Style(ref styleHeading1Out);
				paraMadkhalCount.Range.Font.Name = FontFamily;
				paraMadkhalCount.Range.Font.SizeBi = FontSize;
				paraMadkhalCount.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
				paraMadkhalCount.Range.ParagraphFormat.ReadingOrder = WdReadingOrder.wdReadingOrderRtl;
				paraMadkhalCount.Range.Text = BookAllText;
				paraMadkhalCount.Range.InsertParagraphAfter();

				//Save the document  
				object filename = strPath;
				document.SaveAs2(ref filename);
				document.Close(ref missing, ref missing, ref missing);
				document = null;
				winword.Quit(ref missing, ref missing, ref missing);
				winword = null;
				MessageBox.Show("Word Document Created Successfully !!!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	
	}
}
