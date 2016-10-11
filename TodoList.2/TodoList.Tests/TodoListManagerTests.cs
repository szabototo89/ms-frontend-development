using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TodoList.Tests
{
    [TestFixture]
    public class TodoListManagerTests
    {
        [Test]
        public void AddItem_WhenSpecifyingName_CreatesNewTodoListItem()
        {
            // Arrange
            ITodoListManager manager = new TodoListManager();

            // Act
            manager.AddItem("test-item");

            // Assert
            var result = manager.Items;
            // Assert.IsTrue(result.SequenceEqual(new[] { "test-item" }));
            Assert.That(result, Is.EquivalentTo(new[]
            {
                "test-item"
            }));
        }

        [Test]
        public void ToggleItem_WhenSpecifyingName_TogglesIsDoneProperty()
        {
            // Arrange
            ITodoListManager manager = new TodoListManager();
            manager.AddItem("test-item");

            // Act
            manager.ToggleItem("test-item");

            // Assert
            Assert.That(manager.CompletedItems, Is.EquivalentTo(new[]
            {
                "test-item"
            }));
        }
    }

    public struct TodoListItem
    {
        public String Name { get; set; }

        public Boolean IsDone { get; set; }
    }

    public interface ITodoListManager
    {
        void AddItem(String name);
        void ToggleItem(String name);

        IEnumerable<String> Items { get; }
        IEnumerable<String> CompletedItems { get; }
    }

    public enum Priority { Low, Normal, High }


    public class TodoListManager
    {
        private readonly List<TodoListItem> items;

        public TodoListManager()
        {
            this.items = new List<TodoListItem>();
        }

        public void AddItem(String name)
        {
            items.Add(new TodoListItem
            {
                Name = name,
                IsDone = false
            });
        }

        public void ToggleItem(String name)
        {
            for (int i = 0; i < items.Count; i++)
            {
                var actualTodoListItem = items[i];
                if (actualTodoListItem.Name == name)
                {
                    actualTodoListItem.IsDone = !actualTodoListItem.IsDone;
                    break;
                }
            }
        }

        private String SelectTodoListItemName(TodoListItem todoListItem)
        {
            //Object[] objects = new Object[]
            //{
            //    todoListItem, // TodoListItem
            //    "Hello world", // String
            //    2 // int -> Int32
            //};

            //foreach (var obj in objects)
            //{
            //    if (obj is TodoListItem)
            //    {
            //        TodoListItem todoListItem2 = obj as TodoListItem;
            //        return todoListItem2.Name;
            //    }

            //    if (obj.GetType() == typeof(TodoListItem))
            //    {
            //        return ((TodoListItem) obj).Name;
            //    }
            //    if (obj.GetType() == typeof(String))
            //    {
            //        return (String) obj;
            //    }
            //}


            return todoListItem.Name;
        }

        public IEnumerable<String> Items => items.Select(SelectTodoListItemName);

        public IEnumerable<String> CompletedItems => items.Where(item => item.IsDone)
                                                          .Select(item => item.Name);
    }
}