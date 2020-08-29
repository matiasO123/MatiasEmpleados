using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal_OlivieriMatias
{
    public partial class Form1 : Form
    {

        DataSet ddss = new DataSet();
        int identify;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LlenarDDGG();
            


        }

        //LLena la tabla al arrancar el programa o hacer alguna operación
        public void LlenarDDGG()
        {
            
            Empleado emp = new Empleado();
            ddss = emp.BuscarTodos();
            
            dataGridView1.DataSource = ddss.Tables[0];
            dataGridView1.Columns["ID"].Visible = false;
        }
                
        
        
        
       
        /// ///////////////////////////////////////////////////////////////////////////
       //BOTONES FUNCIONALES
        
        
        //BOTON AGREGAR en Pestaña 'principal'
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);

        }

        //BOTON AGREGAR en pestaña 'agregar'
        private void button6_Click(object sender, EventArgs e)
        {
            bool vale = true;
            bool esCasado = false ;
            int result = 0;
            double resu = 0;
            int resul = 0;


            //VALIDACIONES DE CAMPOS
            //Nombre
            if(textBox1.Text == "")
            {
                vale = false;
                MessageBox.Show("El nombre es obligatorio");
            }
            //DNI
            if (textBox2.Text == "")
            {
                vale = false;
                MessageBox.Show("El DNI es obligatorio");
            } 
            else if (Int32.TryParse(textBox2.Text, out result) == false)
            {
                vale = false;
                MessageBox.Show("El dni debe contener sólo números");
            }
            //Edad
            if (textBox3.Text == "")
            {
                vale = false;
                MessageBox.Show("La edad es obligatoria");
            } 
            else if (Int32.TryParse(textBox3.Text, out resul) == false)
            {
                vale = false;
                MessageBox.Show("La edad debe contener sólo números");
            }
            //Casado
            if (textBox4.Text == "")
            {
                vale = false;
                MessageBox.Show("El estado civil es obligatorio");
            }
            else if (textBox4.Text == "si")
            {
                esCasado = true;
            }
            else if (textBox4.Text == "no")
            {
                esCasado = false;
            }
            else
            {
                vale = false;
                MessageBox.Show("En el estado civil ingresá 'si' o 'no'");
            }
            if (textBox5.Text == "")
            {
                vale = false;
                MessageBox.Show("El salario es obligatorio");
            } 
            else if (Double.TryParse(textBox5.Text, out resu) == false)
            {
                vale = false;
                MessageBox.Show("El salario debe expresarse en números");
            }

            if (vale == true)
            {
                Empleado emp = new Empleado();
                emp.Creador(textBox1.Text, result, resul, esCasado, resu);
                emp.CreadorenDDBB();
                tabControl1.SelectTab(0);
                LlenarDDGG();

            }



            
        }
        
        //BOTON EDITAR en  pestaña 'principal'
        private void button2_Click(object sender, EventArgs e)
        {
            identify = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            tabControl1.SelectTab(2);
            Empleado emp = new Empleado();
            
            ddss = emp.BuscarxID(identify);
            textBox11.Text = ddss.Tables[0].Rows[0]["NombreCompleto"].ToString();
            textBox10.Text = ddss.Tables[0].Rows[0]["DNI"].ToString();
            textBox9.Text = ddss.Tables[0].Rows[0]["Edad"].ToString();
            if (ddss.Tables[0].Rows[0]["Casado"].ToString() == "true")
            {
                textBox8.Text = "si";
            }
            else textBox8.Text = "no";
                     
            textBox7.Text = ddss.Tables[0].Rows[0]["Salario"].ToString();






        }

        //BOTON MODIFICAR en pestaña 'editar'
        private void button7_Click(object sender, EventArgs e)
        {
            bool vale = true;
            bool esCasado = false;
            int result = 0;
            double resu = 0;
            int resul = 0;


            //VALIDACIONES DE CAMPOS
            //Nombre
            if (textBox11.Text == "")
            {
                vale = false;
                MessageBox.Show("El nombre es obligatorio");
            }
            //DNI
            if (textBox10.Text == "")
            {
                vale = false;
                MessageBox.Show("El DNI es obligatorio");
            }
            else if (Int32.TryParse(textBox10.Text, out  result) == false)
            {
                vale = false;
                MessageBox.Show("El dni debe contener sólo números");
            }
            //Edad
            if (textBox9.Text == "")
            {
                vale = false;
                MessageBox.Show("La edad es obligatoria");
            }
            else if (Int32.TryParse(textBox9.Text, out  resul) == false)
            {
                vale = false;
                MessageBox.Show("La edad debe contener sólo números");
            }
            //Casado
            if (textBox8.Text == "")
            {
                vale = false;
                MessageBox.Show("El estado civil es obligatorio");
            }
            else if (textBox8.Text == "si")
            {
                esCasado = true;
            }
            else if (textBox8.Text == "no")
            {
                esCasado = false;
            }
            else
            {
                vale = false;
                MessageBox.Show("En el estado civil ingresá 'si' o 'no'");
            }
            if (textBox7.Text == "")
            {
                vale = false;
                MessageBox.Show("El salario es obligatorio");
            }
            else if (Double.TryParse(textBox7.Text, out  resu) == false)
            {
                vale = false;
                MessageBox.Show("El salario debe expresarse en números");
            }

            if (vale == true)
            {
                Empleado emp = new Empleado();
                emp.Editor(identify, textBox11.Text, result, resul, esCasado, resu);
                
                tabControl1.SelectTab(0);

                LlenarDDGG();

            }
        }

        //BOTON ELIMINAR
        private void button3_Click(object sender, EventArgs e)
        {
            identify = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            Empleado emp = new Empleado();

            emp.Eliminador(identify);
            LlenarDDGG();
        }

        //BOTON BUSCAR
        private void button5_Click_1(object sender, EventArgs e)
        {
            Empleado emp = new Empleado();
            if (textBox6.Text == "")
            {
                MessageBox.Show("Llená el campo de arriba a la izquierda con algún nombre");
            }
            else
            {
                string nombre = textBox6.Text;
                ddss = emp.BuscarxNombre(nombre);
                dataGridView1.DataSource = ddss.Tables[0];
                dataGridView1.Columns["ID"].Visible = false;
            }
        }







        /// ///////////////////////////////////////////////////////////////////////////
       //BOTONES SECUNDARIOS

        //BOTON VOLVER
        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        //BOTON VOLVER2
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        //BOTÓN CERRAR
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }



