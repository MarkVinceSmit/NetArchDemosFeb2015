using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace myService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // self host WCF
            // NO USING STATEMENT!!!!
            

            EventLog.WriteEntry("We've started");
        
        
        }

        protected override void OnStop()
        {
        }
    }
}
