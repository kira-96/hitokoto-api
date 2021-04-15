using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Hitokoto.Sample.wpf
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        private HitokotoContent _yiyan;

        public HitokotoContent Yiyan
        {
            get => _yiyan;
            private set => Set(ref _yiyan, value);
        }

        public async Task RefreshHitokoto()
        {
            IsBusy = true;
            Yiyan = await HitokotoHelper.GetHitokoto();
            IsBusy = false;
        }

        // PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets a backing field value and if it's changed raise a notifcation.
        /// </summary>
        /// <typeparam name="T">The type of the value being set.</typeparam>
        /// <param name="oldValue">A reference to the field to update.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">The name of the property for change notifications.</param>
        /// <returns></returns>
        public virtual bool Set<T>(ref T oldValue, T newValue, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                return false;
            }

            oldValue = newValue;

            NotifyOfPropertyChanged(propertyName ?? string.Empty);

            return true;
        }

        public virtual void NotifyOfPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
