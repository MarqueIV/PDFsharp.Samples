﻿// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

// Disabled warnings, because this is documentation code.
#pragma warning disable CS8602 // Dereference of a possibly null reference
#pragma warning disable IDE0059
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedVariable

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace MigraDocDocs.DOM.Formats.Font
{
    /// <summary>
    /// Underline chapter.
    /// </summary>
    static class UnderlineTypes
    {
        [AutoCreatePath]
        const string Path = $"{Helper.DocsRoot}/Document object model/Formats/Font";

        const string Filename = $"{Path}/UnderlineTypes.pdf";
        const string SampleName = "Underline types";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];
            style.ParagraphFormat.SpaceAfter = Unit.FromPoint(12);

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Set the font.Underline to Single.
            var paragraph = section.AddParagraph("This is a sample paragraph with Underline.Single, so it is underlined by one single line.");
            paragraph.Format.Font.Underline = Underline.Single;

            // Set the font.Underline to Words.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.Words, so every word is underlined separately.");
            paragraph.Format.Font.Underline = Underline.Words;

            // Set the font.Underline to Dotted.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.Dotted, so it is underlined by one dotted line.");
            paragraph.Format.Font.Underline = Underline.Dotted;

            // Set the font.Underline to Dash.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.Dash, so it is underlined by one dashed line.");
            paragraph.Format.Font.Underline = Underline.Dash;

            // Set the font.Underline to DotDash.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.DotDash, so it is underlined by alternated dots and dashes.");
            paragraph.Format.Font.Underline = Underline.DotDash;

            // Set the font.Underline to DotDotDash.
            paragraph = section.AddParagraph("This is a sample paragraph with Underline.DotDotDash, so it is underlined by the pattern dot - dot - dash.");
            paragraph.Format.Font.Underline = Underline.DotDotDash;

            // --- Rendering

            // Create a renderer for the MigraDoc document.
            var pdfRenderer = new PdfDocumentRenderer
            {
                // Associate the MigraDoc document with a renderer.
                Document = document,
                // Let the PDF viewer show this PDF with full pages.
                PdfDocument =
                {
                    PageLayout = PdfPageLayout.SinglePage,
                    ViewerPreferences =
                    {
                        FitWindow = true
                    }
                }
            };

            // Layout and render document to PDF.
            pdfRenderer.RenderDocument();

            // Add sample-specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}
