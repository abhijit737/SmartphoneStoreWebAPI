using System.Reflection;
using System.Text.Json.Serialization;

namespace MobilePhoneStore.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]

        public virtual ICollection<Mobile> Mobiles { get; set; }
    }
}


