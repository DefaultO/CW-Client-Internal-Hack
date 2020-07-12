using CW_Internal_Hack;
using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class Rendering
{
	// Token: 0x06000020 RID: 32 RVA: 0x00002C48 File Offset: 0x00000E48
	public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width, bool antiAlias)
	{
		float num = pointB.x - pointA.x;
		float num2 = pointB.y - pointA.y;
		float num3 = Mathf.Sqrt(num * num + num2 * num2);
		bool flag = num3 < 0.001f;
		if (!flag)
		{
			Texture2D texture2D;
			if (antiAlias)
			{
				width *= 3f;
				texture2D = Rendering.aaLineTex;
				Material material = Rendering.blendMaterial;
			}
			else
			{
				texture2D = Rendering.lineTex;
				Material material = Rendering.blitMaterial;
			}
			float num4 = width * num2 / num3;
			float num5 = width * num / num3;
			Matrix4x4 identity = Matrix4x4.identity;
			identity.m00 = num;
			identity.m01 = -num4;
			identity.m03 = pointA.x + 0.5f * num4;
			identity.m10 = num2;
			identity.m11 = num5;
			identity.m13 = pointA.y - 0.5f * num5;
			GL.PushMatrix();
			GL.MultMatrix(identity);
			GUI.color = color;
			GUI.DrawTexture(Rendering.lineRect, texture2D);
			GL.PopMatrix();
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002D50 File Offset: 0x00000F50
	public static void DrawLine3(Vector2 pointA, Vector2 pointB, Color color, float width, bool antiAlias)
	{
		float num = pointB.x - pointA.x;
		float num2 = pointB.y - pointA.y;
		float num3 = Mathf.Sqrt(num * num + num2 * num2);
		bool flag = num3 < 0.001f;
		if (!flag)
		{
			Texture2D texture2D;
			if (antiAlias)
			{
				width *= 3f;
				texture2D = Rendering.aaLineTex;
				Material material = Rendering.blendMaterial;
			}
			else
			{
				texture2D = Rendering.lineTex;
				Material material = Rendering.blitMaterial;
			}
			float num4 = width * num2 / num3;
			float num5 = width * num / num3;
			Matrix4x4 identity = Matrix4x4.identity;
			identity.m00 = num;
			identity.m01 = -num4;
			identity.m03 = pointA.x + 0.5f * num4;
			identity.m10 = num2;
			identity.m11 = num5;
			identity.m13 = pointA.y - 0.5f * num5;
			GL.PushMatrix();
			GL.MultMatrix(identity);
			GUI.color = color;
			GUI.DrawTexture(Rendering.lineRect, texture2D);
			GL.PopMatrix();
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002E58 File Offset: 0x00001058
	private static Vector2 CubeBezier(Vector2 s, Vector2 st, Vector2 e, Vector2 et, float t)
	{
		float num = 1f - t;
		return num * num * num * s + 3f * num * num * t * st + 3f * num * t * t * et + t * t * t * e;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002EC0 File Offset: 0x000010C0
	public static void DrawRadarBackground(Rect rect)
	{
		Color color;
		color = new UColor(30, 30, 30).Get();
		Rendering.texture2D_0.SetPixel(0, 0, color);
		Rendering.texture2D_0.Apply();
		GUI.color = color;
		GUI.DrawTexture(rect, Rendering.texture2D_0);
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002F18 File Offset: 0x00001118
	public static void DrawString3(Vector2 pos, string text, Color color, bool center = true, int size = 12, bool stroke = true)
	{
		Rendering.guistyle_0.fontSize = size;
		Rendering.guistyle_0.fontStyle = FontStyle.Bold;
		GUIContent guicontent = new GUIContent(text);
		if (center)
		{
			pos.x -= Rendering.guistyle_0.CalcSize(guicontent).x / 2f;
		}
		if (stroke)
		{
			GUI.color = Color.black;
			GUI.Label(new Rect(pos.x - 1f, pos.y, 300f, 25f), guicontent, Rendering.guistyle_0);
			GUI.Label(new Rect(pos.x + 1f, pos.y, 300f, 25f), guicontent, Rendering.guistyle_0);
			GUI.Label(new Rect(pos.x, pos.y - 1f, 300f, 25f), guicontent, Rendering.guistyle_0);
			GUI.Label(new Rect(pos.x, pos.y + 1f, 300f, 25f), guicontent, Rendering.guistyle_0);
		}
		GUI.color = color;
		GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Rendering.guistyle_0);
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00003068 File Offset: 0x00001268
	public static void DrawLine100(Vector2 startPos, Vector2 endPos, Color color, float thickness)
	{
		bool flag = Rendering.texture != null;
		if (flag)
		{
			Rendering.texture.SetPixel(0, 0, color);
			Rendering.texture.wrapMode = 0;
			Rendering.texture.Apply();
		}
		Rendering.DrawLineStretched(startPos, endPos, Rendering.texture, thickness);
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000030BC File Offset: 0x000012BC
	public static void FillRGB(Vector2 point, float width, float height, Color color, float alpha)
	{
		Texture2D texture2D = new Texture2D(1, 1);
		Color color2 = color;
		color2.a = alpha;
		Color[] pixels = texture2D.GetPixels();
		for (int i = 0; i < pixels.Length; i++)
		{
			pixels[i] = color2;
		}
		texture2D.SetPixels(pixels);
		texture2D.Apply();
		GUI.DrawTexture(new Rect(point.x, point.y, width, height), texture2D);
	}

	// Token: 0x06000027 RID: 39 RVA: 0x0000312C File Offset: 0x0000132C
	public static void DrawLine6(Vector2 pointA, Vector2 pointB, Color color)
	{
		Rendering.lineMaterial.SetPass(0);
		GL.Begin(1);
		GL.Color(color);
		GL.Vertex3(pointA.x, pointA.y, 0f);
		GL.Vertex3(pointB.x, pointB.y, 0f);
		GL.End();
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00003188 File Offset: 0x00001388
	public static void DrawTriangle(Vector2 Point, int left, int right, int height, Color color)
	{
		Rendering.DrawLine6(Point, new Vector2(Point.x - (float)left, Point.y + (float)height), color);
		Rendering.DrawLine6(Point, new Vector2(Point.x + (float)right, Point.y + (float)height), color);
		Rendering.DrawLine6(new Vector2(Point.x - (float)left, Point.y + (float)height), new Vector2(Point.x + (float)right, Point.y + (float)height), color);
	}

	// Token: 0x06000029 RID: 41 RVA: 0x0000320C File Offset: 0x0000140C
	public static void BoxRect(Rect rect, Color color)
	{
		bool flag = color != Rendering.color_0;
		if (flag)
		{
			Rendering.texture2D_0.SetPixel(0, 0, color);
			Rendering.texture2D_0.Apply();
			Rendering.color_0 = color;
		}
		GUI.DrawTexture(rect, Rendering.texture2D_0);
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00003256 File Offset: 0x00001456
	/*public static void DrawCircle(Vector2 center, int radius, Color color, float width, int segmentsPerQuarter)
	{
		Rendering.DrawCircle(center, radius, color, width, false, segmentsPerQuarter);
	}*/

	// Token: 0x0600002B RID: 43 RVA: 0x00003268 File Offset: 0x00001468
	public static void DrawBezierLine(Vector2 start, Vector2 startTangent, Vector2 end, Vector2 endTangent, Color color, float width, bool antiAlias, int segments)
	{
		Vector2 pointA = Rendering.CubeBezier(start, startTangent, end, endTangent, 0f);
		for (int i = 1; i < segments + 1; i++)
		{
			Vector2 vector = Rendering.CubeBezier(start, startTangent, end, endTangent, (float)i / (float)segments);
			Rendering.DrawLine3(pointA, vector, color, width, antiAlias);
			pointA = vector;
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000032BC File Offset: 0x000014BC
	/*public static void DrawCircle(Vector2 center, int radius, Color color, float width, bool antiAlias, int segmentsPerQuarter)
	{
		float num = (float)radius / 2f;
		Vector2 vector;
		vector..ctor(center.x, center.y - (float)radius);
		Vector2 endTangent;
		endTangent..ctor(center.x - num, center.y - (float)radius);
		Vector2 startTangent;
		startTangent..ctor(center.x + num, center.y - (float)radius);
		Vector2 vector2;
		vector2..ctor(center.x + (float)radius, center.y);
		Vector2 endTangent2;
		endTangent2..ctor(center.x + (float)radius, center.y - num);
		Vector2 startTangent2;
		startTangent2..ctor(center.x + (float)radius, center.y + num);
		Vector2 vector3;
		vector3..ctor(center.x, center.y + (float)radius);
		Vector2 startTangent3;
		startTangent3..ctor(center.x - num, center.y + (float)radius);
		Vector2 endTangent3;
		endTangent3..ctor(center.x + num, center.y + (float)radius);
		Vector2 vector4;
		vector4..ctor(center.x - (float)radius, center.y);
		Vector2 startTangent4;
		startTangent4..ctor(center.x - (float)radius, center.y - num);
		Vector2 endTangent4;
		endTangent4..ctor(center.x - (float)radius, center.y + num);
		Rendering.DrawBezierLine(vector, startTangent, vector2, endTangent2, color, width, antiAlias, segmentsPerQuarter);
		Rendering.DrawBezierLine(vector2, startTangent2, vector3, endTangent3, color, width, antiAlias, segmentsPerQuarter);
		Rendering.DrawBezierLine(vector3, startTangent3, vector4, endTangent4, color, width, antiAlias, segmentsPerQuarter);
		Rendering.DrawBezierLine(vector4, startTangent4, vector, endTangent, color, width, antiAlias, segmentsPerQuarter);
	}*/

	// Token: 0x0600002D RID: 45 RVA: 0x00003438 File Offset: 0x00001638
	public static void DrawBar(Rect pos, float value, float maxValue, Color color)
	{
		Rendering.DrawBox1(new Vector2(pos.x, pos.y), new Vector2(pos.width, pos.height), Color.black);
		Rendering.DrawBox1(new Vector2(pos.x, pos.y), new Vector2(value * pos.width / maxValue, pos.height), color);
		Rendering.DrawBoxOutlines(new Vector2(pos.x - 2f, pos.y - 2f), new Vector2(pos.width + 3f, pos.height + 2f), 2f, Color.black);
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000034F8 File Offset: 0x000016F8
	public static void DrawLine2(Vector2 startPos, Vector2 endPos, Color color, float thickness)
	{
		bool flag = Rendering.texture != null;
		if (flag)
		{
			Rendering.texture.SetPixel(0, 0, color);
			Rendering.texture.wrapMode = 0;
			Rendering.texture.Apply();
		}
		Rendering.DrawLineStretched(startPos, endPos, Rendering.texture, thickness);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x0000354C File Offset: 0x0000174C
	/*static Rendering()
	{
		Rendering.outlineColor = new Color(0f, 0f, 0f, 1f);
		Rendering.texture = new Texture2D(1, 1);
		Rendering.style = new GUIStyle(GUI.skin.label)
		{
			fontSize = 12
		};
		Rendering.outlineStyle = new GUIStyle(GUI.skin.label)
		{
			fontSize = 12
		};
		Rendering.tahoma = Font.CreateDynamicFontFromOSFont("Tahoma", 12);
	}*/

	// Token: 0x06000030 RID: 48 RVA: 0x000036A0 File Offset: 0x000018A0
	public static void DrawHealth(float x, float y, float health, float maxHealth = 100f, float width = 50f, float height = 5f, float thickness = 1f)
	{
		float num = (width - thickness * 2f) * health / maxHealth;
		bool flag = num < 1f;
		if (flag)
		{
			num = 1f;
		}
		Color color = Color.green;
		bool flag2 = health < maxHealth * 0.6f;
		if (flag2)
		{
			color = Color.yellow;
		}
		bool flag3 = health < maxHealth * 0.3f;
		if (flag3)
		{
			color = Color.red;
		}
		Rendering.RectFilled(x - width / 2f, y - height, width, height, Color.black);
		Rendering.RectFilled(x - width / 2f + thickness, y - height + thickness, num, height - thickness * 2f, color);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x0000374C File Offset: 0x0000194C
	public static Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle)
	{
		return angle * (point - pivot) + pivot;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00003774 File Offset: 0x00001974
	public static void RectOutlined(float x, float y, float width, float height, Color color, float thickness = 1f)
	{
		Rendering.RectFilled(x, y, thickness, height, color);
		Rendering.RectFilled(x + width - thickness, y, thickness, height, color);
		Rendering.RectFilled(x + thickness, y, width - thickness * 2f, thickness, color);
		Rendering.RectFilled(x + thickness, y + height - thickness, width - thickness * 2f, thickness, color);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x000037D8 File Offset: 0x000019D8
	public static void CornerBox(Vector2 Head, float Width, float Height, float thickness, Color color, bool outline)
	{
		int num = (int)(Width / 4f);
		int num2 = num;
		if (outline)
		{
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y - 1f, (float)(num + 2), 3f, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y - 1f, 3f, (float)(num2 + 2), Color.black);
			Rendering.RectFilled(Head.x + Width / 2f - (float)num - 1f, Head.y - 1f, (float)(num + 2), 3f, Color.black);
			Rendering.RectFilled(Head.x + Width / 2f - 1f, Head.y - 1f, 3f, (float)(num2 + 2), Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y + Height - 4f, (float)(num + 2), 3f, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y + Height - (float)num2 - 4f, 3f, (float)(num2 + 2), Color.black);
			Rendering.RectFilled(Head.x + Width / 2f - (float)num - 1f, Head.y + Height - 4f, (float)(num + 2), 3f, Color.black);
			Rendering.RectFilled(Head.x + Width / 2f - 1f, Head.y + Height - (float)num2 - 4f, 3f, (float)(num2 + 3), Color.black);
		}
		Rendering.RectFilled(Head.x - Width / 2f, Head.y, (float)num, 1f, color);
		Rendering.RectFilled(Head.x - Width / 2f, Head.y, 1f, (float)num2, color);
		Rendering.RectFilled(Head.x + Width / 2f - (float)num, Head.y, (float)num, 1f, color);
		Rendering.RectFilled(Head.x + Width / 2f, Head.y, 1f, (float)num2, color);
		Rendering.RectFilled(Head.x - Width / 2f, Head.y + Height - 3f, (float)num, 1f, color);
		Rendering.RectFilled(Head.x - Width / 2f, Head.y + Height - (float)num2 - 3f, 1f, (float)num2, color);
		Rendering.RectFilled(Head.x + Width / 2f - (float)num, Head.y + Height - 3f, (float)num, 1f, color);
		Rendering.RectFilled(Head.x + Width / 2f, Head.y + Height - (float)num2 - 3f, 1f, (float)(num2 + 1), color);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00003AF8 File Offset: 0x00001CF8
	public static void DrawString1(Vector2 pos, string text, Color color, bool center = true, int size = 12, FontStyle fontStyle = FontStyle.Bold, int depth = 1)
	{
		Rendering.style.fontSize = size;
		Rendering.style.richText = true;
		//Rendering.style.font = F
		Rendering.style.normal.textColor = color;
		Rendering.style.fontStyle = fontStyle;
		Rendering.outlineStyle.fontSize = size;
		Rendering.outlineStyle.richText = true;
		//Rendering.outlineStyle.font = Rendering.tahoma;
		Rendering.outlineStyle.normal.textColor = new Color(0f, 0f, 0f, 1f);
		Rendering.outlineStyle.fontStyle = fontStyle;
		GUIContent guicontent = new GUIContent(text);
		GUIContent guicontent2 = new GUIContent(text);
		if (center)
		{
			pos.x -= Rendering.style.CalcSize(guicontent).x / 2f;
		}
		switch (depth)
		{
			case 0:
				GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Rendering.style);
				break;
			case 1:
				GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), guicontent2, Rendering.outlineStyle);
				GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Rendering.style);
				break;
			case 2:
				GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), guicontent2, Rendering.outlineStyle);
				GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), guicontent2, Rendering.outlineStyle);
				GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Rendering.style);
				break;
			case 3:
				GUI.Label(new Rect(pos.x + 1f, pos.y + 1f, 300f, 25f), guicontent2, Rendering.outlineStyle);
				GUI.Label(new Rect(pos.x - 1f, pos.y - 1f, 300f, 25f), guicontent2, Rendering.outlineStyle);
				GUI.Label(new Rect(pos.x, pos.y - 1f, 300f, 25f), guicontent2, Rendering.outlineStyle);
				GUI.Label(new Rect(pos.x, pos.y + 1f, 300f, 25f), guicontent2, Rendering.outlineStyle);
				GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), guicontent, Rendering.style);
				break;
		}
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00003E0C File Offset: 0x0000200C
	/*public static void DrawVerticalHealth(Vector2 Head, float Width, float Height, float health)
	{
		int num = (int)(Width / 4f);
		float num2 = health / Height / 400f;
		bool flag = num2 >= 1f;
		if (flag)
		{
			bool flag2 = num2 < 0f;
			if (flag2)
			{
			}
		}
		bool flag3 = health > 0f;
		if (flag3)
		{
			Color color = Color.green;
			bool flag4 = health < 400f;
			if (flag4)
			{
				color = Color.yellow;
			}
			bool flag5 = health < 300f;
			if (flag5)
			{
				color..ctor(1f, 0.7f, 0.16f, 1f);
			}
			bool flag6 = health < 200f;
			if (flag6)
			{
				color = Color.red;
			}
			bool flag7 = health <= 0f;
			if (flag7)
			{
				color = Color.clear;
			}
			Rendering.RectFilled(Head.x - Width / 2f - 4f, Head.y - 1f, 3f, 1f, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 4f, Head.y, 1f, Height - 2f, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y, 1f, Height - 2f, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 4f, Head.y + Height - 2f, 3f, 1f, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y, -2f, Height - 2f, color);
			Rendering.DrawString1(new Vector2(Head.x, Head.y - 30f), ((int)health).ToString() + "♥", color, true, 10, FontStyle.Bold, 3);
		}
	}*/

	// Token: 0x06000036 RID: 54 RVA: 0x00004010 File Offset: 0x00002210
	public static void RectFilled(float x, float y, float width, float height, Color color)
	{
		bool flag = color != Rendering.textureColor;
		if (flag)
		{
			Rendering.textureColor = color;
			Rendering.texture.SetPixel(0, 0, color);
			Rendering.texture.Apply();
		}
		GUI.DrawTexture(new Rect(x, y, width, height), Rendering.texture);
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00004068 File Offset: 0x00002268
	public static void DrawLineStretched(Vector2 lineStart, Vector2 lineEnd, Texture2D texture, float thickness)
	{
		Vector2 vector = lineEnd - lineStart;
		float num = 57.29578f * Mathf.Atan(vector.y / vector.x);
		bool flag = vector.x < 0f;
		if (flag)
		{
			num += 180f;
		}
		bool flag2 = thickness < 1f;
		if (flag2)
		{
			thickness = 1f;
		}
		int num2 = (int)Mathf.Ceil(thickness / 2f);
		GUIUtility.RotateAroundPivot(num, lineStart);
		GUI.DrawTexture(new Rect(lineStart.x, lineStart.y - (float)num2, vector.magnitude, thickness), texture);
		GUIUtility.RotateAroundPivot(-num, lineStart);
	}

	// Token: 0x06000038 RID: 56 RVA: 0x0000410C File Offset: 0x0000230C
	public static void DrawBox1(Vector2 pos, Vector2 size, Color color)
	{
		bool flag = !Rendering.figTex;
		if (flag)
		{
			Rendering.figTex = new Texture2D(1, 1);
		}
		bool flag2 = color != Rendering.lfgColor;
		if (flag2)
		{
			Rendering.figTex.SetPixel(0, 0, color);
			Rendering.figTex.Apply();
			Rendering.lfgColor = color;
		}
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), Rendering.figTex);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00004194 File Offset: 0x00002394
	public static void DrawBoxOutlines(Vector2 position, Vector2 size, float borderSize, Color color)
	{
		Rendering.DrawBox1(new Vector2(position.x + borderSize, position.y), new Vector2(size.x - 2f * borderSize, borderSize), color);
		Rendering.DrawBox1(new Vector2(position.x, position.y), new Vector2(borderSize, size.y), color);
		Rendering.DrawBox1(new Vector2(position.x + size.x - borderSize, position.y), new Vector2(borderSize, size.y), color);
		Rendering.DrawBox1(new Vector2(position.x + borderSize, position.y + size.y - borderSize), new Vector2(size.x - 2f * borderSize, borderSize), color);
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00004258 File Offset: 0x00002458
	public static void DrawBox(Vector2 pos, Vector2 size, float thick, Color color, bool ducked = false)
	{
		if (ducked)
		{
			size.y *= 0.611f;
			pos.y -= 1.5f;
		}
		Rendering.BoxRect(new Rect(pos.x, pos.y, size.x, thick), color);
		Rendering.BoxRect(new Rect(pos.x, pos.y, thick, size.y), color);
		Rendering.BoxRect(new Rect(pos.x + size.x, pos.y, thick, size.y), color);
		Rendering.BoxRect(new Rect(pos.x, pos.y + size.y, size.x + thick, thick), color);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00004320 File Offset: 0x00002520
	public static void FullBox(Vector2 Head, float Width, float Height, float thickness, int distance, Color color, bool outline = false)
	{
		int num = (int)(Width / 4f);
		if (outline)
		{
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y - 1f, 3f, Height, Color.black);
			Rendering.RectFilled(Head.x + Width / 2f - 1f, Head.y - 1f, 3f, Height, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y - 1f, Width, 3f, Color.black);
			Rendering.RectFilled(Head.x - Width / 2f - 1f, Head.y + Height - 4f, Width, 3f, Color.black);
		}
		Rendering.RectFilled(Head.x - Width / 2f, Head.y, 1f, Height - 2f, color);
		Rendering.RectFilled(Head.x + Width / 2f, Head.y, 1f, Height - 2f, color);
		Rendering.RectFilled(Head.x - Width / 2f, Head.y, Width, 1f, color);
		Rendering.RectFilled(Head.x - Width / 2f, Head.y + Height - 3f, Width, 1f, color);
	}

	// Token: 0x0600003C RID: 60 RVA: 0x000044A4 File Offset: 0x000026A4
	public static void DrawHealth(Vector2 pos, float health, bool center = false)
	{
		if (center)
		{
			pos -= new Vector2(26f, 0f);
		}
		pos -= new Vector2(0f, 8f);
		Rendering.BoxRect(new Rect(pos.x, pos.y, 52f, 5f), Color.black);
		pos += new Vector2(1f, 1f);
		Color color = Color.green;
		bool flag = health <= 60f;
		if (flag)
		{
			color = Color.yellow;
		}
		bool flag2 = health <= 25f;
		if (flag2)
		{
			color = Color.red;
		}
		Rendering.BoxRect(new Rect(pos.x, pos.y, 0.5f * health, 3f), color);
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00004620 File Offset: 0x00002820
	public static void DrawWatermark(string text, Color color, int size = 12)
	{
		Rendering.guistyle_0.fontSize = size;
		Rendering.guistyle_0.normal.textColor = color;
		GUIContent guicontent = new GUIContent(text);
		GUI.Label(new Rect(1f, 1f, 300f, 25f), guicontent, Rendering.guistyle_0);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00004678 File Offset: 0x00002878
	public static void DrawWatermark2(string text, Color color, int size = 12)
	{
		Rendering.guistyle_0.fontSize = size;
		Rendering.guistyle_0.normal.textColor = color;
		GUIContent guicontent = new GUIContent(text);
		GUI.Label(new Rect(250f, 250f, 300f, 25f), guicontent, Rendering.guistyle_0);
	}

	// Token: 0x06000040 RID: 64 RVA: 0x000046D0 File Offset: 0x000028D0
	public static void DrawOutlinedString(Rect rect, string text, Color color)
	{
		GUIStyle guistyle = Rendering.guistyle_0;
		Rendering.guistyle_0.normal.textColor = Color.black;
		float num = rect.x;
		rect.x = num - 1f;
		GUI.Label(rect, text, Rendering.guistyle_0);
		rect.x += 2f;
		GUI.Label(rect, text, Rendering.guistyle_0);
		num = rect.x;
		rect.x = num - 1f;
		num = rect.y;
		rect.y = num - 1f;
		GUI.Label(rect, text, Rendering.guistyle_0);
		rect.y += 2f;
		GUI.Label(rect, text, Rendering.guistyle_0);
		num = rect.y;
		rect.y = num - 1f;
		Rendering.guistyle_0.normal.textColor = color;
		GUI.Label(rect, text, Rendering.guistyle_0);
		Rendering.guistyle_0 = guistyle;
	}

	// Token: 0x0400000A RID: 10
	private static Color color_0;

	// Token: 0x0400000B RID: 11
	private static GUIStyle guistyle_0 = new GUIStyle(GUI.skin.label);

	// Token: 0x0400000C RID: 12
	private static Texture2D texture2D_0 = new Texture2D(1, 1);

	// Token: 0x0400000D RID: 13
	private static Texture2D figTex;

	// Token: 0x0400000E RID: 14
	private static Color lfgColor;

	// Token: 0x0400000F RID: 15
	private static Color textureColor;

	// Token: 0x04000011 RID: 17
	private static Texture2D aaLineTex = null;

	// Token: 0x04000012 RID: 18
	private static Texture2D lineTex = null;

	// Token: 0x04000013 RID: 19
	private static Material blitMaterial = null;

	// Token: 0x04000014 RID: 20
	private static Material blendMaterial = null;

	// Token: 0x04000015 RID: 21
	private static Rect lineRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x04000016 RID: 22
	private static Material lineMaterial = null;

	// Token: 0x04000017 RID: 23
	private static Color outlineColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x04000018 RID: 24
	private static Texture2D texture = new Texture2D(1, 1);

	// Token: 0x04000019 RID: 25
	private static GUIStyle style = new GUIStyle(GUI.skin.label)
	{
		fontSize = 12
	};

	// Token: 0x0400001A RID: 26
	private static GUIStyle outlineStyle = new GUIStyle(GUI.skin.label)
	{
		fontSize = 12
	};
}
