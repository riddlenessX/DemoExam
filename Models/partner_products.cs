namespace Masterpol.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterpol.partner_products")]
    public partial class partner_products
    {
        public int id { get; set; }

        public int? product_article { get; set; }

        public int? partner_id { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? sale_date { get; set; }

        public virtual partner partner { get; set; }

        public virtual product product { get; set; }
    }
}
