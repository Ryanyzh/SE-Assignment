
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_Assignment_Codes
{
    interface Aggregate
    {
        ConcreteReportIterator CreateIterator();
    }
}