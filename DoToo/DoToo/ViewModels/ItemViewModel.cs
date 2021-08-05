using DoToo.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoToo.ViewModels
{
	public class ItemViewModel : ViewModel
	{
		private readonly ToDoItemRepository repository;

		public ItemViewModel(ToDoItemRepository repository)
		{
			this.repository = repository;
		}
	}
}
