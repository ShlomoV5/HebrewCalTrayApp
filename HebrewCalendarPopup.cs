using System;
using System.Drawing;
using System.Windows.Forms;

namespace HebrewCalendarTrayApp
{
    public class HebrewCalendarPopup : Form
    {
        private Label titleLabel;
        private TableLayoutPanel calendarTable;
        private Button okButton;
        private Button prevMonthButton;
        private Button nextMonthButton;

        public HebrewCalendarPopup()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.titleLabel = new Label();
            this.calendarTable = new TableLayoutPanel();
            this.okButton = new Button();
            this.prevMonthButton = new Button();
            this.nextMonthButton = new Button();

            // 
            // titleLabel
            // 
            this.titleLabel.Dock = DockStyle.Top;
            this.titleLabel.Font = new Font("Arial", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.titleLabel.Text = "ניסן תשפ״ה"; // Example text, should be dynamically set

            // 
            // calendarTable
            // 
            this.calendarTable.ColumnCount = 7;
            this.calendarTable.RowCount = 6;
            this.calendarTable.Dock = DockStyle.Fill;
            this.calendarTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            for (int i = 0; i < 7; i++)
            {
                this.calendarTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.28F));
            }
            for (int i = 0; i < 6; i++)
            {
                this.calendarTable.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
            }

            // Add day labels (א–ש)
            string[] dayLabels = { "א", "ב", "ג", "ד", "ה", "ו", "ש" };
            for (int i = 0; i < 7; i++)
            {
                Label dayLabel = new Label();
                dayLabel.Text = dayLabels[i];
                dayLabel.TextAlign = ContentAlignment.MiddleCenter;
                this.calendarTable.Controls.Add(dayLabel, i, 0);
            }

            // Add day numbers (example data, should be dynamically set)
            for (int row = 1; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Label dayNumberLabel = new Label();
                    dayNumberLabel.Text = "א"; // Example text, should be dynamically set
                    dayNumberLabel.TextAlign = ContentAlignment.MiddleCenter;
                    dayNumberLabel.ForeColor = Color.Black; // Example color, should be dynamically set
                    this.calendarTable.Controls.Add(dayNumberLabel, col, row);
                }
            }

            // 
            // okButton
            // 
            this.okButton.Dock = DockStyle.Bottom;
            this.okButton.Text = "אישור";
            this.okButton.Click += new EventHandler(this.OkButton_Click);

            // 
            // prevMonthButton
            // 
            this.prevMonthButton.Dock = DockStyle.Left;
            this.prevMonthButton.Text = "←";
            this.prevMonthButton.Click += new EventHandler(this.PrevMonthButton_Click);

            // 
            // nextMonthButton
            // 
            this.nextMonthButton.Dock = DockStyle.Right;
            this.nextMonthButton.Text = "→";
            this.nextMonthButton.Click += new EventHandler(this.NextMonthButton_Click);

            // 
            // HebrewCalendarPopup
            // 
            this.ClientSize = new Size(400, 300);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.calendarTable);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.prevMonthButton);
            this.Controls.Add(this.nextMonthButton);
            this.Text = "לוח עברי";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrevMonthButton_Click(object sender, EventArgs e)
        {
            // Logic to show the previous Hebrew month
        }

        private void NextMonthButton_Click(object sender, EventArgs e)
        {
            // Logic to show the next Hebrew month
        }
    }
}
