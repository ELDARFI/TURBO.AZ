using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_az
{
    [Serializable]

    internal class markas
    {
        public static int counter = 0;

        public markas()
        {
            this.markaid = ++counter;
        }

        public int markaid
        {
            get;
            set;
        }
        public string markaname
        {
            get;
            set;
        }

        public override string ToString()
        {
            return $"Id: {markaid} || Brand: {markaname}";
        }
    }
}
