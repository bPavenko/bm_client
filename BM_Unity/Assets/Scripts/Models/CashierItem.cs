﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class CashierItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _phoneNumber = default;
        [SerializeField] private Button _options = default;
        [SerializeField] private Button _hideOptions = default;
        [SerializeField] private GameObject _optionsBar = default;
        [SerializeField] private Button _editOption = default;
        [SerializeField] private Button _deleteOption = default;

        public void Init()//TODO: init item by cashier model
        {
            
        }
    }
}