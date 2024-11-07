namespace Masterpol.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterpol.material")]
    public partial class material
    {
        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? supplier_id { get; set; }

        public int? material_type_id { get; set; }

        public int? package_quantity { get; set; }

        [StringLength(20)]
        public string unit_name { get; set; }

        public string description { get; set; }

        [StringLength(255)]
        public string image_link { get; set; }

        public decimal? cost { get; set; }

        public int? quantity_in_stock { get; set; }

        public int? min_required_quantity { get; set; }

        public virtual supplier supplier { get; set; }

        public virtual material_type material_type { get; set; }
    }
}
