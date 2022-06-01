using System;
using System.Collections.Generic;

namespace ZolotiTelenok
{
    public partial class Услуги
    {
        public Услуги()
        {
            Записьs = new HashSet<Запись>();
        }

        public int ИдУслуги { get; set; }
        public string Наименование { get; set; } = null!;
        public string Описание { get; set; } = null!;
        public decimal Цена { get; set; }

        public virtual ICollection<Запись> Записьs { get; set; }
    }
}
