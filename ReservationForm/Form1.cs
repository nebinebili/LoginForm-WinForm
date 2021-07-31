using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ReservInfo reservInfo=new ReservInfo();

        

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(mTB_name.Text)|| string.IsNullOrEmpty(mTB_surname.Text)||
                string.IsNullOrEmpty(mTB_phone.Text) || string.IsNullOrEmpty(mTB_city.Text)||
                string.IsNullOrEmpty(mTB_address.Text) || string.IsNullOrEmpty(mTB_adult.Text)||
                string.IsNullOrEmpty(mTB_under3.Text) || string.IsNullOrEmpty(mTB_under6.Text)||
                string.IsNullOrEmpty(mTB_ZIPcode.Text) || string.IsNullOrEmpty(mTB_email.Text)
                )MessageBox.Show("Please fill in all the information");
            reservInfo.Name = mTB_name.Text;
            reservInfo.Surname = mTB_surname.Text;
            reservInfo.Email = mTB_email.Text;
            reservInfo.Phone = mTB_phone.Text;
            reservInfo.Zip_code = mTB_ZIPcode.Text;
            reservInfo.Address = mTB_address.Text;
            reservInfo.City = mTB_city.Text;
            reservInfo.ArrivialDate = dT_arrivial.Value;
            reservInfo.EndOfStay = dT_endstay.Value;
            reservInfo.Adults = Convert.ToInt32(mTB_adult.Text);
            reservInfo.KidsUnderOf_3Years = Convert.ToInt32(mTB_under3.Text);
            reservInfo.KidsUnderOf_6Years = Convert.ToInt32(mTB_under6.Text);
            reservInfo.Payment = Convert.ToString(combBox_payment.SelectedItem);

            if (radioButton1.Checked) reservInfo.TypeOfRoom = radioButton1.Text;
            else if (radioButton2.Checked) reservInfo.TypeOfRoom = radioButton2.Text;
            else if (radioButton3.Checked) reservInfo.TypeOfRoom = radioButton3.Text;
            else MessageBox.Show("Type of room not selected");
            if (radioButton4.Checked) reservInfo.TypeOfFood = radioButton4.Text;
            else if (radioButton5.Checked) reservInfo.TypeOfFood = radioButton5.Text;
            else if (radioButton6.Checked) reservInfo.TypeOfFood = radioButton6.Text;
            else MessageBox.Show("Type of food not selected");
            var str = JsonConvert.SerializeObject(reservInfo, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("ReservInfo.json", str);
           
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            var info = File.ReadAllText("ReservInfo.json");
            reservInfo = JsonConvert.DeserializeObject<ReservInfo>(info);
            mTB_name.Text = reservInfo.Name;
            mTB_address.Text = reservInfo.Address;
            mTB_city.Text = reservInfo.City;
            mTB_email.Text = reservInfo.Email;
            mTB_phone.Text = reservInfo.Phone;
            mTB_surname.Text = reservInfo.Surname;
            mTB_ZIPcode.Text = reservInfo.Zip_code;
            mTB_adult.Text = Convert.ToString(reservInfo.Adults);
            mTB_under6.Text = Convert.ToString(reservInfo.KidsUnderOf_6Years);
            mTB_under3.Text = Convert.ToString(reservInfo.KidsUnderOf_3Years);
            dT_arrivial.Value = reservInfo.ArrivialDate;
            dT_endstay.Value= reservInfo.EndOfStay;
            combBox_payment.SelectedItem = reservInfo.Payment;
            

            if (radioButton1.Text == reservInfo.TypeOfRoom) radioButton1.Checked = true;
            else if (radioButton2.Text == reservInfo.TypeOfRoom) radioButton2.Checked = true;
            else if (radioButton3.Text == reservInfo.TypeOfRoom) radioButton3.Checked = true;

            if (radioButton4.Text == reservInfo.TypeOfFood) radioButton4.Checked = true;
            else if (radioButton5.Text == reservInfo.TypeOfFood) radioButton5.Checked = true;
            else if (radioButton6.Text == reservInfo.TypeOfFood) radioButton6.Checked = true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            mTB_name.Text = string.Empty;
            mTB_address.Text = string.Empty;
            mTB_city.Text = string.Empty;
            mTB_email.Text = string.Empty;
            mTB_phone.Text = string.Empty;
            mTB_surname.Text = string.Empty;
            mTB_ZIPcode.Text = string.Empty;
            mTB_adult.Text = string.Empty;
            mTB_under6.Text = string.Empty;
            mTB_under3.Text = string.Empty;
            dT_arrivial.Value = DateTime.Now;
            dT_endstay.Value = DateTime.Now;
            combBox_payment.SelectedIndex = 0;
            if (radioButton1.Checked)  radioButton1.Checked=false;
            else if (radioButton2.Checked) radioButton1.Checked = false;
            else if (radioButton3.Checked) radioButton1.Checked = false;

            if (radioButton4.Checked) radioButton4.Checked = false;
            else if (radioButton5.Checked) radioButton5.Checked = false;
            else if (radioButton6.Checked) radioButton6.Checked = false;
        }
    }
}
