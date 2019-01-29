using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myshutdown {
    class Program {
        private enum shutDownTypeEnum {
            sleep,
            shutdown,
            restart,
            hybernate
        }
        private static shutDownTypeEnum shutDownType;
        
        static void Main(string[] args) {
            if (args.Length > 0) {
                var shutdownType = args[0];
            } else {
                shutDownType = shutDownTypeEnum.sleep;
            }
            switch (shutDownType) {
                case shutDownTypeEnum.sleep:
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                    break;
                case shutDownTypeEnum.shutdown:
                    System.Diagnostics.Process.Start("shutdown.exe", "-s 0");
                    break;
                case shutDownTypeEnum.restart:
                    System.Diagnostics.Process.Start("shutdown.exe", "-r");
                    break;
                default:
                    Application.SetSuspendState(PowerState.Hibernate, true, true);
                    break;
            }
        }
    }
}
