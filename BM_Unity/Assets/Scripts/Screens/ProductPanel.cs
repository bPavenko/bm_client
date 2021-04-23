using Common;
using Common.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class ProductPanel : BaseScreen
    {
        [SerializeField] private Button _menu = default;
        [SerializeField] private Button _save = default;
        [SerializeField] private Image _productPhoto = default;
        [SerializeField] private Button _setPhoto = default;
        [SerializeField] private ProductInfoItem _productInfo = default;
        [SerializeField] private Button _addCharacteristic = default;
        [SerializeField] private Transform _characteristicsParent = default;
        [SerializeField] private GameObject _characteristicPrefab = default;
        [SerializeField] private CharacteristicItem _warehouseCharacteristic = default;

        public void Init()//TODO: init product info by product data model with characteristics
        {
            
        }
        
        private void Awake()
        {
            if (ScreensService.ProductPanel == null)
                ScreensService.ProductPanel = this;
            
            _menu.onClick.AddListener(OnMenuButtonHandler);
            _save.onClick.AddListener(OnSaveButtonHandler);
            _setPhoto.onClick.AddListener(OnSetPhotoButtonHandler);
            _addCharacteristic.onClick.AddListener(OnAddCharacteristicButtonHandler);
        }

        private void OnMenuButtonHandler()
        {
            ScreensService.MenuPanel.ShowSelf();
        }

        private void OnSaveButtonHandler()
        {
            
        }

        private void OnSetPhotoButtonHandler()
        {
            
        }

        private void OnAddCharacteristicButtonHandler()
        {
            
        }
    }
}
