using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Bars
{
    public class MenuLogoutBar : MonoBehaviour
    {
        [SerializeField] private Button _menu = default;
        [SerializeField] private Button _logout = default;

        private void Awake()
        {
            _menu.onClick.AddListener(OnMenuButtonHandler);
            _logout.onClick.AddListener(OnLogoutButtonHandler);
        }

        private void OnMenuButtonHandler()
        {
            ScreensService.MenuPanel.ShowSelf();
        }

        private void OnLogoutButtonHandler()
        {
            EventsService.OnLogout.Invoke();
        }
    }
}
