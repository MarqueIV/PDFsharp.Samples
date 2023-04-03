// PDFsharp - A .NET library for processing PDF
// See the LICENSE file in the solution root for more information.

using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Snippets.Font;

// This sample is the obligatory Hello World program.

// NET6FIX
if (Capabilities.Build.IsCoreBuild)
    GlobalFontSettings.FontResolver = new FailsafeFontResolver();

// Create a new PDF document.
var document = new PdfDocument();
document.Info.Title = "Created with PDFsharp";

// Create an empty page.
var page = document.AddPage();

// Get an XGraphics object for drawing.
var gfx = XGraphics.FromPdfPage(page);

// Create a font.
var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);

// Draw the text.
gfx.DrawString("Hello, World!", font, XBrushes.Black,
          new XRect(0, 0, page.Width, page.Height),
          XStringFormats.Center);

// Save the document...
const string filename = "HelloWorld_tempfile.pdf";
document.Save(filename);
// ...and start a viewer.
Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
