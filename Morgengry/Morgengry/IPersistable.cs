using System;
using System.Collections.Generic;
using System.Text;

namespace Morgengry
{
    public interface IPersistable
    {
        public void Save();
        public void Save(string fileName);
        public void Load();
        public void Load(string fileName);
    }
}
