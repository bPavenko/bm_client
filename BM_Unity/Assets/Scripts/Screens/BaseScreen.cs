using System;
using UnityEngine;

namespace Screens
{
    public class BaseScreen : MonoBehaviour
    {
        public Action OnScreenShow { get; set; }
        
        [SerializeField] protected CanvasGroup _content = default;

        protected bool _isShowing = false;
        private BaseScreen _backScreen;

        public virtual void Init() { } 
        
        public virtual void ShowSelf()
        {
            OnScreenShow?.Invoke();
            _isShowing = true;
        }

        public void Show(BaseScreen screenToHide, BaseScreen backScreen = null)
        {
            if(backScreen != null)
                _backScreen = backScreen;
            screenToHide.Hide();
            ShowSelf();
        }

        public void Hide()
        {
            _isShowing = false;
        }

        protected virtual void Back()
        {
            if(_backScreen == null) return;
            _backScreen.Show(this);
        }

        protected virtual void Update()
        {
            if (_isShowing)
            {
                if(!_content.gameObject.activeSelf)
                    _content.gameObject.SetActive(true);
                if (_content.alpha < 1f){
                    _content.alpha += 4f * Time.deltaTime;
                }
            }
            else
            {
                if (_content.alpha > 0f)
                {
                    _content.alpha -= 4f * Time.deltaTime;
                    if(_content.alpha <= 0f)
                        _content.gameObject.SetActive(false);
                }
            }
        }
    }
}