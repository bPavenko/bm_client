using System;
using System.Collections.Generic;
using Common;
using Common.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class FiltersPanel : BaseScreen
    {
        [Header("Panel settings:")]
        [SerializeField] private RectTransform _showPosition = default;
        [SerializeField] private RectTransform _hidePosition = default;
        [SerializeField] private float _moveSpeed = default;
        [SerializeField] private Button _applyFilter = default;

        [Header("Common:")] 
        [SerializeField] private Button _orderStatusFilterButton = default;
        [SerializeField] private Button _createdDateFilterButton = default;
        [SerializeField] private OrderStatusFiltersGroup _orderStatusFilters = default;
        [SerializeField] private CreatedDateFiltersGroup _createdDateFilters = default;

        private Transform _contentTransform;
        private FilterType _currentFilterType;
        private Action<Dictionary<FilterType, object>> _onFilterSelectedHandler;
        //TODO: use SelectedItem class, NOT dictionary for correct work
        private Dictionary<FilterType, object> _selectedItems = new Dictionary<FilterType, object>();

        public void Init(Action<Dictionary<FilterType, object>> onFilterSelectedHandler)
        {
            _onFilterSelectedHandler = onFilterSelectedHandler;
            ShowSelf();
        }
        
        public override void ShowSelf()
        {
            OnOrderStatusFilterButtonHandler();
            base.ShowSelf();
        }

        private void OnOrderStatusFilterButtonHandler()
        {
            _currentFilterType = FilterType.OrderStatus;
            _orderStatusFilters.gameObject.SetActive(true);
            _createdDateFilters.gameObject.SetActive(false);
            _orderStatusFilters.Init(selectedItem =>
            {
                _selectedItems.Add(FilterType.OrderStatus, selectedItem.OrderStatusType);
            });
        }

        private void OnCreatedDateFilterButtonHandler()
        {
            _currentFilterType = FilterType.CreatedDate;
            _orderStatusFilters.gameObject.SetActive(false);
            _createdDateFilters.gameObject.SetActive(true);
            _createdDateFilters.Init(selectedItem =>
            {
                _selectedItems.Add(FilterType.CreatedDate, selectedItem.CreatedDateType);
            });
        }

        private void OnApplyFilterClickHandler()
        {
            _onFilterSelectedHandler.Invoke(_selectedItems);
            _createdDateFilters.Clear();
            _orderStatusFilters.Clear();
            Hide();
        }
        
        private void Awake()
        {
            if (ScreensService.FiltersPanel == null)
                ScreensService.FiltersPanel = this;
            
            _orderStatusFilterButton.onClick.AddListener(OnOrderStatusFilterButtonHandler);
            _createdDateFilterButton.onClick.AddListener(OnCreatedDateFilterButtonHandler);
            _applyFilter.onClick.AddListener(OnApplyFilterClickHandler);
        }

        private void Start()
        {
            if (_contentTransform == null)
                _contentTransform = _content.transform;

            _contentTransform.position = _hidePosition.position;
        }
        
        protected override void Update()
        {
            if (_isShowing)
            {
                if(!_content.gameObject.activeSelf)
                    _content.gameObject.SetActive(true);
                if (!_contentTransform.position.Equals(_showPosition.position))
                    _contentTransform.position = Vector3.Lerp(_contentTransform.position, _showPosition.position, _moveSpeed * Time.deltaTime);
            }
            else
            {
                if (!_contentTransform.position.Equals(_hidePosition.position))
                {
                    _contentTransform.position = Vector3.Lerp(_contentTransform.position, _hidePosition.position, _moveSpeed * Time.deltaTime);
                }
                else
                {
                    if(_contentTransform.gameObject.activeSelf)
                        _contentTransform.gameObject.SetActive(false);
                }
            }
        }
    }
}
