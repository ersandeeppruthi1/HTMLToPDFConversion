namespace PDFConvert.Models
{
    /// <summary>
    /// Represents the input model for generating a PDF from HTML.
    /// </summary>
    public class HtmlInputModel
    {
        /// <summary>
        /// Gets or sets the HTML content to be converted to a PDF.
        /// </summary>
        /// <value>The HTML content as a string. This property is required for PDF generation.</value>
        public string Html { get; set; }

        /// <summary>
        /// Gets or sets the optional filename for the generated PDF.
        /// </summary>
        /// <value>The name of the generated PDF file. If not provided, a default name will be used.</value>
        public string FileName { get; set; } // Optional filename property
    }
}