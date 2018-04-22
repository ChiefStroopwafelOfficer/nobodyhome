using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace nobodyhome.Pages
{
    public class MonitorModel : PageModel
    {
        [JsonIgnore]
        public ConfigData Configuration  { get; set; }
        
    }
}
