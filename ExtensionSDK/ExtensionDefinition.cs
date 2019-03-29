using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtensionSDK
{

    public class ExtensionDefinition
    {
        public string moduleName { get; set; }
        public string description { get; set; }
        public int platform { get; set; }
        public string schedule_type { get; set; }
        internal bool schedule_selected { get; set; }
        public string extensionType = "Binary";

        public List<ExtensionParameter> parameters = new List<ExtensionParameter>();
        internal List<OutputTag> tags = new List<OutputTag>();

        public string readSelf()
        {
            byte[] AsBytes = File.ReadAllBytes(System.Reflection.Assembly.GetExecutingAssembly().Location);
            String AsBase64String = Convert.ToBase64String(AsBytes);
            return AsBase64String;
        }

        public string XML()
        {


            // keep the EXE smaller by not using a template library
            var builder = new StringBuilder();
            builder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n");
            builder.Append("<module>\n");
            builder.Append("<name>").Append(this.moduleName).Append("</name>\n");
            builder.Append("<description>").Append(this.description).Append("</description>\n");
            builder.Append("<platforms>\n")
                   .Append("<platform>\n")
                   .Append(this.platform)
                   .Append("</platform>\n")
                   .Append("</platforms>\n");

            builder.Append("<Parameters>\n");
            foreach (var param in parameters)
            {
                builder.Append("<Parameter>\n")
                .Append("<name>")
                .Append(param.name)
                .Append("</name>")
                .Append("<displayName>")
                .Append(param.DisplayName)
                .Append("</displayName>")
                .Append("<description>")
                .Append(param.Description)
                .Append("</description>")
                .Append("<type>")
                .Append(param.Type)
                .Append("</type>")
                .Append("<required>")
                .Append(param.Required)
                .Append("</required>")
                .Append("</Parameter>\n");
            }
            //.Append().Append("<>");
            builder.Append("</Parameters>\n");

            builder.Append("<output>");
            foreach (var tag in tags)
            {

                builder.Append("<tag>")
                        .Append("<name>")
                       .Append(tag.Name)
                        .Append("</name>")
                        .Append("<displayName>")
                       .Append(tag.DisplayName)
                        .Append("</displayName>")
                       .Append("</tag>");
            }
            builder.Append("</output>")
            .Append("<extension><![CDATA[")
            .Append(readSelf())
            .Append("]]></extension>\n</module>");
            return builder.ToString();
        }

    }

}
