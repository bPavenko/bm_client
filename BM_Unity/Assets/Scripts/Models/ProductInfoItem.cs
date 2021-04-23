using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class ProductInfoItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _code = default;
        [SerializeField] private TMP_InputField _description = default;
        [SerializeField] private Button _setNameCode = default;

        public void Init()//TODO: add productData model and init by model fields
        {
            
        }
        
        private void Awake()
        {
            _setNameCode.onClick.AddListener(OnSetNameCodeButtonHandler);
        }

        private void OnSetNameCodeButtonHandler()
        {
            //TODO: show popup with set name and code fields
        }
    }
}
