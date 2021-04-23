using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class OrderStatusFilterItem : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle = default;
        [SerializeField] private OrderStatusType _orderStatusType;

        public OrderStatusType OrderStatusType => _orderStatusType;

        private Action<OrderStatusFilterItem> _onSelectedHandler;
        
        public void Init(Action<OrderStatusFilterItem> onSelectedHandler)
        {
            _onSelectedHandler = onSelectedHandler;
        }

        public void Clear()
        {
            _toggle.isOn = false;
        }
        
        private void Awake()
        {
            _toggle.onValueChanged.AddListener(OnToggleValueChangedHandler);
        }

        private void OnToggleValueChangedHandler(bool isOn)
        {
            if(isOn)
                _onSelectedHandler.Invoke(this);
        }
    }
}
