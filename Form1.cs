using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace efmva1
{
    public partial class Form1 : Form
    {
        public database db =new database();
        public DataTable dt;
        public SqlDataReader rd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // reùplir combobox
            db.open();
              rd = db.executeReader("Select * from fournisseur");
            
              dt= new DataTable();
            dt.Load(rd);
            rd.Close();
            db.Close();
            comboBoxrsf.DataSource= dt;
            comboBoxrsf.DisplayMember= "rsf";
            //ataColumn col = new DataColumn();
            //col = dt.Columns[0];
            comboBoxrsf.ValueMember= "codef";
            
            
            textBoxdateEF.Text = DateTime.Now.ToShortDateString();

           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // rechercher produit   
            if (textBoxref.Text=="")
            {
                MessageBox.Show("Il faut saisir la référence du produits ");
                return;
            }
            db.open();
              rd = db.executeReader("Select * from produit Where refp='" + textBoxref.Text + "' ");
            if (!rd.Read())
            {
                
                MessageBox.Show("la référence du produits n'existe pas!!");
               
                return;

                db.Close();
            }
            else
            {
               textBoxdesg.Text = (string)rd[1];
                rd.Close();
                db.Close();
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.open();
            string codef = comboBoxrsf.ValueMember.ToString() ;
           db.executeQuery("insert into entree values('"+DateTime.Parse(textBoxdateEF.Text)+ "','"+int.Parse(textBoxQte.Text)+ "','"+textBoxref.Text+ "','"+codef+"') ");

            db.Close() ;


        }
    }
    
}
