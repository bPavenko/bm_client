using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class OrderPanel : BaseScreen
    {
        [SerializeField] private Button _backButton = default;
        [SerializeField] private Button _saveButton = default;
        [SerializeField] private TextMeshProUGUI _orderName = default;
        [SerializeField] private TextMeshProUGUI _orderDate = default;
        [SerializeField] private GameObject _notPaidStatus = default;
        [SerializeField] private GameObject _paidStatus = default;
        [SerializeField] private GameObject _installmentStatus = default;
        [SerializeField] private GameObject _shippedStatus = default;
        [SerializeField] private TextMeshProUGUI _orderSum = default;
        [SerializeField] private TextMeshProUGUI _orderProductsCount = default;
        [SerializeField] private TMP_InputField _orderComment = default;
        [SerializeField] private GameObject _orderProductItemPrefab = default;
        [SerializeField] private Transform _orderProductItemsParent = default;
        [SerializeField] private Button _addProduct = default;
        [SerializeField] private Button _shipOrder = default;

        public void Init()
        {
            //TODO: realize initialization order panel
        }

        private void Awake()
        {
            if (ScreensService.OrderPanel == null)
                ScreensService.OrderPanel = this;
        }
    }
}
