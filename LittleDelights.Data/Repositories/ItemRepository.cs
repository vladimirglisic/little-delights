using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Data.Repositories
{
    public class ItemRepository
    {
        private readonly Context context;

        public ItemRepository(Context context)
        {
            this.context = context;
        }

        public Guid AddItem(Item item)
        {
            Guid id = Guid.NewGuid();

            context.Items[id] = item;

            return id;
        }

        public Item GetItem(Guid id)
        {
            if (!context.Items.ContainsKey(id)) return null;

            return context.Items[id];
        }

        public Dictionary<Guid, Item> GetItems()
        {
            return context.Items;
        }
    }
}
