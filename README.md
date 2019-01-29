# myShutdown
this is a console application that puts a computer to sleep. you can pass 4 parameters to make the pc sleep, hibernate, shutdown or restart.  the reason i created this application is because i removed all the buttons from windows so my family stops putting the computer to sleep.  This affected me because i was unable to rdp to it.
```
myShutdown.exe 

myShutdown.exe 1

myShutdown.exe 2

myShutdown.exe 3
```
This is what teh main method looks like.
```
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
```
