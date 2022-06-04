using LittleDelights.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleDelights.Data.Contract.Repositories
{
    public interface IItemRepository
    {
        Guid AddItem(Item item);
        Item GetItem(Guid id);
    }
}