//Consulta SQL para ejecutar en SQLServer
/* use master

go

Create database EMPLEADOS_DB

GO

Use EMPLEADOS_DB

Go

Create Table Empleados(

Id int IDENTITY(1,1) PRIMARY KEY,

NombreCompleto varchar(100) not null,

DNI varchar(10) not null,

Edad int not null,

Casado bit not null,

Salario decimal (12,2)

);  

GO

Insert into Empleados(NombreCompleto, DNI, Edad, Casado, Salario)

values('Juan Topo','12345633',55,1,2500.02)

Go

Insert into Empleados(NombreCompleto, DNI, Edad, Casado, Salario)

values('Mirta Grand','100000',85,1,99989989.12)

Go

Insert into Empleados(NombreCompleto, DNI, Edad, Casado, Salario)

values('Marcos Pereira','36154214',18,0,10000)

Go

Insert into Empleados(NombreCompleto, DNI, Edad, Casado, Salario)

values('Josefina Fausto','54653756',45,1,1111152.45)

Go

Insert into Empleados(NombreCompleto, DNI, Edad, Casado, Salario)

values('Raul Portal','23152478',65,0,1000)

Go

Insert into Empleados(NombreCompleto, DNI, Edad, Casado, Salario)

values('Lizy Gaga','91235487',35,1,2556600.22)*/


}
