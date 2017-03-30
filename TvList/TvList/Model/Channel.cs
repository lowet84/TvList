using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvList.Model
{
    [DebuggerDisplay("{Name}")]
    public class Channel
    {
        public Channel(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
