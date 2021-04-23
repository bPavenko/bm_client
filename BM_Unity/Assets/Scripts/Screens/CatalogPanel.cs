using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class CatalogPanel : BaseScreen
    {
        [SerializeField] private TMP_InputField _searchField = default;
        [SerializeField] private GameObject _addOptionsItem = default;
        [SerializeField] private Button _addCategory = default;
        [SerializeField] private Button _addProduct = default;
        [SerializeField] private GameObject _categoryItemPrefab = default;
        [SerializeField] private GameObject _productItemPrefab = default;
        [SerializeField] private Button _basket = default;
        [SerializeField] private GameObject _countBar = default;
        [SerializeField] private TextMeshProUGUI _basketProductsCount = default;

        private void Awake()
        {
            if (ScreensService.CatalogPanel == null)
                ScreensService.CatalogPanel = this;
        }
    }
}
