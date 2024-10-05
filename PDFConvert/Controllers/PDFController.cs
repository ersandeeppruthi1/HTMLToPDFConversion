using SelectPdf;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PDFConvert.Controllers
{
    [RoutePrefix("api/pdf")]
    public class PDFController : ApiController
    {
        // POST api/pdf/generatepdf
        [HttpPost]
        [Route("generatepdf")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GeneratePdf([FromBody] HtmlInputModel input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input.Html))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "HTML content cannot be empty.");
                }

                // Define PDF generation options (using SelectPdf as an example)
                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument pdfDocument = converter.ConvertHtmlString(input.Html);

                // Save PDF to memory stream
                var memoryStream = new MemoryStream();
                pdfDocument.Save(memoryStream);
                pdfDocument.Close();
                memoryStream.Position = 0;

                // Create the response with the PDF content
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(memoryStream.ToArray())
                };
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "GeneratedPDF.pdf"
                };

                return response;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error generating PDF: {ex.Message}");
            }
        }
    }

    public class HtmlInputModel
    {
        public string Html { get; set; }
    }
}