using System;

namespace Common.Models
{
    public class PopupData
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string PositiveText { get; set; }
        public Action PositiveAction { get; set; }
        public string NegativeText { get; set; }
        public Action NegativeAction { get; set; }

        public PopupData()
        {
            if (string.IsNullOrEmpty(NegativeText))
                NegativeText = LocalizationService.NegativePopupText;
            if (string.IsNullOrEmpty(PositiveText))
                PositiveText = LocalizationService.PositivePopupText;
        }
    }
}
