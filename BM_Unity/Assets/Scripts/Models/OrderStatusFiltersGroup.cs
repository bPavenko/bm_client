using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Models
{
    public class OrderStatusFiltersGroup : MonoBehaviour
    {
        [SerializeField] private List<OrderStatusFilterItem> _filters = default;

        public void Init(Action<OrderStatusFilterItem> onSelectFilterHandler)
        {
            _filters.ForEach(item =>
            {
                item.Init(onSelectFilterHandler);
            });
        }

        public void Clear()
        {
            _filters.ForEach(item =>
            {
                item.Clear();
            });
        }
    }
}
