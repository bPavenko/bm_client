using Screens;

namespace Common
{
    public static class ScreensService
    {
        public static PopupPanel PopupPanel { get; set; }
        public static MenuPanel MenuPanel { get; set; }
        public static FiltersPanel FiltersPanel { get; set; }
        public static SelectOrganizationPanel SelectOrganizationPanel { get; set; }
        public static AddOrganizationPanel AddOrganizationPanel { get; set; }
        public static AuthorizationPanel AuthorizationPanel { get; set; }
        public static AccountPanel AccountPanel { get; set; }
        public static OrdersPanel OrdersPanel { get; set; }
        public static OrderPanel OrderPanel { get; set; }
        public static CatalogPanel CatalogPanel { get; set; }
        public static ProductPanel ProductPanel { get; set; }
        public static MakeOrderPanel MakeOrderPanel { get; set; }
        public static NotesPanel NotesPanel { get; set; }
        public static NoteShowPanel NoteShowPanel { get; set; }
        public static ClientsPanel ClientsPanel { get; set; }
        public static AddClientPanel AddClientPanel { get; set; }
        public static ManagersPanel ManagersPanel { get; set; }
        public static AddManagerPanel AddManagerPanel { get; set; }
        public static StorekeepersPanel StorekeepersPanel { get; set; }
        public static AddStorekeeperPanel AddStorekeeperPanel { get; set; }
        public static CashiersPanel CashiersPanel { get; set; }
        public static AddCashierPanel AddCashierPanel { get; set; }
        public static ReportsPanel ReportsPanel { get; set; }
        
        public static QuestionPopup QuestionPopup { get; set; }
        public static InputFieldPopup InputFieldPopup { get; set; }
        public static SelectClientPopup SelectClientPopup { get; set; }
        public static SelectManagerPopup SelectManagerPopup { get; set; }
    }
}
