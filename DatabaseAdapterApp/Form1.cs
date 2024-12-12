using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAdapterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Додаємо можливості вибору бази даних
            cmbDatabases.Items.Add("");
            cmbDatabases.Items.Add("SQL Server");
            cmbDatabases.Items.Add("MySQL");
            cmbDatabases.SelectedIndex = 0;
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {
            IDatabase database = null;

            // Вибір адаптера залежно від вибору користувача
            if (cmbDatabases.SelectedItem.ToString() == "SQL Server")
            {
                database = new SQLServerAdapter();
            }
            else if (cmbDatabases.SelectedItem.ToString() == "MySQL")
            {
                database = new MySQLAdapter();
            }

            // Підключення та отримання даних
            try
            {
                database.Connect(); // Підключення до бази даних
                string data = database.FetchData(); // Отримання даних
                txtResult.Text = data; // Вивести результат в TextBox
                database.Disconnect(); // Відключення від бази
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Показуємо повідомлення про помилку
            }
        }

    }
}
