using Restudemy.Data.VO;
using Restudemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Business
{
    public interface IFileBusiness
    {
        byte[] GetPDFFile();
    }
}
