using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public interface IValuable
    {
        public double GetValue();

        public string CreateLineToSave();
    }
}
