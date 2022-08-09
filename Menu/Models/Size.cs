using System.Collections.Generic;

namespace Menu.Models
{
    public class Size
    {
        public Size()
        {
            this.JoinEntities = new HashSet<MenuItemSize>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int SizePrice { get; set; }

        public virtual ICollection<MenuItemSize> JoinEntities { get; set; }
    }
}