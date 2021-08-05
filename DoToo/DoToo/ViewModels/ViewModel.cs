using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DoToo.ViewModels
{
	// not meant to be instantiated on its own, so it's marked as abstract.
	// ViewModel is a base class for all the other VMs. pg. 58
	// implements INotifyPropertyChanged in System.ComponentModel in .NET base class library
	public abstract class ViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(params string[] propertyNames)
		{
			foreach (var propertyName in propertyNames)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public INavigation Navigation { get; set; }
	}
}
