namespace ExtensionSDK
{

            public class ExtensionParameter
            {
                public string name { get; set; }
                public string DisplayName { get => displayName; set => displayName = value; }
                public string Description { get => description; set => description = value; }
                public string Type { get => type; set => type = value; }
                public string Value { get => value; set => this.value = value; }
                public bool Required { get => required; set => required = value; }

                private string displayName;
                private string description;
                private string type;
                private string value;
                private bool required;
            }

}
