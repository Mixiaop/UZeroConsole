using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JetBrains.Annotations;

namespace UZeroConsole.Web._Tests
{
    public partial class JetBrainsTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var jet = new JetBrainsClass();
            var child = jet.Child;
           Response.Write(child.Name);
            Response.Write("sus");
        }
    }

    public class JetBrainsClass {
        [NotNull]
        public JetBrainsChild Child { get; set; }
        public string Name { get; set; }
    }

    public class JetBrainsChild {
        public string Name { get; set; }
    }
}