using DoToo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace DoToo.Repositories
{
	public class ToDoItemRepository : IToDoItemRepository
	{
		private SQLiteAsyncConnection connection;
		private async Task CreateConnection()
		{
			//check if we already have a connection
			if(connection != null)
			{
				return;
			}

			//Xamarin finds the closet match to this folder on each platform that is targeted. pg.55
			var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var databasePath = Path.Combine(documentPath, "ToDoItems.db");

			//store the reference to the connection
			connection = new SQLiteAsyncConnection(databasePath);

			await connection.CreateTableAsync<ToDoItem>();

			if (await connection.Table<ToDoItem>().CountAsync() == 0)
			{
				await connection.InsertAsync(new ToDoItem()
				{
					Title = "Welcome to DoToo",
					DueDate = DateTime.Now
				});
			}
		}

		//used to notify subscribers of that list if items have been added or updated.
		public event EventHandler<ToDoItem> OnItemAdded;
		public event EventHandler<ToDoItem> OnItemUpdated;

		public async Task<List<ToDoItem>> GetItems()
		{
			await CreateConnection();
			return await connection.Table<ToDoItem>().ToListAsync();
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
