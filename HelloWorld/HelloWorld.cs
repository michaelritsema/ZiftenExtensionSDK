using System;
using ExtensionSDK;

namespace Examples
{
    public class HelloWorld : ExtensionSDK.Extension
    {
        public HelloWorld(ExtensionDefinition extensionDefinition) : base(extensionDefinition)
        {

        }

        public override void run(string[] args)
        {
            String arg1 = args[0];
            String arg2 = args[1];
            emitResults(new string[] { "hello", arg1, arg2 });
        }

        public static void Main(string[] args)
        {

            var extensionDefinition = new ExtensionDefinitionBuilder().SetName("HelloWorld")
                                                                    .SetDescription("A Hello World Extension")
                                                                    .SetSchedule("", false)
                                                                    .SetPlatform(2)
                                                                    .AddParameter("arg1", "first param", true, "string")
                                                                    .AddParameter("arg2", "second param", false, "string")
                                                                    .AddOutputTag("tag0", "first response tag")
                                                                      .AddOutputTag("tag1", "second response  tag")
                                                                     .SetType("Binary")
                                                                    .BuildExtension();

            new HelloWorld(extensionDefinition).execute(args);
        }
    }
}
