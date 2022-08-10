namespace Menu.Models
{
  public class MenuItemSize
    {       
        public int MenuItemSizeId { get; set; }
        public int SizeId { get; set; }
        public int MenuItemId { get; set; }
        public int OrderId { get; set; }
        public virtual Size Size { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public virtual Order Order { get; set; }
    }
}