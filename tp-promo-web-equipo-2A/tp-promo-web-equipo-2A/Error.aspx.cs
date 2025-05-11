using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_promo_web_equipo_2A
{
    public partial class Error : System.Web.UI.Page
    {
        public string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"] != null)
            {
                msg = Session["error"].ToString();
            }
        }
    }
}