using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreGameAPI.Models
{
    public class SandboxElement
    {
        [Key]
        public int SandboxElementKey { get; set; }

        public virtual SandboxElementStyle SandboxElementStyle { get; set; }
    }
}
