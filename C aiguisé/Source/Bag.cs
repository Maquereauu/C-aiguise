using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace C_aiguisé
{
    public class Bag
    {
        private Dictionary<Item, int> _bag;

        public Dictionary<Item, int> _mBag
        {
            get { return _bag; }
            protected set { _bag = value; }
        }

        public void AddItem(Item item, int number = 1)
        {
            foreach (var el in _bag)
            {
                if (el.Key.GetName() == item.GetName() && el.Key.IsUnique() == false)
                {
                    if (_bag[el.Key] < 99 - number)
                    {
                        _bag[el.Key] += number;
                        return;
                    }
                }
            }

            if (item.IsUnique() == true)
            {
                _bag.Add(item, 1);
            }
            else
            {
                _bag.Add(item, number);
            }
            
        }
        public void AddItem(List<Item> items, List<int> numbers)
        {
            if (items.Count != numbers.Count)
            {
                Console.Clear();
                Console.WriteLine("Error with add items");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    AddItem(items[i], numbers[i]);
                }
            }

        }
        public void RemoveItem(Item item, int number = 1)  
        {
            foreach (var el in _bag)
            {
                if (el.Key.GetName() == item.GetName())
                {
                    if (el.Key.IsUnique() == false)
                    {
                        if (_bag[el.Key] >= number)
                        {
                            _bag[el.Key] -= number;
                        }
                    }
                    else
                    {
                        _bag.Remove(el.Key);
                    }
                    return;
                }
            }
        }
        public void RemoveItem(List<Item> items, List<int> numbers)
        {
            if (items.Count != numbers.Count)
            {
                Console.Clear();
                Console.WriteLine("Error with remove items");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    RemoveItem(items[i], numbers[i]);
                }
            }
            
        }

        public Dictionary<Item, int> GetBag()
        {
            return _bag;
        }

    }
}