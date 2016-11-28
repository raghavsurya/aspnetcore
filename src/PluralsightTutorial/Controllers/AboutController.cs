using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralsightTutorial.Controllers
{
    [Route("rag/[controller]/[action]")]
    public class AboutController
    {
      
        public string Phone()
        {
            return "04452879687";
        }

        [Route("address")]
        public string Address()
        {
            return "TG Nagar";
        }
    }
}
