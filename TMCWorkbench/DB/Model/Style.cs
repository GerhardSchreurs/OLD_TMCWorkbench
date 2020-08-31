using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TMCWorkbench.DB.Model
{
    public class Style
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Style_id { get; set; }

        public int? Parent_style_id { get; set; }
        public int? Alt_style_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Weight { get; set; }

        [ForeignKey("Parent_style_id")]
        public virtual Style ParentStyle { get; set; }
        public virtual ICollection<Style> ParentStyleChildren { get; set;  }

        [ForeignKey("Alt_style_id")]
        public virtual Style ParentAltStyle { get; set; }
        public virtual ICollection<Style> ParentAltStyleChildren { get; set; }
    }
}
