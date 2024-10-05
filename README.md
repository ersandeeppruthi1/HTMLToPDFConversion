# PDF Generation API using ASP.NET MVC Web API

## Description

This project is an ASP.NET MVC Web API that allows users to generate PDF files from HTML content. The API uses **SelectPdf**, a popular library for converting HTML to PDF, and provides a RESTful endpoint to handle PDF generation requests. It includes features like **Swagger** for API documentation and **CORS** support to allow cross-origin requests, making it accessible from a web frontend or other services.

## Features

- **Generate PDF from HTML**: Accepts HTML content as input and converts it into a downloadable PDF file.
- **REST API Endpoint**: The endpoint `/api/pdf/generatepdf` allows the client to post HTML data and receive a PDF in return.
- **Swagger Integration**: Interactive API documentation is available, making it easier to test and understand API endpoints.
- **CORS Enabled**: Supports cross-origin requests, allowing frontends hosted on different domains to interact with the API seamlessly.
- **Error Handling**: Proper error responses for invalid inputs or internal server errors.

## Technologies Used

- **ASP.NET MVC Web API**: Provides the foundation for the API server.
- **SelectPdf**: Converts HTML content into a PDF document.
- **Swagger (Swashbuckle)**: Generates interactive documentation for the API.
- **CORS (Microsoft.AspNet.WebApi.Cors)**: Ensures the API can be accessed from different domains securely.

## Getting Started

### Prerequisites

- **Visual Studio** (or any preferred IDE)
- **.NET Framework 4.x**
- **NuGet Packages**:
  - Microsoft.AspNet.WebApi.Cors
  - Swashbuckle
  - SelectPdf

### Installation

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/yourusername/PDF-Generation-API.git
   cd PDF-Generation-API
