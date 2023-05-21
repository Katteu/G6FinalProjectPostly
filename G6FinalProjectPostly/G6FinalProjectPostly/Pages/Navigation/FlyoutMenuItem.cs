using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G6FinalProjectPostly.Pages.Navigation
{

    public class FlyoutMenuItem
    {
        //public FlyoutMenuItem()
        //{
        //    TargetType = typeof(FlyoutMenuItem);
        //}
        public string Title { get; set; }
        public string IconSource { get; set; }

        public Type TargetPage { get; set; }
    }
}