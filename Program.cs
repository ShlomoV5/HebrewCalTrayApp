using System;
using System.Drawing;
using System.Windows.Forms;

namespace HebrewCalendarTrayApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Icon = new Icon("hebrew_day_icon.ico");
            trayIcon.Text = "Loading...";

            ContextMenu trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("📅 לוח עברי", ShowHebrewCalendarPopup);

            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            UpdateTrayIcon(trayIcon);

            Application.Run();
        }

        static async void UpdateTrayIcon(NotifyIcon trayIcon)
        {
            var hebrewDate = await HebcalApi.GetHebrewDate(DateTime.Now);
            trayIcon.Text = hebrewDate.FullDate;
            trayIcon.Icon = CreateIconWithText(hebrewDate.DayNumber);
        }

        static Icon CreateIconWithText(string text)
        {
            Bitmap bitmap = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
                using (Font font = new Font("Arial", 8, FontStyle.Bold))
                {
                    g.DrawString(text, font, Brushes.Black, new PointF(0, 0));
                }
            }
            return Icon.FromHandle(bitmap.GetHicon());
        }

        static void ShowHebrewCalendarPopup(object sender, EventArgs e)
        {
            HebrewCalendarPopup popup = new HebrewCalendarPopup();
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(Cursor.Position.X - popup.Width / 2, Cursor.Position.Y - popup.Height);
            popup.ShowDialog();
        }
    }
}
