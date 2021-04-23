using System;

namespace Common
{
    public static class EventsService
    {
        public static Action OnScreensServiceInitialized { get; set; }
        public static Action OnLocalDataBaseUpdated { get; set; }
        public static Action OnAuthorizationSuccess { get; set; }
        public static Action OnLogout { get; set; }
    }
}
