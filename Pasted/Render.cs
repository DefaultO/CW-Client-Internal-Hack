using System;
using System.Collections.Generic;
using UnityEngine;

namespace Discord
{
	// Token: 0x0200001B RID: 27
	public static class Render
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000CE70 File Offset: 0x0000B070
		// (set) Token: 0x060000DA RID: 218 RVA: 0x0000CE77 File Offset: 0x0000B077
		public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000DB RID: 219 RVA: 0x0000CE80 File Offset: 0x0000B080
		// (set) Token: 0x060000DC RID: 220 RVA: 0x0000CE97 File Offset: 0x0000B097
		public static Color Color
		{
			get
			{
				return GUI.color;
			}
			set
			{
				GUI.color = value;
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000CEA1 File Offset: 0x0000B0A1
		/*public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawLine(from, to, thickness);
		}*/

		// Token: 0x060000DE RID: 222 RVA: 0x0000CEB4 File Offset: 0x0000B0B4
		/*public static void DrawLine(Vector2 from, Vector2 to, float thickness)
		{
			Vector2 normalized = (to - from).normalized;
			float num = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
			GUIUtility.RotateAroundPivot(num, from);
			Render.DrawBox(from, Vector2.right * (from - to).magnitude, thickness, false);
			GUIUtility.RotateAroundPivot(-num, from);
		}*/

		// Token: 0x060000DF RID: 223 RVA: 0x0000CF20 File Offset: 0x0000B120
		/*public static void DrawBox(float x, float y, float w, float h, Color color)
		{
			Render.DrawLine(new Vector2(x, y), new Vector2(x + w, y), 1f, color);
			Render.DrawLine(new Vector2(x, y), new Vector2(x, y + h), 1f, color);
			Render.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), 1f, color);
			Render.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), 1f, color);
		}*/

		// Token: 0x060000E0 RID: 224 RVA: 0x0000CFAA File Offset: 0x0000B1AA
		/*public static void DrawBox(Vector2 position, Vector2 size, float thickness, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawBox(position, size, thickness, centered);
		}*/

		// Token: 0x060000E1 RID: 225 RVA: 0x0000CFC0 File Offset: 0x0000B1C0
		/*public static void DrawBox(Vector2 position, Vector2 size, float thickness, bool centered = true)
		{
			Vector2 vector = centered ? (position - size / 2f) : position;
			GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
		}*/

		// Token: 0x060000E2 RID: 226 RVA: 0x0000D082 File Offset: 0x0000B282
		/*public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawCross(position, size, thickness);
		}*/

		// Token: 0x060000E3 RID: 227 RVA: 0x0000D098 File Offset: 0x0000B298
		/*public static void DrawCross(Vector2 position, Vector2 size, float thickness)
		{
			GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
		}*/

		// Token: 0x060000E4 RID: 228 RVA: 0x0000D106 File Offset: 0x0000B306
		/*public static void DrawDot(Vector2 position, Color color)
		{
			Render.Color = color;
			Render.DrawDot(position);
		}*/

		// Token: 0x060000E5 RID: 229 RVA: 0x0000D117 File Offset: 0x0000B317
		/*public static void DrawDot(Vector2 position)
		{
			Render.DrawBox(position - Vector2.one, Vector2.one * 2f, 1f, true);
		}*/

		// Token: 0x060000E6 RID: 230 RVA: 0x0000D140 File Offset: 0x0000B340
		/*public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawString(position, label, centered);
		}*/

		// Token: 0x060000E7 RID: 231 RVA: 0x0000D154 File Offset: 0x0000B354
		/*public static void DrawString(Vector2 position, string label, bool centered = true)
		{
			GUIContent guicontent = new GUIContent(label);
			Vector2 vector = Render.StringStyle.CalcSize(guicontent);
			Vector2 vector2 = centered ? (position - vector / 2f) : position;
			GUI.Label(new Rect(vector2, vector), guicontent);
		}*/

		// Token: 0x060000E8 RID: 232 RVA: 0x0000D19B File Offset: 0x0000B39B
		/*public static void DrawCircle(Vector2 position, float radius, int numSides, bool centered = true, float thickness = 1f)
		{
			Render.DrawCircle(position, radius, numSides, Color.white, centered, thickness);
		}*/

		// Token: 0x060000E9 RID: 233 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
		/*public static void DrawCircle(Vector2 position, float radius, int numSides, Color color, bool centered = true, float thickness = 1f)
		{
			bool flag = Render.ringDict.ContainsKey(numSides);
			Render.RingArray ringArray;
			if (flag)
			{
				ringArray = Render.ringDict[numSides];
			}
			else
			{
				ringArray = (Render.ringDict[numSides] = new Render.RingArray(numSides));
			}
			Vector2 vector = centered ? position : (position + Vector2.one * radius);
			for (int i = 0; i < numSides - 1; i++)
			{
				Render.DrawLine(vector + ringArray.Positions[i] * radius, vector + ringArray.Positions[i + 1] * radius, thickness, color);
			}
			Render.DrawLine(vector + ringArray.Positions[0] * radius, vector + ringArray.Positions[ringArray.Positions.Length - 1] * radius, thickness, color);
		}*/

		// Token: 0x04000096 RID: 150
		private static Dictionary<int, Render.RingArray> ringDict = new Dictionary<int, Render.RingArray>();

		// Token: 0x0200002C RID: 44
		private class RingArray
		{
			// Token: 0x1700002C RID: 44
			// (get) Token: 0x0600012D RID: 301 RVA: 0x0000EED3 File Offset: 0x0000D0D3
			// (set) Token: 0x0600012E RID: 302 RVA: 0x0000EEDB File Offset: 0x0000D0DB
			public Vector2[] Positions { get; private set; }

			// Token: 0x0600012F RID: 303 RVA: 0x0000EEE4 File Offset: 0x0000D0E4
			public RingArray(int numSegments)
			{
				this.Positions = new Vector2[numSegments];
				float num = 360f / (float)numSegments;
				for (int i = 0; i < numSegments; i++)
				{
					float num2 = 0.0174532924f * num * (float)i;
					this.Positions[i] = new Vector2(Mathf.Sin(num2), Mathf.Cos(num2));
				}
			}
		}
	}
}
