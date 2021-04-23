using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AddManagerPanel : BaseScreen
    {
        [SerializeField] private Button _editName = default;
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TMP_InputField _phone = default;
        [SerializeField] private TMP_InputField _email = default;
        [SerializeField] private TMP_InputField _salary = default;
        [SerializeField] private TMP_InputField _login = default;
        [SerializeField] private TMP_InputField _password = default;
        [SerializeField] private Toggle _storekeeperRole = default;
        [SerializeField] private Button _add = default;

        public void Init(Action callback)
        {
            ShowSelf();
            _add.onClick.AddListener(() =>
            {
                Hide();
                callback.Invoke();
            });
        }
        
        private void Awake()
        {
            if (ScreensService.AddManagerPanel == null)
                ScreensService.AddManagerPanel = this;
            
            _editName.onClick.AddListener(OnEditNameButtonHandler);
            OnScreenShow += Reset;
        }

        private void OnDestroy()
        {
            OnScreenShow -= Reset;
        }

        private void OnEditNameButtonHandler()
        {
            //TODO: show popup with input field
        }

        private void Reset()
        {
            _name.text = LocalizationService.DefaultManagerName;
            _phone.text = string.Empty;
            _email.text = string.Empty;
            _salary.text = string.Empty;
            _login.text = string.Empty;
            _password.text = string.Empty;
            _storekeeperRole.isOn = false;
            _add.onClick.RemoveAllListeners();
        }
    }
}
