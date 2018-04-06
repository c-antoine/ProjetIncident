using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjetIncident.Core.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private Dictionary<string, object> _propertyValues;

        public virtual object GetContent([CallerMemberName] string propertyName = null, object defaultValue = null)
        {
            if (_propertyValues.ContainsKey(propertyName)) return _propertyValues[propertyName];
            return defaultValue;
        }
        public virtual bool SetContent<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            object current = GetContent(propertyName);

            if ((current == null && newValue == null) ||
                (current != null && EqualityComparer<T>.Default.Equals((T)current, newValue)))
            {
                return false;
            }

            _propertyValues[propertyName] = newValue;
            OnPropertyChanged(propertyName);

            return true;
        }

        public BaseViewModel()
        {
            propertyValues = new Dictionary<string, object>();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected Dictionary<string, object> propertyValues;
        protected T GetProperty<T>([CallerMemberName]string propertyName = null)
        {
            if (propertyValues.ContainsKey(propertyName))
                return (T)propertyValues[propertyName];
            return default(T);
        }

        protected bool SetProperty<T>(T value,
                                      [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(GetProperty<T>(propertyName), value))
            {
                propertyValues[propertyName] = value;
                OnPropertyChanged(propertyName);
                return true;
            }
            return false;
        }
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}