using System;
using System.Collections.Generic;

namespace ZolotiTelenok
{
    public partial class Запись
    {
        public int ИдЗаписи { get; set; }
        public int ИдМашины { get; set; }
        public int ИдРаботнка { get; set; }
        public int ИдУслуги { get; set; }
        public DateTime Дата { get; set; }
        public decimal Сумма { get; set; }

        public virtual Машина ИдМашиныNavigation { get; set; } = null!;
        public virtual Работник ИдРаботнкаNavigation { get; set; } = null!;
        public virtual Услуги ИдУслугиNavigation { get; set; } = null!;
    }
}
