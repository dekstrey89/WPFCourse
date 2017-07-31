using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpfApplication
{
  /// <summary>
  /// Класс "Репозиторий".
  /// </summary>
  public class Repository : Entity
  {
    /// <summary>
    /// Внутренний список покупателей.
    /// </summary>
    public List<Customer> Customers;

    /// <summary>
    /// Получить коллекцию покупателей.
    /// </summary>
    /// <returns>Коллекция покупателей.</returns>
    public List<Customer> GetAllCustomers()
    {
      return Customers;
    }

    /// <summary>
    /// Создать нового покупателя.
    /// </summary>
    /// <returns>Новый покупатель.</returns>
    public Customer CreateCustomer()
    {
      var customer = new Customer { Id = Customers.Max(x => x.Id) + 1 };
      Customers.Add(customer);

      return customer;
    }

    /// <summary>
    /// Удалить покупателя.
    /// </summary>
    /// <param name="customer">Покупатель.</param>
    public void DeleteCustomer(Customer customer)
    {
      Customers.Remove(customer);
    }

    /// <summary>
    /// Создать заказ.
    /// </summary>
    /// <returns>Новый заказ.</returns>
    public Order CreateOrder()
    {
      return new Order { Id = Customers.SelectMany(x => x.Orders).Max(x => x.Id) + 1 };
    }

    /// <summary>
    /// Удалить заказ.
    /// </summary>
    /// <param name="order">Заказ.</param>
    public void DeleteOrder(Order order)
    {
      foreach (var customer in Customers.Where(x => x.Orders.Contains(order)))
        customer.Orders.Remove(order);
    }

    /// <summary>
    /// Создать элемент заказа.
    /// </summary>
    /// <returns>Новый элемент заказа.</returns>
    public OrderItem CreateOrderItem()
    {
      //return new OrderItem { Id = (from c in Customers from o in c.Orders from oi in o.OrderItems select oi).Max(o => o.Id) + 1 };
      return new OrderItem { Id = Customers.SelectMany(c => c.Orders.SelectMany(o => o.OrderItems)).Max(i => i.Id) + 1};
    }

    /// <summary>
    /// Удалить элемент заказа.
    /// </summary>
    /// <param name="orderItem">Элемент заказа.</param>
    public void DeleteOrderItem(OrderItem orderItem)
    {
      foreach (var order in Customers.SelectMany(customer => customer.Orders.Where(order => order.OrderItems.Contains(orderItem))))
        order.OrderItems.Remove(orderItem);
    }

    /// <summary>
    /// Статический конструктор.
    /// </summary>
    public Repository()
    {
      var customer1 = new Customer { Id = 1, FirstName = "Филипп", MiddleName = "Бедросович", LastName = "Киркоров" };

      var order1 = new Order { Id = 1 };
      customer1.Orders.Add(order1);
      order1.OrderItems.Add(new OrderItem { Id = 1, Name = "OrderItem1", Count = 1, Price = 99 });
      order1.OrderItems.Add(new OrderItem { Id = 2, Name = "OrderItem2", Count = 2, Price = 54 });
      order1.OrderItems.Add(new OrderItem { Id = 3, Name = "OrderItem3", Count = 5, Price = 49 });

      var order2 = new Order { Id = 2 };
      customer1.Orders.Add(order2);
      order2.OrderItems.Add(new OrderItem { Id = 4, Name = "OrderItem4", Count = 1, Price = 43 });
      order2.OrderItems.Add(new OrderItem { Id = 5, Name = "OrderItem5", Count = 3, Price = 87 });
      order2.OrderItems.Add(new OrderItem { Id = 6, Name = "OrderItem6", Count = 9, Price = 96 });

      var customer2 = new Customer { Id = 2, FirstName = "Николай", MiddleName = "Викторович", LastName = "Басков" };

      var order3 = new Order { Id = 3 };
      customer2.Orders.Add(order3);
      order3.OrderItems.Add(new OrderItem { Id = 7, Name = "OrderItem7", Count = 2, Price = 99 });
      order3.OrderItems.Add(new OrderItem { Id = 8, Name = "OrderItem8", Count = 6, Price = 54 });
      order3.OrderItems.Add(new OrderItem { Id = 9, Name = "OrderItem9", Count = 7, Price = 49 });

      var order4 = new Order { Id = 4 };
      customer2.Orders.Add(order4);
      order4.OrderItems.Add(new OrderItem { Id = 10, Name = "OrderItem10", Count = 2, Price = 43 });
      order4.OrderItems.Add(new OrderItem { Id = 11, Name = "OrderItem11", Count = 5, Price = 87 });
      order4.OrderItems.Add(new OrderItem { Id = 12, Name = "OrderItem12", Count = 8, Price = 96 });

      var order5 = new Order { Id = 5 };
      customer2.Orders.Add(order5);
      order5.OrderItems.Add(new OrderItem { Id = 13, Name = "OrderItem13", Count = 1, Price = 43 });
      order5.OrderItems.Add(new OrderItem { Id = 14, Name = "OrderItem14", Count = 6, Price = 87 });
      order5.OrderItems.Add(new OrderItem { Id = 15, Name = "OrderItem15", Count = 5, Price = 96 });

      var customer3 = new Customer { Id = 3, FirstName = "Максим", MiddleName = "Александрович", LastName = "Галкин" };

      var order6 = new Order { Id = 6 };
      customer3.Orders.Add(order6);
      order6.OrderItems.Add(new OrderItem { Id = 16, Name = "OrderItem16", Count = 5, Price = 99 });
      order6.OrderItems.Add(new OrderItem { Id = 17, Name = "OrderItem17", Count = 3, Price = 54 });
      order6.OrderItems.Add(new OrderItem { Id = 18, Name = "OrderItem18", Count = 8, Price = 49 });

      var order7 = new Order { Id = 7 };
      customer3.Orders.Add(order7);
      order7.OrderItems.Add(new OrderItem { Id = 19, Name = "OrderItem19", Count = 3, Price = 43 });
      order7.OrderItems.Add(new OrderItem { Id = 20, Name = "OrderItem20", Count = 2, Price = 87 });
      order7.OrderItems.Add(new OrderItem { Id = 21, Name = "OrderItem21", Count = 1, Price = 96 });

      var order8 = new Order { Id = 8 };
      customer3.Orders.Add(order8);
      order8.OrderItems.Add(new OrderItem { Id = 22, Name = "OrderItem22", Count = 9, Price = 43 });
      order8.OrderItems.Add(new OrderItem { Id = 23, Name = "OrderItem23", Count = 4, Price = 87 });
      order8.OrderItems.Add(new OrderItem { Id = 24, Name = "OrderItem24", Count = 6, Price = 96 });

      Customers = new List<Customer> { customer1, customer2, customer3 };
    }
  }
}
