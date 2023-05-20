using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using System.Globalization;
using System.Text;

namespace PaymentAPI.Services
{
    public class PaymentService
    {
        public FileStream DoPayment(PaymentModel model)
        {
            var path = GenerateHtml(model);
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return fileStream;
        }

        public string GenerateHtml(PaymentModel model)
        {
            string html = @"<html>
                                <body style=""font-family: 'Times New Roman', Times, serif;"">
                                    <h1 style=""text-align: center;"">Invoice : {InvoiceId}</h1>
                                    <hr></hr>
                                    <br></br>
                                    <h2>Account information</h2>
                                    <pre><label style=""margin-left: 30px;"">First name :</label>  {FirstName}<br></br></pre>
                                    <pre><label style=""margin-left: 30px;"">Last name  :</label>  {LastName} <br></br></pre>
                                    <pre><label style=""margin-left: 30px;"">Username   :</label>  {Username}<br></br></pre>
                                    <pre><label style=""margin-left: 30px;"">Email      :</label>  {Email}<br></br></pre>
                                    <h2>Order information</h2>
                                    <ul>
                                    </ul>
                                    <hr></hr>
                                    <pre><h3>Total price :  {TotalPrice}</h3></pre>
                                    <pre><h3>Date        :  {Date}</h3></pre>
                                    <br></br><br></br><br></br><br></br>
                                    <h4 style=""text-align: center;"">LemAy Tech</h4>
                                </body>
                            </html>";
            string orderHtml = @"<li>
                                    <pre><label> Product Name :</label>  {ProductName}<br></br></pre>
                                    <pre><label> Price        :</label>  {Price}<br></br></pre>
                                    <pre><label> Product type :</label>  {ProductType}<br></br></pre>
                                </li>";

            var result = html.Replace("{FirstName}", model.AccountInfo.FirstName).Replace("{LastName}", model.AccountInfo.LastName)
                             .Replace("{Username}", model.AccountInfo.UserName).Replace("{Email}", model.AccountInfo.Email)
                             .Replace("{InvoiceId}", GetInvoiceId()).Replace("{Date}", DateTime.Now.ToString("dd.MM.yyyy"))
                             .Replace("{TotalPrice}", model.Orders.Select(o => o.Price).Sum().ToString());

            foreach (var item in model.Orders)
            {
                result = result.Insert(result.IndexOf("<ul>") + 4,
                       orderHtml.Replace("{ProductName}", item.Name)
                                .Replace("{Price}", string.Format(CultureInfo.CreateSpecificCulture("az-AZ"), "{0:C}", item.Price))
                                .Replace("{ProductType}", item.ProductType == 1 ? "Book" : "Movie"));
            }

            var path = Environment.CurrentDirectory + @"\Documents\output.pdf";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ConvertHtmlToPdf(result, path);

            return path;
        }

        public void ConvertHtmlToPdf(string htmlCode, string outputPath)
        {
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                document.Open();

                using (StringReader reader = new StringReader(htmlCode))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, reader);
                }

                document.Close();
            }
        }

        private string GetInvoiceId()
        {
            var number = new Random().Next(100000000, 1000000000);
            return number.ToString();
        }
    }
}
