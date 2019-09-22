using Restudemy.Data.VO;
using System.IO;

namespace Restudemy.Business.inplementattions
{
    public class FileBusinessImpl : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fulPath = path + "\\Other\\aspnet-life-cycles-events.pdf";
            return File.ReadAllBytes(fulPath);
        }
    }
}
