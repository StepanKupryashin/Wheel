//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wheel
{
    using System;
    using System.Collections.Generic;
    
    public partial class orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orders()
        {
            this.orders_products = new HashSet<orders_products>();
        }
    
        public System.DateTime created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string customer { get; set; }
        public string delivery_address { get; set; }
        public Nullable<long> user_id { get; set; }
        public int id { get; set; }

        public float price { 
            get
            {
                List<products> products = new List<products>();
                products = Util.getProductsOrder(this.id);
                float sum = 0;
                foreach(var product in products)
                {
                    sum += (float)(product.price - product.discount);
                }
                return sum;
            }
           }
    public float discount { 
            get
            {
                List<products> products = new List<products>();
                products = Util.getProductsOrder(this.id);
                float sum = 0;
                foreach (var product in products)
                {
                    sum += (float)(product.discount);
                }
                return sum;
            }

        }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orders_products> orders_products { get; set; }
    }
}
