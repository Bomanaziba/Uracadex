using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uracadex.Models
{
    public class SNARSListViewModel
    {
        public string Message { get; set; }
        public List<SNARSViewModel> SNARSList { get; set; }
    }
}