namespace Masterpol.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("masterpol.partner")]
    public partial class partner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public partner()
        {
            partner_products = new HashSet<partner_products>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        public int? partner_type_id { get; set; }

        [StringLength(255)]
        public string legal_address { get; set; }

        [StringLength(12)]
        public string individual_taxpayer_number { get; set; }

        [StringLength(30)]
        public string contact_number { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        [StringLength(255)]
        public string logo_image_link { get; set; }

        public int? rating { get; set; }

        public int? director_id { get; set; }

        public virtual director director { get; set; }

        public virtual partner_type partner_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<partner_products> partner_products { get; set; }

        public int CalculateTotalSales()
        {
            // Суммируем все количество продукции для этого партнера
            return partner_products?.Sum(p => p.quantity ?? 0) ?? 0;
        }
    }
}
