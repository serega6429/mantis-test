﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_test
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get; set; }

        public int CompareTo(ProjectData other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(ProjectData other)
        {
            return this.Name.Equals(other.Name);
        }
    }
}
