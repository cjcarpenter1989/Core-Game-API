using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGameAPI.Models
{
    public class SandboxElementStyle
    {
        [Key]
        public int SandboxElementStyleKey { get; set; }

        public string Color { get; set; }
    }
}
