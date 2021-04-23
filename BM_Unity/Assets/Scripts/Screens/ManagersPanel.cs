using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class ManagersPanel : BaseScreen
    {
        [SerializeField] private GameObject _itemPrefab = default;
        [SerializeField] private Transform _itemsParent = default;
        [SerializeField] private Button _add = default;

        public void Init()//TODO: load managers items by database model
        {
            
        }
        
        private void Awake()
        {
            if (ScreensService.ManagersPanel == null)
                ScreensService.ManagersPanel = this;
            
            _add.onClick.AddListener(OnAddButtonHandler);
        }

        private void OnAddButtonHandler()
        {
            
        }
    }
}
