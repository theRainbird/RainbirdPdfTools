using System.Runtime.InteropServices;

namespace Rainbird.PdfTools
{
    [ComVisible(true)]
    [Guid("7F871551-A12A-497B-B822-9EEAFE1A4615")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IPdfFormFiller
    {
        [DispId(1)]
        string DestinationFilePath { get; }

        [DispId(2)]
        string SourceFilePath { get; }

        [DispId(3)]
        void ClosePdfDocument();

        [DispId(4)]
        string GetFieldValue(string fieldName);

        [DispId(5)]
        void LoadPdfDocument(string sourcePdfPath, string filledOutPdfPath);

        [DispId(6)]
        void SetFieldValue(string fieldName, string value);

        [DispId(7)]
        string[] GetFormFieldNames();
    }
}