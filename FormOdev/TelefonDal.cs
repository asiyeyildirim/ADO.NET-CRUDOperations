using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormProject
{
    internal class TelefonDal
    {

        SqlConnection _connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;initial catalog=Telefon; integrated security=true;");
        public List<Telefon> GetAll()
        {
            Control();
            SqlCommand command = new SqlCommand("select *from TblTelefon", _connection);
            SqlDataReader reader = command.ExecuteReader();
            List<Telefon> telefonlar = new List<Telefon>();
            while (reader.Read())
            {
                Telefon telefon = new Telefon()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Marka = reader["Marka"].ToString(),
                    Model = reader["Model"].ToString(),

                    Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                    Stok = Convert.ToInt32(reader["Stok"])

                };

                telefonlar.Add(telefon);
            }
            reader.Close();
            _connection.Close();
            return telefonlar;


        }



        public void Ekle(Telefon telefon)
        {
            Control();
            SqlCommand command = new SqlCommand("insert into TblTelefon values(@marka,@model,@fiyat,@stok)", _connection);
            command.Parameters.AddWithValue("@marka", telefon.Marka);
            command.Parameters.AddWithValue("@model", telefon.Model);
            command.Parameters.AddWithValue("@fiyat", telefon.Fiyat);
            command.Parameters.AddWithValue("@stok", telefon.Stok);
            command.ExecuteNonQuery();
            _connection.Close();


        }


        public void Guncelle(Telefon telefon)
        {            Control();
            SqlCommand command = new SqlCommand("Update TblTelefon set Marka=@Marka,Model=@Model,Fiyat=@fiyat,Stok=@stok where Id=@Id", _connection);
            command.Parameters.AddWithValue("@Marka", telefon.Marka);
            command.Parameters.AddWithValue("@Model", telefon.Model);
            command.Parameters.AddWithValue("@Fiyat", telefon.Fiyat);
            command.Parameters.AddWithValue("@Stok", telefon.Stok);
            command.Parameters.AddWithValue("@Id", telefon.Id);
            command.ExecuteNonQuery();
            _connection.Close();


        }

        public void Sil(int Id)
        {
            Control();
            SqlCommand command = new SqlCommand("Delete from TblTelefon where Id=@Id", _connection);
            command.Parameters.AddWithValue("@Id", Id);
            command.ExecuteNonQuery();
            _connection.Close();

        }


        private void Control()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }


    }
}
