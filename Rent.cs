//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Palashicheva_ProkatCars
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rent
    {
        public int IdRent { get; set; }
        public int ClientId { get; set; }
        public int CarId { get; set; }
        public System.DateTime StartDate { get; set; }
        public int Days { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Client Client { get; set; }
    }
}
