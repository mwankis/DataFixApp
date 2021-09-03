using System.Windows.Forms;

namespace MainApplication.Helpers
{
    public static class GeneralHelper
    {
        public static void LogStatus(ListBox listBox, string message, string statusCount = null)
        {
            if (string.IsNullOrEmpty(statusCount))
            {
              listBox.Items.Add($"{statusCount} .....................................");
            }
            listBox.Items.Add(message);
            listBox.Items.Add("_____________________________________________________________________________________________________________________________________________________________");
        }
    }
}
