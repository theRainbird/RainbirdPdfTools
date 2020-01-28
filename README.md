# Rainbird.PdfTools
Library to fill PDF form fields from VBA (e.g. Excel, Word) without Acrobat.

Consists of the library code (Rainbird.PdfTools) project and a setup project for easy deployment on client machines via MSI.
The setup project is built with WiX ToolSet (https://wixtoolset.org/). You need to install Wix Toolset 3.11.x in order to build the setup project.

Dependencies: itextsharp

Usage example for Excel VBA:
```VB
' Add "Rainbird.PdfTools" as reference to your Excel workbook 
' (menu "Tools" -> "References") in VBA editor.

Dim objPdfFormFiller As Rainbird_PdfTools.PdfFormFiller
Set objPdfFormFiller = New Rainbird_PdfTools.PdfFormFiller

' Load empty template PDF file and specify the path to the filled out destination PDF file. 
objPdfFormFiller.LoadPdfDocument "SOURCE.PDF" "DESTINATION.PDF"

' Set PDF form field value
objPdfFormFiller.SetFieldValue "FIELDNAME", "VALUE"

' Close and tidy up
objPdfFormFiller.ClosePdfDocument
```
