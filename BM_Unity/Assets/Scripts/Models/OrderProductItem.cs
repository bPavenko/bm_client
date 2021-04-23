using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class OrderProductItem : MonoBehaviour
    {
        [SerializeField] private Image _productIcon = default;
        [SerializeField] private TextMeshProUGUI _productName = default;
        [SerializeField] private TextMeshProUGUI _productCount = default;
        [SerializeField] private Button _optionsButton = default;
        [SerializeField] private GameObject _optionsPanel = default;
        [SerializeField] private Button _editOptionButton = default;
        [SerializeField] private Button _deleteOptionButton = default;
        [SerializeField] private Button _hideOptionButton = default;
        
        //TODO: realize item initialization

        private void Awake()
        {
            _optionsButton.onClick.AddListener(OnOptionsButtonHandler);
        }

        private void OnOptionsButtonHandler()
        {
            //TODO: show options panel
        }
    }
}
