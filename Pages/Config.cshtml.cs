using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace nobodyhome.Pages
{
    public class ConfigData
    {
        [Required]
        [Display(Name = "Meraki Dashboard API Key")]
        [DataType(DataType.Password)]
        public string ApiKey { get; set; }

        [Required]
        [Display(Name = "First device MAC address")]
        public string DeviceMac1 { get; set; }

        [Display(Name = "Second device MAC address")]
        public string DeviceMac2 { get; set; }

        [Required]
        [Display(Name = "First Roomba remote IP address")]
        public string RemoteIp1 { get; set; }

        [Display(Name = "Second Roomba remote IP address")]
        public string RemoteIp2 { get; set; }
    }

    public class ConfigModel : PageModel
    {
        [BindProperty]
        public ConfigData Data { get; set; }

        public void OnGet()
        {
            if (System.IO.File.Exists("NobodyHomeConfig.json"))
            {
                Data = JsonConvert.DeserializeObject<ConfigData>(System.IO.File.ReadAllText("NobodyHomeConfig.json"));
            }
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            System.IO.File.WriteAllText("NobodyHomeConfig.json", JsonConvert.SerializeObject(Data));
            return RedirectToPage("./Index");
        }
    }
}
