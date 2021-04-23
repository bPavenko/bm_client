using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Models
{
    public class NoteItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _date = default;
        [SerializeField] private Button _open = default;
        [SerializeField] private GameObject _options = default;
        [SerializeField] private Button _openOptions = default;
        [SerializeField] private Button _delete = default;
        [SerializeField] private Button _hideOptions = default;

        public void Init()//TODO: add note model and init item by model
        {
            
        }
        
        private void Awake()
        {
            _open.onClick.AddListener(OnOpenButtonHandler);
            _openOptions.onClick.AddListener(OnOpenOptionsButtonHandler);
            _delete.onClick.AddListener(OnDeleteButtonHandler);
            _hideOptions.onClick.AddListener(OnHideOptionsButtonHandler);
        }

        private void OnOpenButtonHandler()
        {
            //TODO: open popup with edit field and load note text
        }

        private void OnOpenOptionsButtonHandler()
        {
            _options.SetActive(true);
        }

        private void OnDeleteButtonHandler()
        {
            //TODO: delete note from database, delete item from view and reload notes by ScreensService.NotesPanel.Load();
        }

        private void OnHideOptionsButtonHandler()
        {
            _options.SetActive(false);
        }
    }
}
