using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;

namespace PDFMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter path and New PDF name: ");
            string sNewName = Console.ReadLine();

            Console.Write("Enter pdf's file path : ");
            string sFilePath = Console.ReadLine();

            CreateMergedPDF(sNewName, sFilePath);
            
            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }

        static void CreateMergedPDF(string targetPDF, string sourceDir)
        {
            using (FileStream stream = new FileStream(targetPDF, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4);
                PdfCopy pdf = new PdfCopy(pdfDoc, stream);
                pdfDoc.Open();
                var files = Directory.GetFiles(sourceDir);
                Console.WriteLine("Merging files count: " + files.Length);
                int i = 1;
                foreach (string file in files)
                {
                    Console.WriteLine(i + ". Adding: " + file);
                    pdf.AddDocument(new PdfReader(file));
                    i++;
                }

                if (pdfDoc != null)
                    pdfDoc.Close();

                Console.WriteLine("PDF merge complete.");
            }
        }
    }
}
