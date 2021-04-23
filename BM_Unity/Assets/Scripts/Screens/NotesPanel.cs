using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class NotesPanel : BaseScreen
    {
        [SerializeField] private TMP_InputField _search = default;
        [SerializeField] private Button _addNote = default;
        [SerializeField] private GameObject _noteItemPrefab = default;
        [SerializeField] private Transform _noteItemsParent = default;

        public void Load()//TODO: load notes from database
        {
            Reset();
            //TODO: load here
            ShowSelf();
        }

        public void Load(string searchValue)
        {
            //TODO: load here with check by searchValue
            ShowSelf();
        }

        private void Awake()
        {
            if (ScreensService.NotesPanel == null)
                ScreensService.NotesPanel = this;
            
            _search.onEndEdit.AddListener(OnSearchFieldEditFinishedHandler);
            _addNote.onClick.AddListener(OnAddNoteButtonHandler);
        }

        private void OnSearchFieldEditFinishedHandler(string value)
        {
            Load(value);
        }

        private void OnAddNoteButtonHandler()
        {
            //TODO: show clean popup with text field and after add new note call Load();
        }

        private void Reset()
        {
            _search.text = string.Empty;
        }
    }
}
