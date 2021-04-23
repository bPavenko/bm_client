using System.Collections.Generic;
using Common;
using Common.Models;
using Server;
using Server.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class OrdersPanel : BaseScreen
    {
        [SerializeField] private TMP_InputField _searchField = default;
        [SerializeField] private Button _filter = default;
        [SerializeField] private ReportOfDateItem _reportItem = default;
        [SerializeField] private GameObject _orderPrefab = default;
        [SerializeField] private Transform _ordersParent = default;

        private List<GameObject> _loaded = new List<GameObject>();
        
        private void Init()
        {
            if (Core.Instance.CurrentUser.Role == UserRoles.Manager ||
                Core.Instance.CurrentUser.Role == UserRoles.Director)
            {
                _reportItem.gameObject.SetActive(true);
                ServerConnectorService.OrdersController.GetReportByCurrentMonth(response =>
                {
                    _reportItem.Init("(тест) Выручка за январь", response.ToString());
                });
            }
            ServerConnectorService.OrdersController.GetOrders(response =>
            {
                Load(response.Data);
            });
        }

        private void Load(List<OrderData> data)
        {
            Clear();
            data.ForEach(item =>
            {
                var obj = Instantiate(_orderPrefab, _ordersParent);
                var orderItem = obj.GetComponent<OrderItem>();
                orderItem.Init(item);
                obj.SetActive(true);
                _loaded.Add(obj);
            });
        }

        private void Clear()
        {
            _loaded.ForEach(Destroy);
        }

        private void Awake()
        {
            if (ScreensService.OrdersPanel == null)
                ScreensService.OrdersPanel = this;
            EventsService.OnAuthorizationSuccess += OnAuthorizationSuccessHandler;
            _filter.onClick.AddListener(OnFilterClickHandler);
            _searchField.onEndEdit.AddListener(OnSearchFieldFilledHandler);
        }

        private void OnSearchFieldFilledHandler(string value)
        {
            //TODO: filter loaded orders by name
        }

        private void OnFilterClickHandler()
        {
            ScreensService.FiltersPanel.Init(selectedItems =>
            {
                foreach (var item in selectedItems)
                {
                    switch (item.Key)
                    {
                        case FilterType.CreatedDate:
                            var createdDateType = (CreatedDateType) item.Value;
                            //TODO: filter by createdDateType
                            break;
                        case FilterType.OrderStatus:
                            var orderStatusType = (OrderStatusType) item.Value;
                            //TODO: filter by orderStatusType
                            break;
                    }
                }
            });
        }

        private void OnAuthorizationSuccessHandler()
        {
            Init();
        }
    }
}
