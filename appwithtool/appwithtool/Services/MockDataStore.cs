using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appwithtool.Models;

namespace appwithtool.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Luigi", DescriptionDetail="Experience a slice of Italy with the delicious and inviting pizzas & pastas at Luigi's! Ideal for family dinners, meeting friends or a dinner date", Description="Italian", Location ="Grand Baie" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "KFC", Description="Fast Food", Location ="Bagatelle" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Panarotti", Description="Italiano",Location ="La croisette"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Happy Rajah", Description="Indian", Location ="Grand Baie"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Rocomama", Description="Burger",Location ="Bagatelle" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Steers", Description="Burger",Location ="Ebene" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}