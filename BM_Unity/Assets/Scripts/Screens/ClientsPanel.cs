using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class ClientsPanel : BaseScreen
    {
        [SerializeField] private GameObject _clientItemPrefab = default;
        [SerializeField] private Transform _clientItemsParent = default;
        [SerializeField] private Button _addClient = default;
        [SerializeField] private Button _filter = default;

        public void Init()//TODO: load clients items by database model
        {
            
        }
        
        private void Awake()
        {
            if (ScreensService.ClientsPanel == null)
                ScreensService.ClientsPanel = this;
            
            _addClient.onClick.AddListener(OnAddClientButtonHandler);
            _filter.onClick.AddListener(OnFilterButtonHandler);
        }

        private void OnAddClientButtonHandler()
        {
            
        }

        private void OnFilterButtonHandler()
        {
            //TODO: show popup with managers list and filtering loaded items list
        }
    }
}
