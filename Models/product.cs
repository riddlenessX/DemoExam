namespace Masterpol.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterpol.product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            partner_products = new HashSet<partner_products>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int article { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? product_type_id { get; set; }

        public string description { get; set; }

        [StringLength(255)]
        public string image_link { get; set; }

        public decimal? min_cost { get; set; }

        public decimal? width { get; set; }

        public decimal? height { get; set; }

        public decimal? length { get; set; }

        public decimal? netto { get; set; }

        public decimal? brutto { get; set; }

        [StringLength(255)]
        public string certificate_image_link { get; set; }

        [StringLength(255)]
        public string standart_number { get; set; }

        [StringLength(255)]
        public string production_time { get; set; }

        public decimal? cost_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<partner_products> partner_products { get; set; }

        public virtual product_type product_type { get; set; }
    }
}
