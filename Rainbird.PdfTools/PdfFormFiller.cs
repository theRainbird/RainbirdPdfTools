
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Rainbird.PdfTools
{
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IPdfFormFiller))]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Guid("F52CF46C-B59A-44DE-9076-01800D448528")]
    public class PdfFormFiller : IPdfFormFiller
    {
        private PdfStamper _pdfDocument;
        private FileStream _filledOutStream;
        private string _sourcePdfPath;
        private string _filledOutPdfPath;

        public PdfFormFiller()
        {

        }

        public void LoadPdfDocument(string sourcePdfPath, string filledOutPdfPath)
        {            
            ClosePdfDocument();

            _sourcePdfPath = sourcePdfPath;
            _filledOutPdfPath = filledOutPdfPath;

            _filledOutStream = File.Open(_filledOutPdfPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            
            _pdfDocument =
                new PdfStamper(new PdfReader(_sourcePdfPath), _filledOutStream);                     
        }

        public string GetFieldValue(string fieldName)
        {
            return _pdfDocument.AcroFields.GetField(fieldName);
        }

        public void SetFieldValue(string fieldName, string value)
        {
            _pdfDocument.AcroFields.SetField(fieldName, value);
        }

        public string SourceFilePath
        {
            get => _sourcePdfPath;
        }

        public string DestinationFilePath
        {
            get => _filledOutPdfPath;
        }

        public void ClosePdfDocument()
        {
            if (_pdfDocument == null)
                return;                      

            _sourcePdfPath = null;
            _filledOutPdfPath = null;
            
            _pdfDocument.Close();
            _pdfDocument = null;

            if (_filledOutStream != null)
            {
                _filledOutStream.Close();
                _filledOutStream = null;
            }
        }

        public string[] GetFormFieldNames()
        {

            return _pdfDocument.AcroFields.Fields.Keys.ToArray();
        }
    }
}
