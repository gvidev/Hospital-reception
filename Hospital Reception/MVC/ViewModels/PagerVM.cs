using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class PagerVM
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }
    }
}