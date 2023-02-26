using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace efmva1
{
    public  class database
    {
        string chaine = @"Data Source=.\SQLEXPRESS;Initial Catalog=efmv1;Integrated Security=True";
        public SqlConnection con;
        public  SqlCommand cmd;

        public database()
        {
            con = new SqlConnection(chaine);

            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        // update, delet,insert :
        public int executeQuery(string codeSQL)
        {
            cmd.CommandText = codeSQL; 
            int rows =cmd.ExecuteNonQuery();
            return rows;    
        }
        // select : Résultat à exploiter 
        public SqlDataReader executeReader(string codeSQL)
        {
            cmd.CommandText= codeSQL;   
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        // Executer les Select avec une seule valeur résultat 
        public object executeScalar(string codeSQL) 
        {
            cmd.CommandText= codeSQL;
            object valeur = cmd.ExecuteScalar();
            return valeur;
        }
        // Ouvrir la connexion
        public void open()
        {
            con.Open();
        }
        // Fermer la connexion
        public void Close()
        {
            con.Close();
        }
    }
}
