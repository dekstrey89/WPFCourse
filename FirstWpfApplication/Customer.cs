using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpfApplication
{
  /// <summary>
  /// Класс "Покупатель".
  /// </summary>
  public class Customer : Entity
  {
    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string MiddleName { get; set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Коллекция заказов.
    /// </summary>
    public List<Order> Orders { get; set; }

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public Customer()
    {
      this.Orders = new List<Order>();
    }
  }
}
