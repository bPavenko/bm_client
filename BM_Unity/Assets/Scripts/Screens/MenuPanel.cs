using Common;
using Server.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class MenuPanel : BaseScreen
    {
        [Header("Panel settings:")]
        [SerializeField] private RectTransform _showPosition = default;
        [SerializeField] private RectTransform _hidePosition = default;
        [SerializeField] private float _moveSpeed = default;
        
        [Header("Common:")]
        [SerializeField] private Toggle _accountToggle = default;
        [SerializeField] private Toggle _ordersToggle = default;
        [SerializeField] private Toggle _catalogToggle = default;
        [SerializeField] private Toggle _reportsToggle = default;
        [SerializeField] private Toggle _databaseToggle = default;
        [SerializeField] private Toggle _notesToggle = default;
        [SerializeField] private Toggle _managersToggle = default;
        [SerializeField] private Toggle _storekeepersToggle = default;
        [SerializeField] private Toggle _cashiersToggle = default;

        private BaseScreen _currentScreen;
        private Transform _contentTransform;
        
        private void Awake()
        {
            if (ScreensService.MenuPanel == null)
                ScreensService.MenuPanel = this;
            EventsService.OnAuthorizationSuccess += OnAuthorizationSuccessHandler;
            _accountToggle.onValueChanged.AddListener(OnAccountToggleHandler);
            _ordersToggle.onValueChanged.AddListener(OnOrdersToggleHandler);
            _catalogToggle.onValueChanged.AddListener(OnCatalogToggleHandler);
            _reportsToggle.onValueChanged.AddListener(OnReportsToggleHandler);
            _databaseToggle.onValueChanged.AddListener(OnDatabaseToggleHandler);
            _notesToggle.onValueChanged.AddListener(OnNotesToggleHandler);
            _managersToggle.onValueChanged.AddListener(OnManagersToggleHandler);
            _storekeepersToggle.onValueChanged.AddListener(OnStorekeepersToggleHandler);
            _cashiersToggle.onValueChanged.AddListener(OnCashiersToggleHandler);
        }
        
        private void OnAccountToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            if (_currentScreen != ScreensService.AccountPanel)
            {
                _currentScreen = ScreensService.AccountPanel;
                _currentScreen.Show(this);
            }
            Hide();
        }

        private void OnOrdersToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.OrdersPanel;
            _currentScreen.Show(this);
        }

        private void OnCatalogToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.CatalogPanel;
            _currentScreen.Show(this);
        }

        private void OnReportsToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.ReportsPanel;
            _currentScreen.Show(this);
        }

        private void OnDatabaseToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.ClientsPanel;
            _currentScreen.Show(this);
        }

        private void OnNotesToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.NotesPanel;
            _currentScreen.Show(this);
        }

        private void OnManagersToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.ManagersPanel;
            _currentScreen.Show(this);
        }

        private void OnStorekeepersToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.StorekeepersPanel;
            _currentScreen.Show(this);
        }

        private void OnCashiersToggleHandler(bool value)
        {
            if (!value) return;
            HideCurrentScreen();
            _currentScreen = ScreensService.CashiersPanel;
            _currentScreen.Show(this);
        }

        private void HideCurrentScreen()
        {
            if(_currentScreen == null) return;
            _currentScreen.Hide();
        }

        private void OnAuthorizationSuccessHandler()
        {
            _currentScreen = ScreensService.AccountPanel;
            switch (Core.Instance.CurrentUser.Role)
            {
                case UserRoles.Director:
                    _ordersToggle.gameObject.SetActive(true);
                    _catalogToggle.gameObject.SetActive(true);
                    _reportsToggle.gameObject.SetActive(true);
                    _databaseToggle.gameObject.SetActive(true);
                    _notesToggle.gameObject.SetActive(false);
                    _managersToggle.gameObject.SetActive(true);
                    _storekeepersToggle.gameObject.SetActive(true);
                    _cashiersToggle.gameObject.SetActive(true);
                    break;
                case UserRoles.Manager:
                    _ordersToggle.gameObject.SetActive(true);
                    _catalogToggle.gameObject.SetActive(true);
                    _reportsToggle.gameObject.SetActive(false);
                    _databaseToggle.gameObject.SetActive(true);
                    _notesToggle.gameObject.SetActive(true);
                    _managersToggle.gameObject.SetActive(false);
                    _storekeepersToggle.gameObject.SetActive(false);
                    _cashiersToggle.gameObject.SetActive(false);
                    break;
                case UserRoles.Storekeeper:
                    _ordersToggle.gameObject.SetActive(true);
                    _catalogToggle.gameObject.SetActive(true);
                    _reportsToggle.gameObject.SetActive(false);
                    _databaseToggle.gameObject.SetActive(false);
                    _notesToggle.gameObject.SetActive(false);
                    _managersToggle.gameObject.SetActive(false);
                    _storekeepersToggle.gameObject.SetActive(false);
                    _cashiersToggle.gameObject.SetActive(false);
                    break;
                case UserRoles.Cashier:
                    _ordersToggle.gameObject.SetActive(true);
                    _catalogToggle.gameObject.SetActive(false);
                    _reportsToggle.gameObject.SetActive(false);
                    _databaseToggle.gameObject.SetActive(true);
                    _notesToggle.gameObject.SetActive(true);
                    _managersToggle.gameObject.SetActive(false);
                    _storekeepersToggle.gameObject.SetActive(false);
                    _cashiersToggle.gameObject.SetActive(false);
                    break;
            }
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
