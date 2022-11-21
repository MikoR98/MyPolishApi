using MoneyManager.Properties;
using System.Configuration;

namespace MoneyManager.Services
{
    public class AppConfiguration
    {
        public string AccountNumber { get; set; }
        public string Owner { get; set; }

        public decimal GetBudgetForMonth(string key)
        {
            var budget = 0m;

            var budgetSettings = GetUserSection();
            if (budgetSettings != null)
            {
                var element = budgetSettings.Settings.Get(key);
                if (element != null)
                {
                    decimal.TryParse(element.Value.ValueXml.InnerText, out budget);
                }
            }

            return budget;
        }

        public void AddOrUpdateBudgetForMonth(decimal budget, string key)
        {
            try
            {
                var budgetProperty = Settings.Default[key];
                Settings.Default[key] = budget;

                Settings.Default.Save();
            }
            catch
            {
                var newBudget = new SettingsProperty(key);
                newBudget.PropertyType = typeof(decimal);
                newBudget.IsReadOnly = false;
                newBudget.SerializeAs = SettingsSerializeAs.String;
                newBudget.Provider = Settings.Default.Providers["LocalFileSettingsProvider"];
                newBudget.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
                Settings.Default.Properties.Add(newBudget);
                Settings.Default.Reload();
                Settings.Default[key] = budget;
                Settings.Default.Save();
            }
        }

        private ClientSettingsSection GetUserSection()
        {
            var userConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);

            if (userConfig == null)
                return null;

            try
            {
                var userSettings = userConfig.GetSectionGroup("userSettings");
                if (userSettings != null && userSettings.Sections["MoneyManager.Properties.Settings"] is ClientSettingsSection budgetSettings)
                    return budgetSettings;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
