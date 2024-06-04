using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.DAL
{
    internal class StatisticalInformationOfSeriesDAL
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public int CurrentInSeries { get; set; }
        public TimeOnly CurrentTimeOfView { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
