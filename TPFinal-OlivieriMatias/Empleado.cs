using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace TPFinal_OlivieriMatias
{
    class Empleado
    {
        string nombre;
        int dni;
        int edad;
        bool casado;
        double salario;



        //Crea la persona y llena sus atributos
        public void Creador(string nombre, int dni, int edad, bool casado, double salario)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.edad = edad;
            this.casado = casado;
            this.salario = salario;
            Conexion con = new Conexion();
            

        }

        //Agrega la persona a la BBDD
        public void CreadorenDDBB()
        {
            Conexion con = new Conexion();
            if (con.operador("INSERT INTO Empleados(NombreCompleto, DNI, Edad, Casado, Salario) VALUES('" + nombre + "', '" + dni + "', '" + edad + "', '" + casado + "', '" + salario + "')") == true)
            {
                MessageBox.Show("Empleado agregado!!");

            }
            
                

        }
        //Edita una persona en la BBDD
        public void Editor(int ident, string nombre, int dni, int edad, bool casado, double salario)
        {
            Conexion con = new Conexion();
            if (con.operador(" UPDATE Empleados SET NombreCompleto = '"+nombre+"', DNI = '"+dni+"', Edad = '"+edad+"', Casado = '"+casado+"', Salario = '"+salario+"' WHERE Id = '"+ident+"'") == true)
            {
                MessageBox.Show("Empleado Modificado!!");

            }
        }

        //Eliminar empleado de la BBDD
        public void Eliminador(int ident)
        {
            Conexion con = new Conexion();
            if (con.operador(" DELETE FROM Empleados WHERE Id = '"+ident+"'") == true)
            {
                MessageBox.Show("Empleado Eliminado!!");

            }
        }

        //Buscar por ID en la BBDD
        public DataSet BuscarxID(int ident)
        {
            DataSet datos = new DataSet();
            Conexion con = new Conexion();
            datos = con.consultador(" SELECT * FROM Empleados WHERE Id = '" + ident + "'");
            
            
            return datos;
        }

        //Buscar todos los empleados
        public DataSet BuscarTodos()
        {
            DataSet datos = new DataSet();
            Conexion con = new Conexion();
            datos = con.consultador("select * from Empleados");


            return datos;
        }

        //Buscar por nombre
        public DataSet BuscarxNombre(string name)
        {
            DataSet datos = new DataSet();
            Conexion con = new Conexion();
            datos = con.consultador(" select * from Empleados WHERE NombreCompleto LIKE '" + name + "' ");
            return datos;
        }
                            






    }




    
    

}
