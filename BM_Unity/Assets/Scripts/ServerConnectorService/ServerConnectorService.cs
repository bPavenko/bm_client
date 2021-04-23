using Server.Controllers;

namespace Server
{
    public static class ServerConnectorService
    {
        public static AuthController AuthController { get; private set; }
        public static OrdersController OrdersController { get; private set; }

        public static void Init()
        {
            AuthController = new AuthController();
            OrdersController = new OrdersController();
        }
    }
}
