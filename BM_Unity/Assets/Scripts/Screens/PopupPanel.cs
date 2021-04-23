using Common;
using Common.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class PopupPanel : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _title = default;
        [SerializeField] private TextMeshProUGUI _message = default;
        [SerializeField] private TextMeshProUGUI _negativeText = default;
        [SerializeField] private TextMeshProUGUI _positiveText = default;
        [SerializeField] private Button _negativeButton = default;
        [SerializeField] private Button _positiveButton = default;
        
        public void Init(PopupData data)
        {
            _title.text = data.Title;
            _message.text = data.Message;
            _negativeText.text = data.NegativeText;
            _negativeButton.onClick.RemoveAllListeners();
            _negativeButton.onClick.AddListener(() =>
            {
                Hide();
                data.NegativeAction?.Invoke();
            });
            _positiveText.text = data.PositiveText;
            _positiveButton.onClick.RemoveAllListeners();
            _positiveButton.onClick.AddListener(() =>
            {
                Hide();
                data.PositiveAction?.Invoke();
            });
            ShowSelf();
        }

        private void Awake()
        {
            if (ScreensService.PopupPanel == null)
                ScreensService.PopupPanel = this;
        }
    }
}
