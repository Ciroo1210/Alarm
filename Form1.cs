using System;
using System.Windows.Forms;
using System.Media;

namespace Alarma
{
    public partial class Form1 : Form
    {
        private string selectItemH;
        private string selectItemM;
        private bool alarmActivated;

        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectItemH = comboBox1.SelectedItem?.ToString();
            ActivateAlarm();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectItemM = comboBox2.SelectedItem?.ToString();
            ActivateAlarm();
        }

        private void ActivateAlarm()
        {
            DateTime currentTime = DateTime.Now;

            if (!string.IsNullOrEmpty(selectItemH) && !string.IsNullOrEmpty(selectItemM))
            {
                string selectedTime = selectItemH + ":" + selectItemM;
                string currentTimeSTR = currentTime.ToString("HH:mm");

                if (selectedTime == currentTimeSTR && !alarmActivated)
                {
                    alarmActivated = true;

                    try
                    {
                        SoundPlayer player = new SoundPlayer();
                        player.SoundLocation = @"C:\Users\users\Downloads\sound-effect-for-editing.wav";
                        player.Play();

                        Form2 form2 = new Form2();
                        form2.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error playing the sound: {ex.Message}");
                    }
                }
                else if (selectedTime != currentTimeSTR)
                {
                    alarmActivated = false;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
