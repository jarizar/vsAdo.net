using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace App.UI.Clinica.Common
{
    public class Helpers
    {
        public static void ConfigurarCombo(DropDownList combo,
           string textField, string valueField, object data
           )
        {
            combo.DataTextField = textField;  //Texto
            combo.DataValueField = valueField; //Código
            combo.DataSource = data;
            combo.DataBind();
        }
    }
}