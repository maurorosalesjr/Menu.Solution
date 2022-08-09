using System.Collections.Generic;

namespace Menu.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
            this.JoinEntities = new HashSet<MenuItemSize>();
        }

        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BasePrice { get; set; }

        public virtual ICollection<MenuItemSize> JoinEntities { get;}
    }
}