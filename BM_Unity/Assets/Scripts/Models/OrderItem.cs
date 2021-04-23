using Server.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class OrderItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _orderIdText = default;
        [SerializeField] private TextMeshProUGUI _orderDateText = default;
        [SerializeField] private TextMeshProUGUI _orderSumText = default;
        [SerializeField] private GameObject _installmentStatusObj = default;
        [SerializeField] private GameObject _paidStatusObj = default;
        [SerializeField] private GameObject _notPaidStatusObj = default;
        [SerializeField] private GameObject _shippedStatusObj = default;
        [SerializeField] private Button _openButton = default;

        private OrderData _data;

        public void Init(OrderData data)
        {
            _data = data;
            _orderIdText.text = _data.Id;
            _orderDateText.text = _data.CreatedDate;
            _orderSumText.text = $"{_data.Sum} {_data.Currency}";
            CheckStatus(_data.PaidStatus);
            _shippedStatusObj.SetActive(_data.IsShipped);
        }

        private void CheckStatus(OrderData.StatusType status)
        {
            switch (status)
            {
                case OrderData.StatusType.Installment:
                    _installmentStatusObj.SetActive(true);
                    break;
                case OrderData.StatusType.Paid:
                    _paidStatusObj.SetActive(true);
                    break;
                case OrderData.StatusType.NotPaid:
                    _notPaidStatusObj.SetActive(true);
                    break;
            }
        }
        
        private void Awake()
        {
            _openButton.onClick.AddListener(OnOpenButtonHandler);
        }

        private void OnOpenButtonHandler()
        {
            //TODO: open order panel with _data info
        }
    }
}
