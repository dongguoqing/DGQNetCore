using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel
{
    public class TreeViewModel
    {
        public string title { get; set; }
        public bool expand { get; set; }
        public bool selected { get; set; }
        public string parentId { get; set; }
        public string id { get; set; }
        public string @checked { get; set; }
        public bool hasChildren { get; set; }
    }
}
