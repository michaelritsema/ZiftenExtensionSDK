using System;
namespace ExtensionSDK
{
    public class ExtensionDefinitionBuilder
    {
        public ExtensionDefinition extensionDefinition { get; set; }

        public ExtensionDefinitionBuilder()
        {
            this.extensionDefinition = new ExtensionDefinition();
        }

        public ExtensionDefinitionBuilder SetName(string name)
        {
            extensionDefinition.moduleName = name;
            return this;
        }

        public ExtensionDefinitionBuilder SetDescription(string description)
        {
            extensionDefinition.description = description;
            return this;
        }

        public ExtensionDefinitionBuilder SetSchedule(string scheduleType, bool scheduleSelected)
        {
            extensionDefinition.schedule_type = scheduleType;
            extensionDefinition.schedule_selected = scheduleSelected;
            return this;
        }

        public ExtensionDefinitionBuilder SetPlatform(int platform)
        {
            extensionDefinition.platform = platform;
            return this;
        }

        public ExtensionDefinitionBuilder SetType(String type)
        {
            extensionDefinition.extensionType = type;
            return this;
        }

        public ExtensionDefinitionBuilder AddParameter(string name, string description, bool required, string parameterType)
        {
            var extensionParameter = new ExtensionParameter
            {
                name = name,
                Description = description,
                Required = required,
                Type = parameterType
            };

            extensionDefinition.parameters.Add(extensionParameter);
            return this;

        }
        public ExtensionDefinitionBuilder AddOutputTag(string name, string displayName)
        {
            var outputTag = new OutputTag
            {
                Name = name,
                DisplayName = displayName
            };
            extensionDefinition.tags.Add(outputTag);
            return this;
        }

        public ExtensionDefinition BuildExtension()
        {
            return extensionDefinition;
        }
    }
}
