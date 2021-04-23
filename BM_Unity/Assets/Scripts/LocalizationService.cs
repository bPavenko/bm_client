using Assets.SimpleLocalization;
using UnityEngine;

namespace Common
{
    public static class LocalizationService
    {
        public static string NoCompany { get; private set; }
        public static string UnknownLogin { get; private set; }
        public static string InvalidPassword { get; private set; }
        public static string InvalidOrganizationIp { get; private set; }
        public static string UnknownError { get; private set; }
        public static string PositivePopupText { get; private set; }
        public static string NegativePopupText { get; private set; }
        public static string AttentionText { get; private set; }
        public static string DefaultClientName { get; private set; }
        public static string DefaultManagerName { get; private set; }
        public static string DefaultStorekeeperName { get; private set; }
        public static string DefaultCashierName { get; private set; }
        
        public static void Init()
        {
            Load();
            NoCompany = LocalizationManager.Localize("NoCompanyText");
            UnknownLogin = LocalizationManager.Localize("UnknownLogin");
            InvalidPassword = LocalizationManager.Localize("InvalidPassword");
            InvalidOrganizationIp = LocalizationManager.Localize("InvalidOrganizationIp");
            UnknownError = LocalizationManager.Localize("UnknownError");
            PositivePopupText = LocalizationManager.Localize("OkText");
            NegativePopupText = LocalizationManager.Localize("CancelText");
            AttentionText = LocalizationManager.Localize("AttentionText");
            DefaultClientName = LocalizationManager.Localize("DefaultClientNameText");
            DefaultStorekeeperName = LocalizationManager.Localize("DefaultStorekeeperNameText");
            DefaultCashierName = LocalizationManager.Localize("DefaultCashierNameText");
        }
        
        private static void Load() {
            LocalizationManager.Read();
            switch (Application.systemLanguage) {
                case SystemLanguage.Russian:
                    LocalizationManager.Language = "Russian";
                    break;
                case SystemLanguage.Ukrainian:
                    LocalizationManager.Language = "Ukrainian";
                    break;
                default:
                    LocalizationManager.Language = "Russian";
                    break;
            }
        }
    }
}
