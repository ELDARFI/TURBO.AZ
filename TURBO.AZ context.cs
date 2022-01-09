using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_az
{
    internal class TT_context
    {
        public static GenericStore<markas> Markas { get; set; }
        public static GenericStore<models> Models { get; set; }
        public static GenericStore<cars> Cars { get; set; }
    }
}
