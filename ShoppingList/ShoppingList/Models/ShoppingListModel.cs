using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingList.ShoppingListItems;


namespace ShoppingList.Models
{
    public class ShoppingListModel
    {
        private static List<Items> _listItems = new List<Items>();

        public bool AddItem(string name, int quantity)
        {
            if (quantity <= 0 || String.IsNullOrEmpty(name)) return false; //check if empty or invalid quantity
            if (_listItems.Any(list => list.Name.Contains(name))) return false; //check if already exists

            _listItems.Add(new Items() {Name = name, Quantity = quantity});
            return true;
        }

        public bool UpdateQuantity(string name, int quantity)
        {
            if (quantity <= 0 || String.IsNullOrEmpty(name)) return false; //check if empty or invalid quantity
            if (!_listItems.Any(list => list.Name.Contains(name))) return false; //check if doesnt exist

            _listItems.First(list => list.Name == name).Quantity = quantity;

            return true;
        }

        public bool RemoveItem(string name)
        {
            if (String.IsNullOrEmpty(name)) return false; //check if empty
            if (!_listItems.Any(list => list.Name.Contains(name))) return false; //check if doesnt exist

            _listItems.Remove(_listItems.Single(list => list.Name == name));
            return true;
        }

        public int GetQuantity(string name)
        {
            if (String.IsNullOrEmpty(name) || !_listItems.Any(list => list.Name.Contains(name))) return 0; //check if empty or doesnt exist

            return _listItems.First(list => list.Name == name).Quantity;
        }

        public List<Items> GetAllListItems()
        {
            return _listItems;
        }
    }
}