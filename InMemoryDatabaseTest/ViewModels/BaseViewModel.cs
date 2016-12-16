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
            Entity = entity;
        }

        public int Id => Entity.Id;

        public string Name
        {
            get { return Entity.Name; }
            set
            {
                Entity.Name = value;
                OnPropertyChanged();
            }
        }

        public readonly BaseEntity Entity;
    }
}
