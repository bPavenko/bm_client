using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class CreatedDateFilterItem : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle = default;
        [SerializeField] private CreatedDateType _createdDateType;
        
        public CreatedDateType CreatedDateType => _createdDateType;

        private Action<CreatedDateFilterItem> _onFilterSelectedHandler;

        public void Init(Action<CreatedDateFilterItem> onFilterSelectedHandler)
        {
            _onFilterSelectedHandler = onFilterSelectedHandler;
        }

        public void Clear()
        {
            _toggle.isOn = false;
        }
        
        private void Awake()
        {
            _toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }

        private void OnToggleValueChanged(bool isOn)
        {
            if(isOn)
                _onFilterSelectedHandler.Invoke(this);
        }
    }
}
