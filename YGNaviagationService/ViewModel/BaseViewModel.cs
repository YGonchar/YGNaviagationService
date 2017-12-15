using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace YG.ViewModel
{
    public class BaseViewModel :IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool SetPropertyAndRise<T>(ref T target, T value, [CallerMemberName] string propertyName = "")
        {
            if (Equals(target, value)) return false;

            target = value;
            RaisePropertyChanged(propertyName);
            return true;
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException(nameof(propertyExpression));

            var memberExpression = propertyExpression.Body as MemberExpression;

            if (memberExpression == null)
                throw new ArgumentException(nameof(propertyExpression), $"The expression body is not a {typeof(MemberExpression)}");

            var property = memberExpression.Member as PropertyInfo;

            if (property == null)
                throw new ArgumentException(nameof(propertyExpression), $"The expression body member is not a {typeof(PropertyInfo)}");

            RaisePropertyChanged(property.Name);
        }

        public bool IsBusy { get; set; }
        public async Task InitAsync()
        {
            throw new NotImplementedException();
        }

        public void OnAppearing()
        {
            throw new NotImplementedException();
        }

        public void OnDisappearing()
        {
            throw new NotImplementedException();
        }
    }
}
