using System;
using UnityEngine;

namespace CW_Internal_Hack
{
    class Draw
	{
		#region Old Drawing Method
		public static void Pixel(Vector2 Position, Color color, float thickness)
		{
			if (Draw._coloredLineTexture == null || Draw._coloredLineColor != color)
			{
				Draw._coloredLineColor = color;
				Draw._coloredLineTexture = new Texture2D(1, 1);
				Draw._coloredLineTexture.SetPixel(0, 0, Draw._coloredLineColor);
				Draw._coloredLineTexture.wrapMode = 0;
				Draw._coloredLineTexture.Apply();
			}
			if (thickness < 1f)
			{
				thickness = 1f;
			}
			float num = Mathf.Ceil(thickness / 2f);
			GUI.DrawTexture(new Rect(Position.x, Position.y - num, thickness, thickness), Draw._coloredLineTexture);
		}

		public static void Line(Vector2 lineStart, Vector2 lineEnd, Color color, int thickness)
		{
			if (_coloredLineTexture == null || _coloredLineColor != color)
			{
				_coloredLineColor = color;
				_coloredLineTexture = new Texture2D(1, 1);
				_coloredLineTexture.SetPixel(0, 0, _coloredLineColor);
				_coloredLineTexture.wrapMode = 0;
				_coloredLineTexture.Apply();
			}

			var vector = lineEnd - lineStart;
			float pivot = 57.29578f * Mathf.Atan(vector.y / vector.x);
			if (vector.x < 0f)
			{
				pivot += 180f;
			}

			if (thickness < 1)
			{
				thickness = 1;
			}

			int yOffset = (int)Mathf.Ceil((float)(thickness / 2));

			GUIUtility.RotateAroundPivot(pivot, lineStart);
			GUI.DrawTexture(new Rect(lineStart.x, lineStart.y - (float)yOffset, vector.magnitude, (float)thickness), _coloredLineTexture);
			GUIUtility.RotateAroundPivot(-pivot, lineStart);
		}

		private static Texture2D _coloredLineTexture;

		private static Color _coloredLineColor;
		#endregion

		[Flags]
		public enum TextFlags
		{
			TEXT_FLAG_NONE = 0,
			TEXT_FLAG_CENTERED = 1,
			TEXT_FLAG_OUTLINED = 2,
			TEXT_FLAG_DROPSHADOW = 3
		}

		private static Texture2D drawingTex = null;
		private static Color lastTexColor;
		private static Material lineMaterial;

		public static void DrawString(Vector2 pos, Color color, TextFlags flags, string text)
		{
			bool center = (flags & TextFlags.TEXT_FLAG_CENTERED) == TextFlags.TEXT_FLAG_CENTERED;
			if ((flags & TextFlags.TEXT_FLAG_OUTLINED) == TextFlags.TEXT_FLAG_OUTLINED)
			{
				DrawStringInternal(pos + new Vector2(1f, 0f), Color.black, text, center);
				DrawStringInternal(pos + new Vector2(0f, 1f), Color.black, text, center);
				DrawStringInternal(pos + new Vector2(0f, -1f), Color.black, text, center);
			}
			if ((flags & TextFlags.TEXT_FLAG_DROPSHADOW) == TextFlags.TEXT_FLAG_DROPSHADOW)
			{
				DrawStringInternal(pos + new Vector2(1f, 1f), Color.black, text, center);
			}
			DrawStringInternal(pos, color, text, center);
		}

		public static Vector2 TextBounds(string text)
		{
			return new GUIStyle(GUI.skin.label)
			{
				fontSize = 13
			}.CalcSize(new GUIContent(text));
		}

		private static void DrawStringInternal(Vector2 pos, Color color, string text, bool center)
		{
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.label);
			gUIStyle.normal.textColor = color;
			gUIStyle.fontSize = 13;
			if (center)
			{
				pos.x -= gUIStyle.CalcSize(new GUIContent(text)).x / 2f;
			}
			GUI.Label(new Rect(pos.x, pos.y, 800f, 40f), text, gUIStyle);
		}

		public static void DrawBox(Vector2 pos, Vector2 size, Color color)
		{
			if (!drawingTex)
			{
				drawingTex = new Texture2D(1, 1);
			}
			if (color != lastTexColor)
			{
				drawingTex.SetPixel(0, 0, color);
				drawingTex.Apply();
				lastTexColor = color;
			}
			GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), drawingTex);
		}

		// Only works on older Unity Games. Get used to use something different than that.
		public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color)
		{
			if (!lineMaterial)
			{
				lineMaterial = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {   BindChannels { Bind \"Color\",color }   Blend SrcAlpha OneMinusSrcAlpha   ZWrite Off Cull Off Fog { Mode Off }} } }");
				lineMaterial.hideFlags = HideFlags.HideAndDontSave;
				lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
			}
			lineMaterial.SetPass(0);
			GL.Begin(1);
			GL.Color(color);
			GL.Vertex3(pointA.x, pointA.y, 0f);
			GL.Vertex3(pointB.x, pointB.y, 0f);
			GL.End();
		}

		public static void DrawBoxOutlines(Vector2 position, Vector2 size, float borderSize, Color color)
		{
			DrawBox(new Vector2(position.x + borderSize, position.y), new Vector2(size.x - 2f * borderSize, borderSize), color);
			DrawBox(new Vector2(position.x, position.y), new Vector2(borderSize, size.y), color);
			DrawBox(new Vector2(position.x + size.x - borderSize, position.y), new Vector2(borderSize, size.y), color);
			DrawBox(new Vector2(position.x + borderSize, position.y + size.y - borderSize), new Vector2(size.x - 2f * borderSize, borderSize), color);
		}

		public static void HeliosBox()
		{
			HeliosBox((float)(Screen.width / 2), (float)(Screen.height / 2));
		}

		public static void HeliosBox(float sx, float sy)
		{
			Color color = new Color(255f, 255f, 0f);
			DrawLine(new Vector2(sx - 8f, sy - 8f), new Vector2(sx + 8f, sy - 8f), color);
			DrawLine(new Vector2(sx + 8f, sy - 8f), new Vector2(sx + 8f, sy + 8f), color);
			DrawLine(new Vector2(sx - 8f, sy + 8f), new Vector2(sx + 8f, sy + 8f), color);
			DrawLine(new Vector2(sx - 8f, sy - 8f), new Vector2(sx - 8f, sy + 8f), color);
		}
	}
}
