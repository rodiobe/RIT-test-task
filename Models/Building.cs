using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask1.Models
{
    class Building : Asset
    {
        public Building(string name)
        {
            Name = name;
        }

        public override string Name { get; set; }
        public string Address { get; set; }
        public int ResidualValue { get; set; }
        public int AssessedValue { get; set; }
        public override string Value => $"{Name} Address: {Address}, Res Val: {ResidualValue}, Ass Val {AssessedValue}";
    }
}