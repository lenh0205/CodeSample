using Aspose.OCR;
using Aspose.OCR.Models.PreprocessingFilters;
using Microsoft.VisualBasic;

class ThreadTest
{
    static void Main()
    {
        PreprocessingFilter filter = new PreprocessingFilter {
            PreprocessingFilter.ContrastCorrectionFilter(),
            PreprocessingFilter.AutoDewarping()
        };
        OcrInput photos = new OcrInput(InputType.SingleImage, filter);
        photos.Add("photo.png");

        AsposeOcr api = new AsposeOcr();
        List<RecognitionResult> result = api.Recognize(photos);

        AsposeOcr.SaveMultipageDocument("test.pdf", SaveFormat.Pdf, result);
    }
}