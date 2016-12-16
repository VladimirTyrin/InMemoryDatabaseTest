using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InMemoryDatabaseTest.Entities;

namespace InMemoryDatabaseTest
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ObservableCollection<BaseEntity> Entities = new ObservableCollection<BaseEntity>();

        public void Update()
        {
            using (var context = new InMemoryContext())
            {
                var allNew = context.BaseEntities.ToList();
                Entities.Clear();
                foreach (var baseEntity in allNew)
                {
                    Entities.Add(baseEntity);
                }
            }
        }

        public void AddWithName(string name)
        {
            using (var context = new InMemoryContext())
            {
                context.BaseEntities.Add(new BaseEntity
                {
                    Name = name
                });
                context.SaveChanges();
            }
        }
    }
}
