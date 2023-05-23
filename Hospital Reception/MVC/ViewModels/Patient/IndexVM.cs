using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels.Patient
{
    public class IndexVM
    {
        public FilterVM Filter { get; set; }

        public List<PatientVM> Items { get; set; }
        public PagerVM Pager { get; set; }
    }
}