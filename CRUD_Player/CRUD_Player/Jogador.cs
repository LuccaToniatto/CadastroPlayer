using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_Player
{
    class Jogador
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string email { get; set; }
        public string celular { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\programas\\CRUD_Player\\CRUD_Player\\DbJogador.mdf;Integrated Security=True");

        public List<Jogador> listajogador()
        {
            List<Jogador> li = new List<Jogador>();
            string sql = "SELECT * FROM Jogador";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Jogador j = new Jogador();
                j.Id = (int)dr["Id"];
                j.nome = dr["nome"].ToString();
                j.cidade = dr["cidade"].ToString();
                j.email = dr["email"].ToString();
                j.celular = dr["celular"].ToString();
                li.Add(j);
            }
            return li;

        } 
        
        public void Inserir(string nome, string cidade, string email, string celular)
        {
            string sql = "INSERT INTO Jogador(nome,cidade,email,celular) VALUES ('"+nome+"','"+cidade+"','"+email+"','"+celular+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Jogador WHERE Id = '" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cidade = dr["cidade"].ToString();
                email = dr["email"].ToString();
                celular = dr["celular"].ToString();
            }
        }

        public void Atualizar(int Id, string nome, string cidade, string email, string celular)
        {
            string sql = "UPDATE Jogador SET nome='"+nome+"',cidade='"+cidade+"',email='"+email+"',celular='"+celular+"' WHERE Id='"+Id+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string sql = "DELETE FROM Jogador WHERE Id='"+Id+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
