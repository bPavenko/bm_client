using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class NoteShowPanel : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _date = default;
        [SerializeField] private Button _editName = default;
        [SerializeField] private TMP_InputField _noteMessage = default;
        [SerializeField] private Button _save = default;

        public void Init()//TODO: init panel by note model
        {
            
        }
        
        private void Awake()
        {
            if (ScreensService.NoteShowPanel == null)
                ScreensService.NoteShowPanel = this;
            
            _editName.onClick.AddListener(OnEditNameButtonHandler);
            _save.onClick.AddListener(OnSaveButtonHandler);
        }

        private void OnEditNameButtonHandler()
        {
            
        }

        private void OnSaveButtonHandler()
        {
            
        }
    }
}
