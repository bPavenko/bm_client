using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class CategoryItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private GameObject _selectedBg = default;
        [SerializeField] private Button _selectCategory = default;
        [SerializeField] private GameObject _deselectCategoryButton = default;
        [SerializeField] private Button _deselectCategory = default;

        public void Init()//TODO: init by product items category filter from all products list
        {
            SetSelectedState(false);
        }

        private void Awake()
        {
            _selectCategory.onClick.AddListener(OnSelectCategoryButtonHandler);
            _deselectCategory.onClick.AddListener(OnDeselectCategoryButtonHandler);
        }

        private void OnSelectCategoryButtonHandler()
        {
            SetSelectedState(true);
        }

        private void OnDeselectCategoryButtonHandler()
        {
            SetSelectedState(false);
        }

        private void SetSelectedState(bool selected)
        {
            _deselectCategoryButton.SetActive(selected);
            _selectedBg.SetActive(selected);
        }
    }
}
