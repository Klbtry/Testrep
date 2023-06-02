using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.NewFolder1
{
    internal class Todomod: INotifyPropertyChanged
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

		private string task;
        private bool IsDone;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Task
		{
			get { return task; }
			set {
                if (task == value) return;
                task = value;
                Onpropchanged("Task");
            }


		}
		public bool isDone
		{ get { return IsDone; }
		  set { if (IsDone == value) return;
				IsDone = value;
				Onpropchanged("isDone");
			}
		}

		protected virtual void Onpropchanged(string propertyName = "")

		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

			
		}



	}
}
