//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdvertesingAgency
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public int id_dept { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
    
        public virtual Dept Dept { get; set; }
    }
}