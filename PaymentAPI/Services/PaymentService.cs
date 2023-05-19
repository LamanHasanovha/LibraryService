using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using PaymentAPI.Models;
using System.Text;

namespace PaymentAPI.Services
{
    public class PaymentService
    {
        public void DoPayment(PaymentModel model)
        {

        }

        public void GenerateHtml(PaymentModel model)
        {
            string html = @"<!DOCTYPE html>
<html>
<body>

<h1 style=""text-align: center;"">Invoice</h1>
<hr>
<br>
<form action=""/action_page.php"">
  <h3>Account information</h3>
  <label for=""firstname"">First name :</label><br>
  <input type=""text"" id=""fname"" name=""firstname"" ><br>
  <label for=""lastname"">Last name :</label><br>
  <input type=""text"" id=""lname"" name=""lastname"" ><br>
  <label for=""username"">Username :</label><br>
  <input type=""text"" id=""username"" name=""username"" ><br>
  <label for=""email"">Email :</label><br>
  <input type=""text"" id=""email"" name=""email""><br>

  <h3>Order information</h3>
  <ul>
    <li>
      <label for=""name"">Product Name :</label><br>
      <input type=""text"" id=""name"" name=""name"" ><br>
      <label for=""price"">Price :</label><br>
      <input type=""text"" id=""price"" name=""price"" ><br>
      <label for=""type"">Product type :</label><br>
      <input type=""text"" id=""type"" name=""type"" ><br>
      <br>
    </li>
    <li>
      <label for=""name"">Product Name :</label><br>
      <input type=""text"" id=""name"" name=""name"" ><br>
      <label for=""price"">Price :</label><br>
      <input type=""text"" id=""price"" name=""price"" ><br>
      <label for=""type"">Product type :</label><br>
      <input type=""text"" id=""type"" name=""type"" ><br>
      <br>
    </li>
  </ul>
  <hr>
  <h3>Total price :</h3>
  <input type=""text"" id=""totalPrice"" name=""totalPrice"" ><br>
  
  <br><br><br><br>

  <h4 style=""text-align: center;""></h4>
</form> 
</body>
</html>";
            string htmlTest = @"<html><body><h1 style=""text-align: center;"">Invoice</h1><h3>Account information</h3>
                                  <label>First name : </label> {FirstName} <br></br><br></br>
                                  <label>Last name : </label> {LastName} <br></br><br></br>
                                  <label>Username : </label> {Username} <br></br><br></br>
                                  <label>Email : </label> {Email} <br></br><br></br>
                                  <h3>Order information<h3>
                                  <ul>
                                    <li>
                                        
                                    <li>
                                    <li>
                                        
                                    <li>
                                  <ul>
                                </body></html>";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ConvertHtmlToPdf(htmlTest, @"C:\Docs\output.pdf");

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

    }
}
