using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask1
{
    class Money : Asset
    {
        public override string Name { get; set; }

        /// <summary>
        /// Может стоило сделать readonly? 
        /// </summary>
        public override string Value
        {
            get => $"{Mount} {Currency}";
            set => throw new NotImplementedException();
        }

        public Money(string name)
        {
            Name = name;
        }

        public int Mount { get; set; }

        public string Currency { get; set; }
    }
}