using LittleDelights.Data.Contract.Repositories;
using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Data.Repositories
{
    public class ItemRepository : IItemRepository
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
            return context.Items[id];
        }
    }
}
