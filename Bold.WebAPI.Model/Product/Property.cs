using System;

namespace Bold.WebAPI.Model.Product
{
    public class Property
    {
        public int PropertyId { get; }
        public int LanguageId { get; }
        public string Name { get; }
        public string UnitLong { get; }
        public string UnitShort { get; }
        public string Value { get; }

        public Property(int propertyId, int languageId, string name, string unitLong, string unitShort, string value)
        {
            PropertyId = propertyId;
            LanguageId = languageId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UnitLong = unitLong ?? throw new ArgumentNullException(nameof(unitLong));
            UnitShort = unitShort ?? throw new ArgumentNullException(nameof(unitShort));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
