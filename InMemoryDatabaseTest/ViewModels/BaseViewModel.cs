using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InMemoryDatabaseTest.Entities;

namespace InMemoryDatabaseTest.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public BaseViewModel(BaseEntity entity)
        {
            _entity = entity;
        }

        public string Name
        {
            get { return _entity.Name; }
            set
            {
                _entity.Name = value;
                OnPropertyChanged();
            }
        }

        private readonly BaseEntity _entity;
    }
}
