using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Furniture.Models.Context
{
    public partial class sysdiagram
    {
        public string name { get; set; }
        public int principal_id { get; set; }
        public int diagram_id { get; set; }
        public int version { get; set; }
        public byte[] definition { get; set; }
    }
}
