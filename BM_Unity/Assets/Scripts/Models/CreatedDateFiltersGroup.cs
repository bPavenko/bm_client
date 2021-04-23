using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Models
{
    public class CreatedDateFiltersGroup : MonoBehaviour
    {
        [SerializeField] private List<CreatedDateFilterItem> _filters = default;

        public void Init(Action<CreatedDateFilterItem> onSelectFilterHandler)
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
