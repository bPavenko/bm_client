using System;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class SelectManagerPopup : BaseScreen
    {
        [SerializeField] private GameObject _itemPrefab = default;
        [SerializeField] private Transform _itemParent = default;
        [SerializeField] private Button _cancel = default;

        private Action _onSelectedCallback;
        
        public void Init(Action onSelectedHandler)//TODO: add client model to callback
        {
            LoadManagers();
            ShowSelf();
        }

        private void LoadManagers()
        {
            //TODO: load client from database and instantiate its
        }

        private void Awake()
        {
            if (ScreensService.SelectManagerPopup == null)
                ScreensService.SelectManagerPopup = this;
            
            _cancel.onClick.AddListener(Hide);
        }
    }
}
