using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VoteCounter
{
    /// <summary>
    /// Return the information for audting purpose : round number, 
    /// valid votes number, invalid votes number, reason to remove
    /// the number votes of each candidate in each round  
    /// Allow to print to csv file
    /// navigate back to the VoteCounterForm
    /// </summary>
    public partial class AuditingForm : Form
    {
        #region Properties
        VoteCounter voteCounter = null; // track VoteCounter object 

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="votecounter">VoteCounter object</param>    
        public AuditingForm(VoteCounter votecounter)
        {
            InitializeComponent();
            voteCounter = votecounter;
            AddRoundSummaryListView();
            AddVotesSummaryListView();

        }

        #endregion

        #region Summary Information for each round

        /// <summary>
        /// Show the information of each round on list view : round number, 
        /// Valida Votes Number, Invalid Vote Number
        /// Removed Candidates, Reason to remove      
        /// </summary> 
        private void AddRoundSummaryListView()
        {
            // set list view properties
            RoundSummaryLV.View = View.Details;
            RoundSummaryLV.FullRowSelect = true;
            // add columns
            RoundSummaryLV.Columns.Add("Round #", 80);
            RoundSummaryLV.Columns.Add("Valid Votes", 80);
            RoundSummaryLV.Columns.Add("Invalid Votes", 80);
            RoundSummaryLV.Columns.Add("Removed Candidates", 150);
            RoundSummaryLV.Columns.Add("Reason", 150);
            // add Items to RoundSummaryLV
            foreach (var entry in voteCounter.RoundSummary)
            {
                ListViewItem LVI = RoundSummaryLV.Items.Add((entry.Key).ToString());
                foreach (var v in entry.Value)
                {
                    LVI.SubItems.Add((v).ToString());
                }
            }
        }

        #endregion

        #region Number votes of each candidate in each round

        /// <summary>
        /// Show the number votes of each candidate in each round          
        /// </summary>
        private void AddVotesSummaryListView()
        {
            // set list view properties
            VotesSummaryLV.View = View.Details;
            VotesSummaryLV.FullRowSelect = true;
            // add columns
            VotesSummaryLV.Columns.Add("Candidate ", 120);
            for (int i = 1; i < voteCounter.VoteSummaryRow.Count; i++)
            {
                string RoundNo = "Votes #" + i;
                VotesSummaryLV.Columns.Add(RoundNo, 60);
            }
            // add Items
            foreach (var entry in voteCounter.VoteSummaryRow)
            {
                ListViewItem LVI = VotesSummaryLV.Items.Add((entry.Key).ToString());
                foreach (var v in entry.Value)
                {
                    LVI.SubItems.Add((v).ToString());
                }
            }
        }

        #endregion

        #region Print report

        /// <summary>
        /// EventHandle for CSV printer button
        /// Create new csv file to store all the information in the form
        /// </summary>
        /// <param name="sender">The object that called the method</param>
        /// <param name="e">Information about the calling event</param>
        private void CsvPrinterBtn_Click(object sender, EventArgs e)
        {
            //declare new SaveFileDialog + set it's initial properties
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Choose file to save to",
                FileName = "auditing summary.csv",
                Filter = "CSV (*.csv)|*.csv",
                FilterIndex = 0,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            //show the dialog + display the results in a msgbox unless cancelled

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string output = OutputData();
                System.IO.File.WriteAllText(sfd.FileName, output);
            }

        }

        /// <summary>
        /// EventHandle for PDF printer button
        /// Create new pdf file to store all the information in the form
        /// </summary>
        /// <param name="sender">The object that called the method</param>
        /// <param name="e">Information about the calling event</param>
        /// 
        private void PdfPrinterBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Choose file to save to",
                FileName = "auditing summary.pdf",
                Filter = "PDF (*.pdf)|*.pdf",
                FilterIndex = 0,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            //show the dialog + display the results in a msgbox unless cancelled
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable1 = new PdfPTable(RoundSummaryLV.Columns.Count);
                pdfTable1.DefaultCell.Padding = 3;
                pdfTable1.WidthPercentage = 80;
                pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable1.DefaultCell.BorderWidth = 1;

                //Adding Header row
                foreach (ColumnHeader column in RoundSummaryLV.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.Text));
                    pdfTable1.AddCell(cell);
                }

                //Adding DataRow
                foreach (ListViewItem itemRow in RoundSummaryLV.Items)
                {
                    for (int i = 0; i < itemRow.SubItems.Count; i++)
                    {
                        pdfTable1.AddCell(itemRow.SubItems[i].Text);
                    }
                }

                // Creating iTextSharp Table from the DataTable data
                PdfPTable pdfTable2 = new PdfPTable(VotesSummaryLV.Columns.Count);
                pdfTable2.DefaultCell.Padding = 3;
                pdfTable2.WidthPercentage = 95;
                pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable2.DefaultCell.BorderWidth = 1;

                //Adding Header row
                foreach (ColumnHeader column in VotesSummaryLV.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.Text));
                    pdfTable2.AddCell(cell);
                }

                //Adding DataRow
                foreach (ListViewItem itemRow in VotesSummaryLV.Items)
                {
                    int emptyCellsNo = 0;
                    for (int i = 0; i < itemRow.SubItems.Count; i++)
                    {                        
                        pdfTable2.AddCell(itemRow.SubItems[i].Text);

                    }
                    // Add empty cells if blank
                    if (itemRow.SubItems.Count < VotesSummaryLV.Columns.Count) {
                        emptyCellsNo = VotesSummaryLV.Columns.Count - itemRow.SubItems.Count;
                        for (int i = 0; i < emptyCellsNo; i++)
                        {
                            
                            pdfTable2.AddCell("");
                        }
                    }
                }

                //Exporting to PDF
                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(new Chunk("\n"));
                    pdfDoc.Add(new Paragraph("Audit Summary Report "));
                    pdfDoc.Add(new Chunk("\n"));
                    pdfDoc.Add(new Paragraph("# Round Summary"));
                    pdfDoc.Add(new Chunk("\n"));
                    pdfDoc.Add(pdfTable1);
                    pdfDoc.Add(new Chunk("\n"));
                    pdfDoc.Add(new Paragraph("Votes Summary Per Each Round # "));
                    pdfDoc.Add(new Chunk("\n"));
                    pdfDoc.Add(pdfTable2);
                    pdfDoc.Close();
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// Take data from listviews of AuditingForm 
        /// to create output data for report       
        /// </summary>
        private string OutputData()
        {
            string output = "";

            // add RoundSummaryLV content
            string[] headers1 = RoundSummaryLV.Columns.OfType<ColumnHeader>()
                       .Select(header1 => header1.Text.Trim()).ToArray();

            string[][] items1 = RoundSummaryLV.Items.OfType<ListViewItem>()
                        .Select(lvi => lvi.SubItems.OfType<ListViewItem.ListViewSubItem>()
                            .Select(si1 => si1.Text).ToArray()).ToArray();

            string table1 = string.Join(",", headers1) + Environment.NewLine;
            foreach (string[] a1 in items1)
            {
                table1 += string.Join(",", a1) + Environment.NewLine;
            }

            // add  VotesSummaryLV content
            string[] headers2 = VotesSummaryLV.Columns.OfType<ColumnHeader>()
                     .Select(header2 => header2.Text.Trim()).ToArray();

            string[][] items2 = VotesSummaryLV.Items.OfType<ListViewItem>()
                        .Select(lvi2 => lvi2.SubItems.OfType<ListViewItem.ListViewSubItem>()
                            .Select(si2 => si2.Text).ToArray()).ToArray();

            string table2 = string.Join(",", headers2) + Environment.NewLine;
            foreach (string[] a2 in items2)
            {
                table2 += string.Join(",", a2) + Environment.NewLine;
            }
            table2 = table2.TrimEnd('\r', '\n');

            // combine 2 listview + write to file
            output += "\n Audit Summary Report \n\n";
            output += "# Round Summary \n" + table1 + "\n\n";
            output += "Votes Summary Per Each Round # \n\n" + table2;
            return output;
        }

        #endregion

        #region Navigate back to VoteCounterForm
        /// <summary>
        /// Come back to the vote counter form    
        /// </summary>
        /// <param name="sender">The object that called the method</param>
        /// <param name="e">Information about the calling event</param>
        private void SwitchToVoteFormBtn_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Dispose();      // close the form     
        }



        #endregion

        

        private void Printer_Click(object sender, EventArgs e)
        {
            // Allow the user to choose the page range he or she would
            // like to print.

            PrintDialog pdl = new PrintDialog();
            System.Drawing.Printing.PrintDocument docToPrint =
         new System.Drawing.Printing.PrintDocument();
            pdl.AllowSomePages = true;

            // Show the help button.
            pdl.ShowHelp = true;

            // Set the Document property to the PrintDocument for 
            // which the PrintPage Event has been handled. To display the
            // dialog, either this property or the PrinterSettings property 
            // must be set 
            pdl.Document = docToPrint;

            DialogResult result = pdl.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }

        // The PrintDialog will print the document
        // by handling the document's PrintPage event.
        private void document_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {

            // Insert code to render the page here.
            // This code will be called when the control is drawn.

            // The following code will render a simple
            // message on the printed document.
            string text = OutputData();
            System.Drawing.Font printFont = new System.Drawing.Font
                ("Arial", 35, System.Drawing.FontStyle.Regular);

            // Draw the content.
            e.Graphics.DrawString(text, printFont,
                System.Drawing.Brushes.Black, 10, 10);
        }
    }
}
