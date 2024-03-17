using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Data
{
    public class Type
    {
        float capacity { get; set; } = -1f;
        string description { get; set; } = string.Empty;
        int group_id { get; set; } = -1;
        float mass { get; set; } = -1f;
        string name { get; set; } = string.Empty;
        float packaged_volume { get; set; } = -1f;
        int portion_size { get; set; } = -1;
        bool published { get; set; } = true;
        float radius { get; set; } = -1f;
        int id { get; set; } = -1;
        float volume { get; set; } = -1f;
        public Type(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public Type(float capacity, string description, int group_id, float mass, string name, float packaged_volume, int portion_size, bool published, float radius, int id, float volume)
        {
            this.capacity = capacity;
            this.description = description;
            this.group_id = group_id;
            this.mass = mass;
            this.name = name;
            this.packaged_volume = packaged_volume;
            this.portion_size = portion_size;
            this.published = published;
            this.radius = radius;
            this.id = id;
            this.volume = volume;
        }
    }
}
