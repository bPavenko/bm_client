using TMPro;
using UnityEngine;

namespace Common.Models
{
    public class ReportOfDateItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _reportOfDateText = default;
        [SerializeField] private TextMeshProUGUI _reportSumText = default;

        public void Init(string reportOfDateText, string reportSum)
        {
            _reportOfDateText.text = reportOfDateText;
            _reportSumText.text = reportSum;
        }
    }
}
