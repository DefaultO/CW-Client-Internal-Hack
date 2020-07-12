using System;
using System.Reflection;
using UnityEngine;

// Token: 0x02000003 RID: 3
public static class Drawing1
{
	// Token: 0x06000004 RID: 4 RVA: 0x000020DC File Offset: 0x000002DC
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
				texture2D = Drawing1.aaLineTex;
				Material material = Drawing1.blendMaterial;
			}
			else
			{
				texture2D = Drawing1.lineTex;
				Material material = Drawing1.blitMaterial;
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
			GUI.DrawTexture(Drawing1.lineRect, texture2D);
			GL.PopMatrix();
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002364 File Offset: 0x00000564
	public static void DrawBezierLine(Vector2 start, Vector2 startTangent, Vector2 end, Vector2 endTangent, Color color, float width, bool antiAlias, int segments)
	{
		Vector2 pointA = Drawing1.CubeBezier(start, startTangent, end, endTangent, 0f);
		for (int i = 1; i < segments + 1; i++)
		{
			Vector2 vector = Drawing1.CubeBezier(start, startTangent, end, endTangent, (float)i / (float)segments);
			Drawing1.DrawLine(pointA, vector, color, width, antiAlias);
			pointA = vector;
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000023B8 File Offset: 0x000005B8
	private static Vector2 CubeBezier(Vector2 s, Vector2 st, Vector2 e, Vector2 et, float t)
	{
		float num = 1f - t;
		return num * num * num * s + 3f * num * num * t * st + 3f * num * t * t * et + t * t * t * e;
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002420 File Offset: 0x00000620
	public static void Initialize()
	{
		bool flag = Drawing1.lineTex == null;
		if (flag)
		{
			Drawing1.lineTex = new Texture2D(1, 1, TextureFormat.ARGB32, false);
			Drawing1.lineTex.SetPixel(0, 1, Color.white);
			Drawing1.lineTex.Apply();
		}
		bool flag2 = Drawing1.aaLineTex == null;
		if (flag2)
		{
			Drawing1.aaLineTex = new Texture2D(1, 3, TextureFormat.ARGB32, false);
			Drawing1.aaLineTex.SetPixel(0, 0, new Color(1f, 1f, 1f, 0f));
			Drawing1.aaLineTex.SetPixel(0, 1, Color.white);
			Drawing1.aaLineTex.SetPixel(0, 2, new Color(1f, 1f, 1f, 0f));
			Drawing1.aaLineTex.Apply();
		}
		Drawing1.blitMaterial = (Material)typeof(GUI).GetMethod("get_blitMaterial", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
		Drawing1.blendMaterial = (Material)typeof(GUI).GetMethod("get_blendMaterial", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
	}

	// Token: 0x04000001 RID: 1
	private static Texture2D aaLineTex = null;

	// Token: 0x04000002 RID: 2
	private static Texture2D lineTex = null;

	// Token: 0x04000003 RID: 3
	private static Material blitMaterial = null;

	// Token: 0x04000004 RID: 4
	private static Material blendMaterial = null;

	// Token: 0x04000005 RID: 5
	private static Rect lineRect = new Rect(0f, 0f, 1f, 1f);
}

