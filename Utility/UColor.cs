using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CW_Internal_Hack
{
	public class UColor
	{
		private Color color;
		public UColor(float r, float g, float b, float a = 255f)
		{
			this.color = new Color(r / 255f, g / 255f, b / 255f, a / 255f);
		}
		public Color Get()
		{
			return this.color;
		}
	}
}
