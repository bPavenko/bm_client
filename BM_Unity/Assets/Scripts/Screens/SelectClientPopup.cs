using System;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class SelectClientPopup : BaseScreen
    {
        [SerializeField] private GameObject _itemPrefab = default;
        [SerializeField] private Transform _itemParent = default;
        [SerializeField] private Button _cancel = default;

        private Action _onSelectedCallback;
        
        public void Init(Action onSelectedHandler)//TODO: add client model to callback
        {
            LoadClients();
            ShowSelf();
        }

        private void LoadClients()
        {
            //TODO: load client from database and instantiate its
        }

        private void Awake()
        {
            if (ScreensService.SelectClientPopup == null)
                ScreensService.SelectClientPopup = this;
            
            _cancel.onClick.AddListener(Hide);
        }
    }
}
