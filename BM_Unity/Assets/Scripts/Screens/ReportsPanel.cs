using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class ReportsPanel : BaseScreen
    {
        [SerializeField] private Button _reportByDatabase = default;
        [SerializeField] private Button _reportByUser = default;
        [SerializeField] private Button _reportCommon = default;

        private void Awake()
        {
            if (ScreensService.ReportsPanel == null)
                ScreensService.ReportsPanel = this;
            
            _reportByDatabase.onClick.AddListener(OnReportByDatabaseButtonHandler);
            _reportByUser.onClick.AddListener(OnReportByUserButtonHandler);
            _reportCommon.onClick.AddListener(OnReportCommonButtonHandler);
        }

        private void OnReportByDatabaseButtonHandler()
        {
            
        }

        private void OnReportByUserButtonHandler()
        {
            
        }

        private void OnReportCommonButtonHandler()
        {
            
        }
    }
}
