using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restudemy.Data.Converter
{
    public interface IParser<O,D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
