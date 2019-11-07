using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationServices
{
    public partial class _Default : System.Web.UI.Page
    {
       public ServiceReference1.ServicioEjemploSoapClient serv = new ServiceReference1.ServicioEjemploSoapClient();
       //creamos una propiedad llamada serv donde instanciamos el objeto del servicio
           
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = serv.HelloWorld();//de esta forma llamamos al metodo HelloWorld del 
                                              //servicio ServiceReference1

        }
    }
}