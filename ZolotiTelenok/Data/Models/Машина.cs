using System;
using System.Collections.Generic;

namespace ZolotiTelenok
{
    public partial class Машина
    {
        public Машина()
        {
            Записьs = new HashSet<Запись>();
        }

        public int ИдМашины { get; set; }
        public string Марка { get; set; } = null!;
        public string Модель { get; set; } = null!;
        public int Класс { get; set; }

        public virtual ICollection<Запись> Записьs { get; set; }
    }
}
