using Microsoft.Data.SqlClient;
using ProyectoMVC.Models;

namespace ProyectoMVC.Repositories
{
    public class RepositoryHospital
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            this.con = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.con;
        }
        public List<Hospital> GetHospitales()
        {
            string sql = "SELECT * FROM HOSPITAL";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.con.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> hospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hospital);
            }
            this.reader.Close();
            this.con.Close();
            return hospitales;
        }

        public Hospital FindHospital(int idHospital)
        {
            string sql = "select * from HOSPITAL where HOSPITAL_COD=@idhospital";
            this.com.Parameters.AddWithValue("@idhospital", idHospital);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.con.Open();
            this.reader = this.com.ExecuteReader();
            Hospital hospital = new Hospital();
            this.reader.Read();
            hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            hospital.Nombre = this.reader["NOMBRE"].ToString();
            hospital.Direccion = this.reader["DIRECCION"].ToString();
            hospital.Telefono = this.reader["TELEFONO"].ToString();
            hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
            this.reader.Close();
            this.con.Close();
            this.com.Parameters.Clear();
            return hospital;
        }

        public void CreateHospital(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "insert into HOSPITAL values (@idHospital, @nombre, @direccion, @telefono, @camas)";
            this.com.Parameters.AddWithValue("@idHospital", idHospital);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@camas", camas);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.con.Open();
            this.com.ExecuteNonQuery();
            this.con.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateHospital(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "update HOSPITAL set NOMBRE=@nombre "
                        + ", DIRECCION=@direccion, TELEFONO=@telefono "
                        + ", NUM_CAMA=@camas "
                        + " where HOSPITAL_COD=@idhospital";
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@camas", camas);
            this.com.Parameters.AddWithValue("idhospital", idHospital);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.con.Open();
            this.com.ExecuteNonQuery();
            this.con.Close();
            this.com.Parameters.Clear();
        }
    }
}
