using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackExchange.Profiling;

namespace UZeroConsole.WebTests
{
    public partial class MiniProfilerTests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //using (MiniProfiler.Current.Step("Hello start"))
            //{
            //    var a = 1;
            //}

            var person = new Person();
            person.ChangedName += Person_ChangedName;
            person.ChangeName("<br /><br />1");
        }

        private void Person_ChangedName(object sender, Person.ChangeNameArgs e)
        {
            Response.Write("hello" + e.WhatName);
        }
    }

    public class Person
    {
        private string _name;
        public event EventHandler<ChangeNameArgs> ChangedName;
        
        public class ChangeNameArgs : EventArgs
        {
            public string WhatName { get; set; }
        }

        public void ChangeName(string name) {
            _name = name;
            ChangedName(this, new ChangeNameArgs() { WhatName = name });
        }
    }

}