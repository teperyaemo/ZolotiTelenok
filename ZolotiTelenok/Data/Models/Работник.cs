using System;
using System.Collections.Generic;

namespace ZolotiTelenok
{
    public partial class Работник
    {
        public Работник()
        {
            Записьs = new HashSet<Запись>();
        }

        public int ИдРаботника { get; set; }
        public string Фамилия { get; set; } = null!;
        public string Имя { get; set; } = null!;
        public string Отчество { get; set; } = null!;
        public string Телефон { get; set; } = null!;

        public virtual ICollection<Запись> Записьs { get; set; }
    }
}
