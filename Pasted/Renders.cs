using CW_Internal_Hack;
using System;
using UnityEngine;

namespace CW_Internal_Hack
{
	// Token: 0x02000005 RID: 5
	public class Renders
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002754 File Offset: 0x00000954
		public static void Initialize()
		{
			Renders.initialized = true;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000275D File Offset: 0x0000095D
		public static void BoxRect(Rect rect, Color color)
		{
			Renders.texture2D_0.SetPixel(0, 0, color);
			Renders.texture2D_0.Apply();
			Renders.color_0 = color;
			GUI.color = color;
			GUI.DrawTexture(rect, Renders.texture2D_0);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002794 File Offset: 0x00000994
		public static void DrawRadarBackground(Rect rect)
		{
			Color color;
			color = new UColor(0, 0, 0, 125).Get();
			Renders.texture2D_0.SetPixel(0, 0, color);
			Renders.texture2D_0.Apply();
			GUI.color = color;
			GUI.DrawTexture(rect, Renders.texture2D_0);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000027EC File Offset: 0x000009EC
		public static void DrawBox(Vector2 pos, Vector2 size, float thick, Color color)
		{
			Renders.BoxRect(new Rect(pos.x, pos.y, size.x, thick), color);
			Renders.BoxRect(new Rect(pos.x, pos.y, thick, size.y), color);
			Renders.BoxRect(new Rect(pos.x + size.x, pos.y, thick, size.y), color);
			Renders.BoxRect(new Rect(pos.x, pos.y + size.y, size.x + thick, thick), color);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002888 File Offset: 0x00000A88
		public static void DrawHealth(Vector2 pos, float health, bool center = false)
		{
			if (center)
			{
				pos -= new Vector2(26f, 0f);
			}
			pos += new Vector2(0f, 18f);
			Renders.BoxRect(new Rect(pos.x, pos.y, 52f, 5f), Color.black);
			pos += new Vector2(1f, 1f);
			Color color = Color.green;
			bool flag = health <= 50f;
			if (flag)
			{
				color = Color.yellow;
			}
			bool flag2 = health <= 25f;
			if (flag2)
			{
				color = Color.red;
			}
			Renders.BoxRect(new Rect(pos.x, pos.y, 0.5f * health, 3f), color);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002960 File Offset: 0x00000B60
		public static void DrawString(Vector2 pos, string text, Color color, bool center = true, int size = 12, bool stroke = true)
		{
			Renders.guistyle_0.fontSize = size;
			Renders.guistyle_0.fontStyle = FontStyle.Bold;
			GUIContent guicontent = new GUIContent(text);
			if (center)
			{
				pos.x -= Renders.guistyle_0.CalcSize(guicontent).x / 2f;
			}
			if (stroke)
			{
				GUI.color = Color.black;
				GUI.Label(new Rect(pos.x - 1f, pos.y, 300f, 25f), guicontent, Renders.guistyle_0);
				GUI.Label(new Rect(pos.x + 1f, pos.y, 300f, 25f), guicontent, Renders.guistyle_0);
				GUI.Label(new Rect(pos.x, pos.y - 1f, 300f, 25f), guicontent, Renders.guistyle_0);
				GUI.Label(new Rect(pos.x, pos.y + 1f, 300f, 25f), guicontent, Renders.guistyle_0);
			}
			GUI.color = color;
			GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Renders.guistyle_0);
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002AB0 File Offset: 0x00000CB0
		public static void DrawWeapon(Vector2 pos, string text, Color color, bool center = true, int size = 12, bool stroke = true)
		{
			Renders.guistyle_0.fontSize = size;
			Renders.guistyle_0.fontStyle = FontStyle.Bold;
			GUIContent guicontent = new GUIContent(text);
			if (center)
			{
				pos.x -= Renders.guistyle_0.CalcSize(guicontent).x / 2f;
			}
			pos += new Vector2(0f, 21f);
			if (stroke)
			{
				GUI.color = Color.black;
				GUI.Label(new Rect(pos.x - 1f, pos.y, 300f, 25f), guicontent, Renders.guistyle_0);
				GUI.Label(new Rect(pos.x + 1f, pos.y, 300f, 25f), guicontent, Renders.guistyle_0);
				GUI.Label(new Rect(pos.x, pos.y - 1f, 300f, 25f), guicontent, Renders.guistyle_0);
				GUI.Label(new Rect(pos.x, pos.y + 1f, 300f, 25f), guicontent, Renders.guistyle_0);
			}
			GUI.color = color;
			GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Renders.guistyle_0);
		}

		// Token: 0x04000006 RID: 6
		public static bool initialized = false;

		// Token: 0x04000007 RID: 7
		private static Color color_0;

		// Token: 0x04000008 RID: 8
		private static GUIStyle guistyle_0 = new GUIStyle(GUI.skin.label);

		// Token: 0x04000009 RID: 9
		private static Texture2D texture2D_0 = new Texture2D(1, 1);
	}
}
