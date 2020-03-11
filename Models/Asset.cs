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
        public string BankName { get; set; }
        public virtual bool IsSaved { get; set; }
    }
}