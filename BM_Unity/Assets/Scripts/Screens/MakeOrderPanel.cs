using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class MakeOrderPanel : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _orderNumber = default;
        [SerializeField] private Button _editOrderNumber = default;
        [SerializeField] private TextMeshProUGUI _orderDate = default;
        [SerializeField] private TextMeshProUGUI _orderSum = default;
        [SerializeField] private TextMeshProUGUI _orderProductsCount = default;
        [SerializeField] private TextMeshProUGUI _orderSumWithDiscount = default;
        [SerializeField] private Button _selectClient = default;
        [SerializeField] private TextMeshProUGUI _selectedClient = default;
        [SerializeField] private Button _editSelectedClient = default;
        [SerializeField] private TMP_InputField _commentField = default;
        [SerializeField] private GameObject _productItemPrefab = default;
        [SerializeField] private Transform _productItemsParent = default;
        [SerializeField] private Button _makeOrder = default;

        public void Init()//TODO: init panel by order model
        {
            
        }
        
        private void Awake()
        {
            if (ScreensService.MakeOrderPanel == null)
                ScreensService.MakeOrderPanel = this;
            
            _editOrderNumber.onClick.AddListener(OnEditOrderNumberButtonHandler);
            _selectClient.onClick.AddListener(OnSelectClientButtonHandler);
            _editSelectedClient.onClick.AddListener(OnEditSelectedClientButtonHandler);
            _makeOrder.onClick.AddListener(OnMakeOrderButtonHandler);
        }

        private void OnEditOrderNumberButtonHandler()
        {
            
        }

        private void OnSelectClientButtonHandler()
        {
            
        }

        private void OnEditSelectedClientButtonHandler()
        {
            
        }

        private void OnMakeOrderButtonHandler()
        {
            
        }

        private void Reset()
        {
            _selectClient.gameObject.SetActive(true);
            _editSelectedClient.gameObject.SetActive(false);
        }
    }
}
