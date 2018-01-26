using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UZeroConsole.Web._Tests
{
    public partial class LanguageTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(TimeSpan.FromSeconds(15));

        }
    }

    public static class UserTest
    {
        public static bool Enabled => Items.Count > 0;

        private static IList<string> _items = new List<string>();
        public static IList<string> Items => _items;

    }
}