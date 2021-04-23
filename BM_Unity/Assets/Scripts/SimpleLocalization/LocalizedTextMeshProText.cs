using TMPro;
using UnityEngine;

namespace Assets.SimpleLocalization {
    
	/// <summary>
	/// Localize text component.
	/// </summary>
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizedTextMeshProText : MonoBehaviour {
        
        [SerializeField] private string _localizationKey = default;

        private TextMeshProUGUI _textComponent;

        private void Start() {
            _textComponent = GetComponent<TextMeshProUGUI>();
            if(_textComponent == null) return;
            Localize();
            LocalizationManager.LocalizationChanged += Localize;
        }

        private void OnEnable() {
            if(_textComponent == null)
                Start();
            else
                Localize();
        }

        private void OnDestroy() {
            LocalizationManager.LocalizationChanged -= Localize;
        }

        private void Localize() {
            if (_textComponent == null) return;
            _textComponent.text = LocalizationManager.Localize(_localizationKey);
        }
    }
}
