using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoToo.Repositories
{
	public class ToDoItemRepository : IToDoItemRepository
	{
		//used to notify subscribers of that list if items have been added or updated.
		public event EventHandler<ToDoItem> OnItemAdded;
		public event EventHandler<ToDoItem> OnItemUpdated;

		public async Task<List<ToDoItem>> GetItems()
		{
			return null; // Just to make it build
		}
		public async Task AddItem(ToDoItem item)
		{
		}
		public async Task UpdateItem(ToDoItem item)
		{
		}

		public async Task AddOrUpdate(ToDoItem item)
		{
			if (item.Id == 0)
			{
				await AddItem(item);
			}
			else
			{
				await UpdateItem(item);
			}
		}
	}
}
