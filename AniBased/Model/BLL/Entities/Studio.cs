﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AniBased.Model.BLL.Entities
{
    public class Studio
    {
        public string Name { get; }
        public string Description { get; }

        public Studio(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
