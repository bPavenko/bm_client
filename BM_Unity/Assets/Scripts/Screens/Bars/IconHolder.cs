using UnityEngine;

namespace Screens.Bars
{
    public class IconHolder : MonoBehaviour
    {
        [SerializeField] private GameObject _unit = default;
        [SerializeField] private GameObject _remainder = default;
        [SerializeField] private GameObject _weight = default;
        [SerializeField] private GameObject _price = default;
        [SerializeField] private GameObject _warehouse = default;
        [SerializeField] private GameObject _def = default;

        public void Init(Icon icon)
        {
            _unit.SetActive(icon == Icon.unit);
            _remainder.SetActive(icon == Icon.remainder);
            _weight.SetActive(icon == Icon.weight);
            _price.SetActive(icon == Icon.price);
            _warehouse.SetActive(icon == Icon.warehouse);
            _def.SetActive(icon == Icon.def);
        }

        private void Awake()
        {
            Init(Icon.def);
        }

        public enum Icon
        {
            unit,
            remainder,
            weight,
            price,
            warehouse,
            def
        }
    }
}
