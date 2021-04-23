using Common.Models;
using Screens;
using Server;
using Server.Models;
using UnityEngine;

namespace Common
{
    public class Core : MonoBehaviour
    {
        [SerializeField] private BaseScreen _startScreen = default;

        public static Core Instance { get; private set; }
        
        
        public OrganizationItem SelectedOrganization { get; set; }
        public UserData CurrentUser { get; set; }

        private void Awake()
        {
            Instance = this;
            InitServices();
            InitScreens();
        }

        private void InitScreens()
        {
            _startScreen.ShowSelf();
        }

        private void InitServices()
        {
            LocalizationService.Init();
            LocalDataBaseService.Init();
            ServerConnectorService.Init();
        }
    }
}
