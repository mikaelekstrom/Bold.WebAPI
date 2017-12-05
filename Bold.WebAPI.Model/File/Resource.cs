using System;
using Bold.Shared.Types.GeneratedCode.Enums;

namespace Bold.WebAPI.Model.File
{
    public class Resource
    {
        public int Id { get; }
        public ResourceTypeEnum Type { get; }
        public string Filename { get; }

        public Resource(int id, ResourceTypeEnum type, string filename)
        {
            Id = id;
            Type = type;
            Filename = filename ?? throw new ArgumentNullException(nameof(filename));
        }
    }
}
