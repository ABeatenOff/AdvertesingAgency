using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertesingAgency
{
    internal class ConnectDB
    {
        private static AdvertisingAgencyEntities _contxt;
        public static AdvertisingAgencyEntities Contxt()
        {  
            if (_contxt == null)
                _contxt = new AdvertisingAgencyEntities();
            return _contxt;
        }
    }
}
