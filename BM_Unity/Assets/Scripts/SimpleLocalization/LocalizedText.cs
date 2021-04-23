using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization {
    
	/// <summary>
	/// Localize text component.
	/// </summary>
    [RequireComponent(typeof(Text))]
    public class LocalizedText : MonoBehaviour {
        
        [SerializeField] private string _localizationKey = default;

        private Text _textComponent;

        private void Start() {
            _textComponent = GetComponent<Text>();
            Localize();
            LocalizationManager.LocalizationChanged += Localize;
        }

        private void OnEnable() {
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
