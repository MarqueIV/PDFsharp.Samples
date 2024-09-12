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

namespace MigraDocDocs.DOM.Formats.BordersAndLineFormat
{
    /// <summary>
    /// Nesting chapter.
    /// </summary>
    static class Nesting
    {
        [AutoCreatePath]
        const string Path = "PDFs/Document object model/Formats/BordersAndLineFormat";
        
        const string Filename = $"{Path}/Nesting.pdf";
        const string SampleName = "Nesting";

        public static string Sample()
        {
            // --- Code needed for sample

            // Create a new MigraDoc document.
            var document = new Document();

            // Set Normal style.
            var style = document.Styles[StyleNames.Normal];

            // Add a section to the document.
            var section = document.AddSection();

            // --- Sample content

            // Add table.
            var table = section.AddTable();
            table.Borders.Visible = true;

            // Set 1 cm left and right padding for all cells for better visualization of cell and paragraph borders.
            table.LeftPadding = table.RightPadding = Unit.FromCentimeter(0.5);

            // Add first column.
            var columnA = table.AddColumn(Unit.FromCentimeter(3));

            // Add second column.
            var columnB = table.AddColumn(Unit.FromCentimeter(3));

            // Add  row.
            var row = table.AddRow();

            // -- cellA1

            var cellA1 = row[0];

            // Set cell borders for cellA1.
            cellA1.Borders.Width = Unit.FromPoint(5);

            // Set paragraph borders for cellA1.
            cellA1.Format.Borders.Width = Unit.FromPoint(1);

            // Add paragraph to cellA1.
            cellA1.AddParagraph("Text A1");

            // -- cellA1

            var cellB1 = row[1];

            // Set cell borders for cellB1.
            cellB1.Borders.Width = Unit.FromPoint(5);
            cellB1.Borders.Style = BorderStyle.Dot;

            // Set paragraph borders for cellB1.
            cellB1.Format.Borders.Width = Unit.FromPoint(1);

            // Add paragraph to cellB1.
            cellB1.AddParagraph("Text B1");

            // Add another paragraph to cellB1.
            cellB1.AddParagraph("Another paragraph");


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

            // Add sample specific heading with sample project helper function.
            Helper.AddSampleNameHeading(pdfRenderer, Path, SampleName);

            // Save the document.
            pdfRenderer.Save(Filename);

            return Filename;
        }
    }
}