using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;

namespace TestTask1
{
    class Asset : BindableBase
    {
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
        /// <summary>
        /// Для чего наименование банка в базовом классе? 
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// Не очень ясно для чего предполагалось использовать?
        /// </summary>
        public virtual bool IsSaved { get; set; }
    }
}