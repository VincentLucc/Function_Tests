using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestProject
{
    class ClassPublic
    {
        public static FormMain winMain;
        public static FormTest winTest;
    }

    public class MailSample
    {
        [Category("Settings"), DisplayName("Mail ID"), Description("This is test1")]
        public int MailID { get; set; }

        [Category("Settings"), DisplayName("Title"), Description("This is abc")]
        public string Title { get; set; }

        [Category("Settings"), DisplayName("Sender"), Description("This is 123")]
        public string Sender { get; set; }

        [Browsable(false)]  //Don't show
        [Category("Settings"), DisplayName("Content"), Description("This is ti456tle")]
        public string Content { get; set; }
    }


}
