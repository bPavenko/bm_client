using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class CashiersPanel : BaseScreen
    {
        [SerializeField] private GameObject _itemPrefab = default;
        [SerializeField] private Transform _itemsParent = default;
        [SerializeField] private Button _add = default;

        public void Init()//TODO: load cashiers items by database model
        {
            
        }
        
        private void Awake()
        {
            if (ScreensService.CashiersPanel == null)
                ScreensService.CashiersPanel = this;
            
            _add.onClick.AddListener(OnAddButtonHandler);
        }

        private void OnAddButtonHandler()
        {
            
        }
    }
}
