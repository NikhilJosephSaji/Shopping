
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Business
{
    public class Logging
    {
        public ILogger logger { get { return Log.Logger; } }
    }
}
