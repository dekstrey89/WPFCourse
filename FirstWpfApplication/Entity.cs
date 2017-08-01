using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstWpfApplication
{
  /// <summary>
  /// Класс "Базовая сущность".
  /// </summary>
  public abstract class Entity : INotifyPropertyChanged, IDataErrorInfo
  {
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id
    {
      get { return Id; }
      set
      {
        Id = value;
        OnPropertyChanged("Id");
      }
    }

    /// <summary>
    /// Текст ошибки.
    /// </summary>
    public string Error
    {
      get { return "Объект содержит ошибки данных."; }
    }

    /// <summary>
    /// Текст ошибки определенного свойства.
    /// </summary>
    /// <param name="columnName"></param>
    /// <returns></returns>
    public virtual string this[string columnName]
    {
      get { return null; }
    }

    /// <summary>
    /// Событие на изменение свойства.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Сгенерировать событие на изменение свойства.
    /// </summary>
    /// <param name="propertyName"></param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
