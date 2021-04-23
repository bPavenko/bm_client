using System.Collections.Generic;
using Common;
using Common.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class SelectOrganizationPanel : BaseScreen
    {
        [SerializeField] private TMP_Dropdown _organizations = default;
        [SerializeField] private Button _selectButton = default;
        [SerializeField] private Button _removeSelectedOrganization = default;
        [SerializeField] private Button _addOrganizationButton = default;

        private List<OrganizationItem> _loadedOrganizations;
        
        public override void Init()
        {
            _organizations.value = 0;
            _organizations.options.Clear();
            _loadedOrganizations = LocalDataBaseService.Organizations;
            if(_loadedOrganizations.Count == 0)
                _organizations.AddOptions(new List<string>{LocalizationService.NoCompany});
            _organizations.interactable = _loadedOrganizations.Count != 0;
            _removeSelectedOrganization.interactable = _loadedOrganizations.Count != 0;
            _selectButton.interactable = _loadedOrganizations.Count != 0;
            foreach (var org in _loadedOrganizations)
                _organizations.AddOptions(new List<string>{org.Name});
        }

        private void Awake()
        {
            if (ScreensService.SelectOrganizationPanel == null)
                ScreensService.SelectOrganizationPanel = this;
            _selectButton.onClick.AddListener(OnSelectButtonHandler);
            _addOrganizationButton.onClick.AddListener(OnAddOrganizationButtonHandler);
            _removeSelectedOrganization.onClick.AddListener(OnRemoveSelectedOrganizationButtonHandler);
            EventsService.OnScreensServiceInitialized += OnScreensServiceInitializedHandler;
            EventsService.OnLocalDataBaseUpdated += Init;
            EventsService.OnLogout += Init;
        }

        private void OnScreensServiceInitializedHandler()
        {
            ScreensService.SelectOrganizationPanel = this;
        }

        private void OnSelectButtonHandler()
        {
            Core.Instance.SelectedOrganization = _loadedOrganizations[_organizations.value];
            ScreensService.AuthorizationPanel.Show(this, this);
        }

        private void OnRemoveSelectedOrganizationButtonHandler()
        {
            if(_loadedOrganizations.Count == 0) return;
            LocalDataBaseService.RemoveOrganization(_loadedOrganizations[_organizations.value].Code);
        }

        private void OnAddOrganizationButtonHandler()
        {
            ScreensService.AddOrganizationPanel.Show(this, this);
        }
    }
}
