using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AccountPanel : BaseScreen
    {
        [SerializeField] private Image _avatarImg = default;
        [SerializeField] private TextMeshProUGUI _userNameText = default;
        [SerializeField] private TextMeshProUGUI _userRoleText = default;
        [SerializeField] private Transform _ordersParent = default;
        [SerializeField] private GameObject _orderPrefab = default;

        private void Init()
        {
            _userNameText.text = Core.Instance.CurrentUser.Name;
            _userRoleText.text = Core.Instance.CurrentUser.Role.ToString();//TODO: make method for get localized role in localization service
        }

        private void Awake()
        {
            EventsService.OnAuthorizationSuccess += OnAuthorizationSuccessHandler;
        }

        private void OnAuthorizationSuccessHandler()
        {
            Init();
            ShowSelf();
        }

        protected override void Back()
        {
            Core.Instance.CurrentUser = null;
            EventsService.OnLogout.Invoke();
            ScreensService.SelectOrganizationPanel.Show(this);
        }
    }
}
