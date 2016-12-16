using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using InMemoryDatabaseTest.Entities;
using InMemoryDatabaseTest.ViewModels;

namespace InMemoryDatabaseTest
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            var examples = new List<BaseEntity>
            {
                new BaseEntity {Name = "First entity"}
            };
            using (var context = new InMemoryContext())
            {
                context.BaseEntities.AddRange(examples);
                context.SaveChanges();
            }

            Update();
        }

        public BaseViewModel SelectedItem { get; set; }
        public ObservableCollection<BaseViewModel> Collection { get; } = new ObservableCollection<BaseViewModel>();

        public void Update()
        {
            List<BaseEntity> allNew;
            using (var context = new InMemoryContext())
            {
                allNew = context.BaseEntities.ToList();
            }
            Collection.Clear();
            foreach (var baseEntity in allNew)
            {
                Collection.Add(new BaseViewModel(baseEntity));
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
            Update();
        }

        public void RemoveCurrent()
        {
            if (SelectedItem == null)
            {
                return;
            }

            using (var context = new InMemoryContext())
            {
                context.BaseEntities.Remove(SelectedItem.Entity);
                context.SaveChanges();
            }
            Update();
        }
    }
}
