using System;
using UnityEngine;

namespace Discord
{
	// Token: 0x0200000E RID: 14
	public static class Render33
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000079 RID: 121 RVA: 0x00009C2E File Offset: 0x00007E2E
		// (set) Token: 0x0600007A RID: 122 RVA: 0x00009C35 File Offset: 0x00007E35
		public static GUIStyle StringStyle { get; set; } = new GUIStyle(GUI.skin.label);

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00009C40 File Offset: 0x00007E40
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00009C57 File Offset: 0x00007E57
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

		// Token: 0x0600007D RID: 125 RVA: 0x00009C61 File Offset: 0x00007E61
		/*public static void Circle(float X, float Y, float radius)
		{
			Render.DrawBox(X - radius / 2f, Y - radius / 2f, radius, radius, Color.red);
		}*/

		// Token: 0x0600007E RID: 126 RVA: 0x00009C83 File Offset: 0x00007E83
		/*public static void DrawLine(Vector2 from, Vector2 to, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawLine(from, to, thickness);
		}*/

		// Token: 0x0600007F RID: 127 RVA: 0x00009C98 File Offset: 0x00007E98
		/*public static void DrawLine(Vector2 from, Vector2 to, float thickness)
		{
			Vector2 normalized = (to - from).normalized;
			float num = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
			GUIUtility.RotateAroundPivot(num, from);
			Render.DrawBox(from, Vector2.right * (from - to).magnitude, thickness, false);
			GUIUtility.RotateAroundPivot(-num, from);
		}*/

		// Token: 0x06000080 RID: 128 RVA: 0x00009D04 File Offset: 0x00007F04
		/*public static void DrawBox(float x, float y, float w, float h, Color color)
		{
			Render.DrawLine(new Vector2(x, y), new Vector2(x + w, y), 1f, color);
			Render.DrawLine(new Vector2(x, y), new Vector2(x, y + h), 1f, color);
			Render.DrawLine(new Vector2(x + w, y), new Vector2(x + w, y + h), 1f, color);
			Render.DrawLine(new Vector2(x, y + h), new Vector2(x + w, y + h), 1f, color);
		}*/

		// Token: 0x06000081 RID: 129 RVA: 0x00009D8E File Offset: 0x00007F8E
		/*public static void DrawBox(Vector2 position, Vector2 size, float thickness, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawBox(position, size, thickness, centered);
		}*/

		// Token: 0x06000082 RID: 130 RVA: 0x00009DA4 File Offset: 0x00007FA4
		/*public static void DrawBox(Vector2 position, Vector2 size, float thickness, bool centered = true)
		{
			if (centered)
			{
			}
			GUI.DrawTexture(new Rect(position.x, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x + size.x, position.y, thickness, size.y), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y + size.y, size.x + thickness, thickness), Texture2D.whiteTexture);
		}*/

		// Token: 0x06000083 RID: 131 RVA: 0x00009E55 File Offset: 0x00008055
		/*public static void DrawCross(Vector2 position, Vector2 size, float thickness, Color color)
		{
			Render.Color = color;
			Render.DrawCross(position, size, thickness);
		}*/

		// Token: 0x06000084 RID: 132 RVA: 0x00009E68 File Offset: 0x00008068
		/*public static void DrawCross(Vector2 position, Vector2 size, float thickness)
		{
			GUI.DrawTexture(new Rect(position.x - size.x / 2f, position.y, size.x, thickness), Texture2D.whiteTexture);
			GUI.DrawTexture(new Rect(position.x, position.y - size.y / 2f, thickness, size.y), Texture2D.whiteTexture);
		}*/

		// Token: 0x06000085 RID: 133 RVA: 0x00009ED6 File Offset: 0x000080D6
		/*public static void DrawString(Vector2 position, string label, Color color, bool centered = true)
		{
			Render.Color = color;
			Render.DrawString(position, label, centered);
		}*/

		// Token: 0x06000086 RID: 134 RVA: 0x00009EE9 File Offset: 0x000080E9
		internal static void DrawLabel(Rect rect, string label, Color color)
		{
			Render.Color = color;
			GUI.Label(rect, label);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00009EFC File Offset: 0x000080FC
		/*public static void DrawString(Vector2 position, string label, bool centered = true)
		{
			GUIContent guicontent = new GUIContent(label);
			Vector2 vector = Render.StringStyle.CalcSize(guicontent);
			GUI.Label(new Rect(centered ? (position - vector / 2f) : position, vector), guicontent);
		}*/

		// Token: 0x0400005E RID: 94
		public static Material DrawMaterial;
	}
}
