using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask1
{
    class Unreliabe : Asset
    {
        public override string Name { get; set; }

        public override string Value
        {
            get =>
                $"StartMount: {StartMount}, Residual Value: {ResidualValue}, Assessed Value: {AssessedValue}, Inventory number: {InventoryNumber}";
            set => throw new NotImplementedException();
        }

        public Unreliabe(string name)
        {
            Name = name;
        }

        public int StartMount { get; set; }

        public int ResidualValue { get; set; }

        public int AssessedValue { get; set; }

        public int InventoryNumber { get; set; }
    }
}