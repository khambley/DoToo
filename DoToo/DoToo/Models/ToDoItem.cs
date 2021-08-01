﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DoToo.Models
{
	public class ToDoItem
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public bool Completed { get; set; }
		public DateTime DueDate { get; set; }

	}
}