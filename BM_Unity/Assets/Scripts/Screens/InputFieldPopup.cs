using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class InputFieldPopup : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _message = default;
        [SerializeField] private TextMeshProUGUI _enterButtonText = default;
        [SerializeField] private Button _cancel = default;
        [SerializeField] private Button _enter = default;

        public void ShowQuestion(string message, Action cancelCallback, Action enterCallback, string enterText = "OK")
        {
            _message.text = message;
            _enterButtonText.text = enterText;
            _cancel.onClick.RemoveAllListeners();
            _cancel.onClick.AddListener(() =>
            {
                Hide();
                cancelCallback.Invoke();
            });
            _enter.onClick.RemoveAllListeners();
            _enter.onClick.AddListener(() =>
            {
                Hide();
                enterCallback.Invoke();
            });
            ShowSelf();
        }

        private void Awake()
        {
            if (ScreensService.InputFieldPopup == null)
                ScreensService.InputFieldPopup = this;
        }
    }
}
