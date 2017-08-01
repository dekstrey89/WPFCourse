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
    private string name;
    private double price;
    private int count;

    /// <summary>
    /// Имя элемента заказа.
    /// </summary>
    public string Name
    {
      get { return name; }
      set
      {
        name = value;
        OnPropertyChanged("Name");
      }
    }

    /// <summary>
    /// Цена.
    /// </summary>
    public double Price
    {
      get { return price; }
      set
      {
        price = value;
        OnPropertyChanged("Price");
      }
    }

    /// <summary>
    /// Количество.
    /// </summary>
    public int Count
    {
      get { return count; }
      set
      {
        count = value;
        OnPropertyChanged("Count");
      }
    }

    public override string this[string columnName]
    {
      get
      {
        string result = null;

        if (columnName == "Name")
        {
          if (string.IsNullOrWhiteSpace(Name))
            result = "Имя не может быть пустым.";
        }
        else if (columnName == "Price")
        {
          if (Price < 0)
            result = "Цена не может быть меньше нуля.";
        }
        else if (columnName == "Count")
        {
          if (Count < 0)
            result = "Количество не может быть меньше нуля.";
        }

        return result;
      }
    }
  }
}
