using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels.Doctor
{
    public class IndexVM
    {
        public FilterVM Filter { get; set; }

        public List<DoctorVM> Items { get; set; }
        public PagerVM Pager { get; set; }
    }
}