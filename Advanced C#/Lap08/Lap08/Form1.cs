namespace Lap08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            double value;
            if (!double.TryParse(txtValue.Text, out value))
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }
            double result = 0;

            if (MeterToKilometer.Checked)
            {
                result = value / 1000.0;
            }
            else if (MeterToMile.Checked)
            {
                result = value / 1609.34;
            }
            else if (MileToMeter.Checked)
            {
                result = value * 1609.34;
            }
            txtResult.Text = result.ToString();
        }
    }
}
