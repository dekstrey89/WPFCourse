  using System;
using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
using System.Text;
using System.Threading.Tasks;
  using System.Windows.Controls.Primitives;

namespace FirstWpfApplication
{
  /// <summary>
  /// Класс "Покупатель".
  /// </summary>
  public class Customer : Entity
  {
    private string _firstName;
    private string _middleName;
    private string _lastName;

    /// <summary>
    /// Имя.
    /// </summary>
    public string FirstName
    {
      get { return _firstName; }
      set
      {
        _firstName = value;
        OnPropertyChanged("FirstName");
      }
    }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string MiddleName
    {
      get { return _middleName; }
      set
      {
        _middleName = value;
        OnPropertyChanged("MiddleName");
      }
    }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string LastName
    {
      get { return _lastName; }
      set
      {
        _lastName = value;
        OnPropertyChanged("LastName");
      }
    }

    /// <summary>
    /// Коллекция заказов.
    /// </summary>
    public ObservableCollection<Order> Orders { get; set; }

    /// <summary>
    /// Ошибки валидации.
    /// </summary>
    /// <param name="columnName">Имя колонки.</param>
    /// <returns>Текст ошибки.</returns>
    public override string this[string columnName]
    {
      get
      {
        string result = null;

        if (columnName == "FirstName")
        {
          if (string.IsNullOrWhiteSpace(this.FirstName))
            result = "Имя не может быть пустым.";
        }
        else if (columnName == "LastName")
        {
          if (string.IsNullOrWhiteSpace(this.LastName))
            result = "Фамилия не может быть пустой.";
        }

        return result;
      }
    }

    /// <summary>
    /// Конструктор по умолчанию.
    /// </summary>
    public Customer()
    {
      this.Orders = new ObservableCollection<Order>();
    }
  }
}
