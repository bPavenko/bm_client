using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AddClientPanel : BaseScreen
    {
        [SerializeField] private Button _editName = default;
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TMP_InputField _phone = default;
        [SerializeField] private TMP_InputField _email = default;
        [SerializeField] private TMP_InputField _discount = default;
        [SerializeField] private TMP_InputField _comments = default;
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
            if (ScreensService.AddClientPanel == null)
                ScreensService.AddClientPanel = this;
            
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
            _name.text = LocalizationService.DefaultClientName;
            _phone.text = string.Empty;
            _email.text = string.Empty;
            _discount.text = string.Empty;
            _comments.text = string.Empty;
            _add.onClick.RemoveAllListeners();
        }
    }
}
