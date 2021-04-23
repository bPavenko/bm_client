using Screens.Bars;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class CharacteristicItem : MonoBehaviour
    {
        [SerializeField] private IconHolder _iconHolder = default;
        [SerializeField] private Button _openOptions = default;
        [SerializeField] private Button _hideOptions = default;
        [SerializeField] private GameObject _optionsBar = default;
        [SerializeField] private Button _setOption = default;
        [SerializeField] private Button _deleteOption = default;
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _value = default;

        public void Init()//TODO: init by CharacteristicData model (add if not exists)
        {
            
        }

        private void Awake()
        {
            _openOptions.onClick.AddListener(OnOpenOptionsButtonHandler);
            _hideOptions.onClick.AddListener(OnHideOptionsButtonHandler);
            _setOption.onClick.AddListener(OnSetOptionButtonHandler);
            _deleteOption.onClick.AddListener(OnDeleteOptionButtonHandler);
        }

        private void OnOpenOptionsButtonHandler()
        {
            _optionsBar.SetActive(true);
        }

        private void OnHideOptionsButtonHandler()
        {
            _optionsBar.SetActive(false);
        }

        private void OnSetOptionButtonHandler()
        {
            
        }

        private void OnDeleteOptionButtonHandler()
        {
            
        }
    }
}
