using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace tesseract_ocr_demo
{
    public static class TEngine
    {
        public static TesseractEngine CreateEngine(string lang = "eng", EngineMode mode = EngineMode.Default)
        {
            var datapath = DataPath;
            return new TesseractEngine(datapath, lang, mode);
        }

        private static string DataPath
        {
            get { return AbsolutePath("tessdata"); }
        }
        private static string AbsolutePath(string relativePath)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            return Path.Combine(Path.GetDirectoryName(path), relativePath);
        }
        public static Pix LoadTestPix(string filename)
        {
            var testFilename = TestFilePath(filename);
            return Pix.LoadFromFile(testFilename);
        }
        private static string TestFilePath(string path)
        {
            var basePath = AbsolutePath("Data");

            return Path.GetFullPath(Path.Combine(basePath, path));
        }
    }
}
