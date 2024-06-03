using AniBased.Model.Entities.EntitiesOfGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.Entities.EntitiesOfStudio
{
    class RegistryOfStudio
    {
        public List<Studio> Studios { get; }

        public void AddStudio(Studio studio)
        {
            if (!IsStudioContains(studio)) { Studios.Add(studio); }
        }

        public void RemoveStudio(Studio studio)
        {
            if (IsStudioContains(studio)) { Studios.Remove(studio); }
        }

        private bool IsStudioNotNull(Studio studio)
        {
            if (studio == null) return false; else return true;
        }

        private bool IsStudioContains(Studio studio)
        {
            if (IsStudioNotNull(studio))
                if (Studios.Contains(studio)) return true; else return false;
            else throw new ArgumentNullException();
        }
    }
}
