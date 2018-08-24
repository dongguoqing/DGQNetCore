using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Module
    {
        [Key]
        public int ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public string ModuleBrief { get; set; }
        public int ModuleLevel { get; set; }
        public int ModulePosition { get; set; }
        public string ModuleIndex { get; set; }
        public int ModuleStatus { get; set; }
        public string ModuleUrl { get; set; }
        public string UseActions { get; set; }
        public bool IsBigTable { get; set; }
        public int LimitCount { get; set; }
        public Guid Guid { get; set; }
        public int ModuleType { get; set; }
        public Guid UpperGuid { get; set; }
        public string ModuleIcon { get; set; }
    }
}
