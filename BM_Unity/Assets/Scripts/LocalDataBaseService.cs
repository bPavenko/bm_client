using System.Collections.Generic;
using Common.Models;
using UnityEngine;
using Utils;

namespace Common
{
    public class LocalDataBaseService
    {
        private static string ORGANIZATIONS_PREFS = "organizations";
        private static List<OrganizationItem> _organizationItems;

        public static List<OrganizationItem> Organizations => _organizationItems;
        
        public static void Init()
        {
            var list = new List<OrganizationItem>();
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString(ORGANIZATIONS_PREFS, string.Empty)))
                list = Crypt.Decode<List<OrganizationItem>>(PlayerPrefs.GetString(ORGANIZATIONS_PREFS));
            _organizationItems = list;
            EventsService.OnLocalDataBaseUpdated.Invoke();
        }

        public static void AddOrganization(OrganizationItem data)
        {
            _organizationItems.Add(data);
            Save();
            EventsService.OnLocalDataBaseUpdated.Invoke();
        }

        public static void RemoveOrganization(string code)
        {
            _organizationItems.RemoveAll(o => o.Code.Equals(code));
            Save();
            EventsService.OnLocalDataBaseUpdated.Invoke();
        }

        public static bool CheckExistsByName(string name)
        {
            return _organizationItems.Exists(o => o.Name.Equals(name));
        }

        public static bool CheckExistsByCode(string code)
        {
            return _organizationItems.Exists(o => o.Code.Equals(code));
        }

        private static void Save()
        {
            if(_organizationItems == null) return;
            if(_organizationItems.Count == 0) return;
            PlayerPrefs.SetString(ORGANIZATIONS_PREFS, Crypt.Encode(_organizationItems));
        }
    }
}
