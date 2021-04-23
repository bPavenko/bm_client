using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AddStorekeeperPanel : BaseScreen
    {
        [SerializeField] private Button _editName = default;
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TMP_InputField _phone = default;
        [SerializeField] private TMP_InputField _login = default;
        [SerializeField] private TMP_InputField _password = default;
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
            if (ScreensService.AddStorekeeperPanel == null)
                ScreensService.AddStorekeeperPanel = this;
            
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
            _name.text = LocalizationService.DefaultStorekeeperName;
            _phone.text = string.Empty;
            _login.text = string.Empty;
            _password.text = string.Empty;
            _add.onClick.RemoveAllListeners();
        }
    }
}
