using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class ProductItem : MonoBehaviour
    {
        [SerializeField] private Image _avatar = default;
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _price = default;
        [SerializeField] private Button _showOptions = default;
        [SerializeField] private Button _hideOptions = default;
        [SerializeField] private GameObject _optionsBar = default;
        [SerializeField] private Button _setCount = default;
        [SerializeField] private Button _addToBasket = default;
        [SerializeField] private Button _delete = default;

        public void Init()//TODO: init by product data model
        {
            
        }

        private void Awake()
        {
            _showOptions.onClick.AddListener(OnShowOptionsButtonHandler);
            _hideOptions.onClick.AddListener(OnHideOptionsButtonHandler);
            _setCount.onClick.AddListener(OnSetCountButtonHandler);
            _addToBasket.onClick.AddListener(OnAddToBasketButtonHandler);
            _delete.onClick.AddListener(OnDeleteButtonHandler);
        }

        private void OnShowOptionsButtonHandler()
        {
            _optionsBar.SetActive(true);
        }

        private void OnHideOptionsButtonHandler()
        {
            _optionsBar.SetActive(false);
        }

        private void OnSetCountButtonHandler()
        {
            
        }

        private void OnAddToBasketButtonHandler()
        {
            
        }

        private void OnDeleteButtonHandler()
        {
            
        }
    }
}
