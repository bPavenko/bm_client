using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class SelectClientItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _phoneNumber = default;
        [SerializeField] private TextMeshProUGUI _email = default;
        [SerializeField] private TextMeshProUGUI _discount = default;
        [SerializeField] private Button _select = default;

        private Action _onSelectedCallback;
        
        public void Init(Action onSelectedHandler)//TODO: add client model to init and to callback
        {
            _onSelectedCallback = onSelectedHandler;
        }

        private void Awake()
        {
            _select.onClick.AddListener(OnSelectButtonHandler);
        }

        private void OnSelectButtonHandler()
        {
            _onSelectedCallback.Invoke();//TODO: add model to callback
        }
    }
}
