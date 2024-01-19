using AutoPost.Presentation.Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoPost.Presentation.Desktop.Controllers
{
    internal class AutomationController 
    {
        private const string FileName = "AutomationSettings.json";

        public AutomationController()
        {
            if (!File.Exists(FileName))
            {
                try
                {
                    Save(new());
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void Save(AutomationSettings automationSettings)
        {
            if (automationSettings == null) { return; }
            string jsonString = JsonSerializer.Serialize(automationSettings);
            File.WriteAllText(FileName, jsonString);
        }
        public AutomationSettings? Load()
        {
            try
            {
                string jsonString = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<AutomationSettings>(jsonString);
            }
           catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}

