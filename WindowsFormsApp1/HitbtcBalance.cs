using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class HitbtcBalance
    {

        [JsonProperty("currency")]
        public string currency { get; set; }
        [JsonProperty("available")]
        public string available { get; set; }
        [JsonProperty("reserved")]
        public string reserved { get; set; }
        
    }
}
