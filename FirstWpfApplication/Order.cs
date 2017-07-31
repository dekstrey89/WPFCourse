using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpfApplication
{
  /// <summary>
  /// Класс "Заказ".
  /// </summary>
  public class Order : Entity
  {
    /// <summary>
    /// Дата заказа.
    /// </summary>
    public DateTime OrderDate { get; private set; }

    /// <summary>
    /// Цена заказа.
    /// </summary>
    public double TotalPrice
    {
      get { return OrderItems.Sum(x => x.Price * x.Count); }
    }

    /// <summary>
    /// Элементы заказа.
    /// </summary>
    public List<OrderItem> OrderItems { get; set; }

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public Order()
    {
      this.OrderDate = DateTime.Now;
      this.OrderItems = new List<OrderItem>();
    }
  }
}
