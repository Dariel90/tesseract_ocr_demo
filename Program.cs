using System;
using Tesseract;

namespace tesseract_ocr_demo
{
    class Program
    {
        private const string TestImagePath = "Ocr/phototest.tif";
        private const string TeicketFoto = "Ocr/ticket-solo-sin-letras.jpg";
        
        private const string Ticket = "Ocr/Ticket1.png";
        static void Main(string[] args)
        {
            var result = CanParseText();
            Console.WriteLine("Devuelve el texto de una imagen");
            Console.WriteLine(result);
            //var result2 = CanProcessSpecifiedRegionInImage();
            //Console.WriteLine(result2);
            //Console.ReadLine();
        }

        public static string CanParseText()
        {
            using (var engine = TEngine.CreateEngine("cat"))
            {
                using (var img = TEngine.LoadTestPix(TeicketFoto))
                {
                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();

                        //const string expectedText =
                        //    "This is a lot of 12 point text to test the\nocr code and see if it works on all types\nof file format.\n\nThe quick brown dog jumped over the\nlazy fox. The quick brown dog jumped\nover the lazy fox. The quick brown dog\njumped over the lazy fox. The quick\nbrown dog jumped over the lazy fox.\n";

                        return text;
                    }
                }
            }
        }

        public static string CanProcessSpecifiedRegionInImage()
        {
            using (var engine = TEngine.CreateEngine(mode: EngineMode.LstmOnly))
            {
                using (var img = TEngine.LoadTestPix(TestImagePath))
                {
                    using (var page = engine.Process(img, Rect.FromCoords(0, 0, img.Width, 188)))
                    {
                        var region1Text = page.GetText();

                        //const string expectedTextRegion1 =
                        //    "This is a lot of 12 point text to test the\nocr code and see if it works on all types\nof file format.\n";

                        return region1Text;
                    }
                }
            }
        }
    }
}
