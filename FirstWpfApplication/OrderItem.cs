using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpfApplication
{
  /// <summary>
  /// Класс "Элемент заказа".
  /// </summary>
  public class OrderItem : Entity
  {
    /// <summary>
    /// Имя элемента заказа.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Количество.
    /// </summary>
    public int Count { get; set; }
  }
}
