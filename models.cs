using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TT_az
{
    [Serializable]

    internal class models
    {
        public static int counterr = 0;

        public models()
        {
            this.ModelID = ++counterr;
        }

        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int ModelMarkaId { get; set; }

        public override string ToString()
        {
            return $"Model ID: {ModelID} || Model: {ModelName} || Marka ID: {ModelMarkaId}";
        }
    }
}
