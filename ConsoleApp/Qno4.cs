using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class EncapPropIndexers
    {
		//Write a program to illustrate encapsulation with properties and indexers.
		

		public EncapPropIndexers(int size) {
			length = size;
			Names = new string[size];
		}
		//Properties
		public int length;
		public string[] Names { get; set; }

		public string this[int i]
		{
			get { return Names[i]; }
			set { Names[i] = value; }
		}

	
	}
}
