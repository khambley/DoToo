using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoToo.Repositories
{
	public interface IToDoItemRepository
	{
		event EventHandler<ToDoItem> OnItemAdded;
		event EventHandler<ToDoItem> OnItemUpdated;

		Task<List<ToDoItem>> GetItems();
		Task AddItem(ToDoItem item);
		Task UpdateItem(ToDoItem item);
		Task AddOrUpdate(ToDoItem item);

		//TODO: Add a DeleteItem method pg.50
	}
}
