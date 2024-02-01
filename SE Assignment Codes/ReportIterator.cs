using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    interface ReportIterator
    {
        bool HasNext();
        Report Next();
    }
}
