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
    
    public partial class orders_products
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public long product_id { get; set; }
    
        public virtual orders orders { get; set; }
        public virtual products products { get; set; }
    }
}
