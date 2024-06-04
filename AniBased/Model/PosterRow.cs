using AniBased.View.Home;
using AniBased.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model
{
    class PosterRow
    {
        public PosterVM PosterVM { get; set; }

        public PosterRow(PosterVM poster)
        {
            this.PosterVM = poster;  
        }
    }
}
