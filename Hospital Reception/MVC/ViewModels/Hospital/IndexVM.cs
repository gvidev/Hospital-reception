using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.ViewModels.Hospital
{
    public class IndexVM
    {
        public FilterVM Filter { get; set; }

        public List<HospitalVM> Items { get; set; }
        public PagerVM Pager { get; set; }
    }
}