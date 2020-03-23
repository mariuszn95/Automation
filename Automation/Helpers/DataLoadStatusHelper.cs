namespace Automation.Helpers
{
    using System;
    using System.IO;

    using Automation.Models;
    using Automation.PageObject.MotherShip.Reports;
    using Automation.PageObject.Pages;

    using Newtonsoft.Json;

    public class DataLoadStatusHelper
    {
        private static readonly string _dataLoadStatusConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_load_status.json");

        public static bool ConfigurationExists => File.Exists(_dataLoadStatusConfigPath);

        public static void SaveConfiguration(DataLoadStatusPage page)
        {
            ReportsMotherShip.SetDataLoadStatuses(page);

            using (StreamWriter file = File.CreateText(_dataLoadStatusConfigPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, ReportsMotherShip.DataLoadStatus);
            }
        }

        public static void LoadConfiguration()
        {
            DataLoadStatus dataLoadStatus = JsonConvert.DeserializeObject<DataLoadStatus>(File.ReadAllText(_dataLoadStatusConfigPath));
            ReportsMotherShip.DataLoadStatus = dataLoadStatus;
        }
    }
}