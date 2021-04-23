using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class StorekeepersPanel : BaseScreen
    {
        [SerializeField] private GameObject _itemPrefab = default;
        [SerializeField] private Transform _itemsParent = default;
        [SerializeField] private Button _add = default;

        public void Init()//TODO: load storekeepers items by database model
        {
            
        }
        
        private void Awake()
        {
            if (ScreensService.StorekeepersPanel == null)
                ScreensService.StorekeepersPanel = this;
            
            _add.onClick.AddListener(OnAddButtonHandler);
        }

        private void OnAddButtonHandler()
        {
            
        }
    }
}
