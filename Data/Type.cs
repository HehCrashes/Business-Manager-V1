using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE.Data
{
    public class Type
    {
        public float capacity { get; set; }
        public string description { get; set; }
        public int group_id { get; set; }
        public int icon_id { get; set; }
        public int market_group_id { get; set; }
        public float mass { get; set; }
        public string name { get; set; }
        public float packaged_volume { get; set; }
        public int portion_size { get; set; }
        public bool published { get; set; }
        public float radius { get; set; }
        public int id { get; set; }
        public float volume { get; set; }
        /// <summary>
        /// FSIIIFSFIBFIF
        /// </summary>
        public Type()
        {
            this.capacity = -1.0f;
            this.description = string.Empty;
            this.group_id = -1;
            this.icon_id = -1;
            this.market_group_id = -1;
            this.mass = -1.0f;
            this.name = string.Empty;
            this.packaged_volume = -1.0f;
            this.portion_size = -1;
            this.published = false;
            this.radius = -1.0f;
            this.id = id;
            this.volume = -1.0f;
        }
    }
}
