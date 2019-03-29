using System;


namespace ExtensionSDK
{
    public abstract class Extension
    {
        public ExtensionDefinition extensionDefinition;

        public Extension(ExtensionDefinition extensionDefinition)
        {
            this.extensionDefinition = extensionDefinition;
        }


        public string buildZep()
        {
            return extensionDefinition.XML();
        }

        public abstract void run(string[] args);

        public void emitResults(string[] results)
        {
            Console.WriteLine("==== BEGIN EXTENSION RESULTS ====");
            Console.WriteLine(string.Join("|", results));
            Console.WriteLine("==== END EXTENSION RESULTS ====");
        }

        public int execute(string[] args)
        {
            if (args.Length > 0 && args[0] == "--build-zep")
            {
                Console.WriteLine(buildZep());
                return 0;
            }



            return 0;
        }

        static int Main(string[] args)
        {
            /* cmd params are quoted and space deliminatd */
            /* windows agent snippet 
             *   
             *  strCmdLine += "cmd.exe /c chcp 1252 >NUL && cd \"";
                strCmdLine += strDirA;
                strCmdLine += "\" && %SystemRoot%\\System32\\WindowsPowerShell\\v1.0\\PowerShell.exe -File \"";
                strCmdLine += _strFName;
                strCmdLine += "\" ";
            */

            /* results are separated by | */
            /* multiple rows are allowed, separated by new lines */
            return 0;

        }
    }
}
