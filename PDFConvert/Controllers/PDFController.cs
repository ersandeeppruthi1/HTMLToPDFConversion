using PDFConvert.Models;
using SelectPdf;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PDFConvert.Controllers
{
    /// <summary>
    /// Controller to handle PDF generation requests from HTML content.
    /// </summary>
    [RoutePrefix("api/pdf")]
    public class PDFController : ApiController
    {
        /// <summary>
        /// Generates a PDF from the provided HTML content.
        /// </summary>
        /// <param name="input">The input model containing HTML content and an optional filename.</param>
        /// <returns>A <see cref="HttpResponseMessage"/> containing the generated PDF file.</returns>
        /// <remarks>
        /// If the filename is not provided in the input, the PDF will be named "GeneratedPDF.pdf" by default.
        /// </remarks>
        [HttpPost]
        [Route("generatepdf")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GeneratePdf([FromBody] HtmlInputModel input)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(input.Html))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "HTML content cannot be empty.");
                }

                // Convert HTML to PDF using SelectPdf
                HtmlToPdf converter = new HtmlToPdf();
                PdfDocument pdfDocument = converter.ConvertHtmlString(input.Html);

                // Save the generated PDF to a memory stream
                var memoryStream = new MemoryStream();
                pdfDocument.Save(memoryStream);
                pdfDocument.Close();
                memoryStream.Position = 0;

                // Determine the filename to use for the PDF
                string fileName = string.IsNullOrWhiteSpace(input.FileName) ? "GeneratedPDF.pdf" : input.FileName;

                // Ensure the filename ends with ".pdf"
                if (!fileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    fileName += ".pdf";
                }

                // Create the HTTP response containing the PDF as an attachment
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(memoryStream.ToArray())
                };
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = fileName
                };

                return response;
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions and return an internal server error response
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, $"Error generating PDF: {ex.Message}");
            }
        }
    }
}