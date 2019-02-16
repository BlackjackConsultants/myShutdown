using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myshutdown {
    class Program {
        private enum shutDownTypeEnum {
            sleep = 0,
            shutdown = 1,
            restart = 2,
            hybernate = 3
        }
        private static shutDownTypeEnum shutDownType;
        
        static void Main(string[] args) {
            if (args.Length > 0) {
                shutDownType = (shutDownTypeEnum)Enum.Parse(typeof(shutDownTypeEnum), args[0], true);
            } else {
                shutDownType = shutDownTypeEnum.sleep;
            }
            switch (shutDownType) {
                case shutDownTypeEnum.sleep:
                    // arg = 0
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
                case shutDownTypeEnum.shutdown:
                    // arg = 1
                    System.Diagnostics.Process.Start("shutdown.exe", "-s 0");
                    break;
                case shutDownTypeEnum.restart:
                    // arg = 2
                    System.Diagnostics.Process.Start("shutdown.exe", "-r");
                    break;
                default:
                    // arg >= 3
                    Application.SetSuspendState(PowerState.Hibernate, true, true);
                    break;
            }
        }
    }
}
