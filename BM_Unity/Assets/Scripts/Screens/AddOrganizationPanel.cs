using Common;
using Common.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AddOrganizationPanel : BaseScreen
    {
        [SerializeField] private TMP_InputField _name = default;
        [SerializeField] private TMP_InputField _code = default;
        [SerializeField] private TMP_InputField _ip = default;
        [SerializeField] private Button _addButton = default;
        [SerializeField] private Button _backButton = default;

        private void Awake()
        {
            if (ScreensService.AddOrganizationPanel == null)
                ScreensService.AddOrganizationPanel = this;
            _addButton.onClick.AddListener(OnAddButtonHandler);
            _backButton.onClick.AddListener(Back);
        }

        private void OnAddButtonHandler()
        {
            if(!CheckFieldsValid()) return;
            var org = new OrganizationItem
            {
                Name = _name.text,
                Code = _code.text,
                Ip = _ip.text
            };
            LocalDataBaseService.AddOrganization(org);
            ScreensService.AuthorizationPanel.Show(this, ScreensService.SelectOrganizationPanel);
        }

        protected override void Back()
        {
            base.Back();
            Clear();
        }

        private void Clear()
        {
            _name.text = string.Empty;
            _code.text = string.Empty;
            _ip.text = string.Empty;
        }

        private bool CheckFieldsValid()
        {
            if (string.IsNullOrEmpty(_name.text))
            {
                _name.Select();
                return false;
            }
            if (LocalDataBaseService.CheckExistsByName(_name.text))
            {
                _name.text = string.Empty;
                _name.Select();
                return false;
            }
            if (string.IsNullOrEmpty(_code.text))
            {
                _code.Select();
                return false;
            }
            if (LocalDataBaseService.CheckExistsByCode(_code.text))
            {
                _code.text = string.Empty;
                _code.Select();
                return false;
            }
            if (string.IsNullOrEmpty(_ip.text))
            {
                _ip.Select();
                return false;
            }
            return true;
        }
    }
}
