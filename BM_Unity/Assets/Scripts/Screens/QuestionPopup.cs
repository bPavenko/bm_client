using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class QuestionPopup : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI _question = default;
        [SerializeField] private TextMeshProUGUI _firstAnswer = default;
        [SerializeField] private TextMeshProUGUI _secondAnswer = default;
        [SerializeField] private Button _firstAnswerButton = default;
        [SerializeField] private Button _secondAnswerButton = default;

        public void ShowQuestion(string question, 
            string firstAnswer, Action firstAnswerCallback, 
            string secondAnswer, Action secondAnswerCallback)
        {
            _question.text = question;
            _firstAnswer.text = firstAnswer;
            _firstAnswerButton.onClick.RemoveAllListeners();
            _firstAnswerButton.onClick.AddListener(() =>
            {
                Hide();
                firstAnswerCallback.Invoke();
            });
            _secondAnswer.text = secondAnswer;
            _secondAnswerButton.onClick.RemoveAllListeners();
            _secondAnswerButton.onClick.AddListener(() =>
            {
                Hide();
                secondAnswerCallback.Invoke();
            });
            ShowSelf();
        }

        private void Awake()
        {
            if (ScreensService.QuestionPopup == null)
                ScreensService.QuestionPopup = this;
        }
    }
}
