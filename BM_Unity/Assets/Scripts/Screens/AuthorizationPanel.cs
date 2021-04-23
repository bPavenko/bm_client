using Common;
using Common.Models;
using Server;
using Server.Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AuthorizationPanel : BaseScreen
    {
        [SerializeField] private TMP_InputField _login = default;
        [SerializeField] private TMP_InputField _password = default;
        [SerializeField] private Button _signInButton = default;
        [SerializeField] private Button _backButton = default;

        private void Awake()
        {
            if (ScreensService.AuthorizationPanel == null)
                ScreensService.AuthorizationPanel = this;
            _signInButton.onClick.AddListener(OnAuthButtonHandler);
            _backButton.onClick.AddListener(Back);
        }

        protected override void Back()
        {
            base.Back();
            Clear();
        }

        private void OnAuthButtonHandler()
        {
            if (FieldsIsValid())
            {
                ServerConnectorService.AuthController.Auth(_login.text, _password.text, response =>
                {
                    switch (response.Status)
                    {
                        case AuthController.AuthStatus.Success:
                            Clear();
                            Core.Instance.CurrentUser = response.Data;
                            EventsService.OnAuthorizationSuccess.Invoke();
                            break;
                        case AuthController.AuthStatus.UnknownLogin:
                            var unknownLogin = new PopupData
                            {
                                Title = LocalizationService.AttentionText,
                                Message = LocalizationService.UnknownLogin,
                                PositiveAction = _login.Select
                            };
                            ScreensService.PopupPanel.Init(unknownLogin);
                            break;
                        case AuthController.AuthStatus.InvalidPassword:
                            var invalidPassword = new PopupData
                            {
                                Title = LocalizationService.AttentionText,
                                Message = LocalizationService.InvalidPassword,
                                PositiveAction = _password.Select
                            };
                            ScreensService.PopupPanel.Init(invalidPassword);
                            break;
                        case AuthController.AuthStatus.InvalidOrganizationIp:
                            var invalidOrgIp = new PopupData
                            {
                                Title = LocalizationService.AttentionText,
                                Message = LocalizationService.InvalidPassword,
                                PositiveAction = Back
                            };
                            ScreensService.PopupPanel.Init(invalidOrgIp);
                            break;
                        case AuthController.AuthStatus.UnknownError:
                            var unknownError = new PopupData
                            {
                                Title = LocalizationService.AttentionText,
                                Message = LocalizationService.UnknownError
                            };
                            ScreensService.PopupPanel.Init(unknownError);
                            break;
                    }
                });
            }
        }

        private void Clear()
        {
            _login.text = string.Empty;
            _password.text = string.Empty;
        }

        private bool FieldsIsValid()
        {
            if (string.IsNullOrEmpty(_login.text))
            {
                _login.Select();
                return false;
            }
            if (string.IsNullOrEmpty(_password.text))
            {
                _password.Select();
                return false;
            }
            return true;
        }
    }
}
