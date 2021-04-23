using TMPro;
using UnityEngine;

namespace Common.Models
{
    public class ClientItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _phoneNumber = default;
        [SerializeField] private TextMeshProUGUI _email = default;
        [SerializeField] private TextMeshProUGUI _manager = default;
        [SerializeField] private TextMeshProUGUI _discount = default;

        public void Init()//TODO: init item by client model
        {
            
        }
    }
}
