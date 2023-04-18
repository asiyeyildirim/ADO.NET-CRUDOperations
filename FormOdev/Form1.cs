using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormProject
{
    public partial class Form1 : Form
    {

        TelefonDal _TelefonDal = new TelefonDal();
        public Form1()
        {
            InitializeComponent();
        }

        private void Load1()
        {
            dataGridView1.DataSource = _TelefonDal.GetAll();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Load1();
        }




        private void btnUrunEkle_Click(object sender, EventArgs e)
        {

            _TelefonDal.Ekle(new Telefon
            {
                Marka = txtMarkaEkle.Text,
                Model = txtModelEkle.Text,
                Fiyat = Convert.ToDecimal(txtFiyatEkle.Text),
                Stok = Convert.ToInt32(txtStokEkle.Text)

            });

            Load1();
            MessageBox.Show("Telefon Bilgileri Başarılı Bir Şekilde Listeye Eklendi...");
            txtMarkaEkle.Clear();
            txtModelEkle.Clear();
            txtFiyatEkle.Clear();
            txtStokEkle.Clear();



        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtMarkaGuncelle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtModelGuncelle.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtFiyatGuncelle.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtStokGuncelle.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            Telefon telefon = new Telefon
            {
                Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                Marka = txtMarkaGuncelle.Text.ToString(),
                Model =txtModelGuncelle.Text.ToString(),
                Fiyat = Convert.ToDecimal(txtFiyatGuncelle.Text),
                Stok = Convert.ToInt32(txtStokGuncelle.Text)

            };
            _TelefonDal.Guncelle(telefon);
            Load1();
            MessageBox.Show("Update Başarlı Bir Şekilde Gerçekleşti..");

        }

        private void Load1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _TelefonDal.GetAll();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            _TelefonDal.Sil(Id);
            Load1();
            MessageBox.Show("Urun Başarlı Bir Şekilde silinmiştir..");
        }
    }
}
