using System.Collections.Generic;

namespace Menu.Models
{
    public class Order 
    {
      public Order() 
      {
        this.JoinEntities = new HashSet<MenuItemSize>();
      }

      public int OrderId { get; set; }
      public string Name { get; }
      public string SizeName { get; }
      
      public virtual ICollection<MenuItemSize> JoinEntities { get; set; }
    }
}