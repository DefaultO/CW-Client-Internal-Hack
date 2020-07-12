using CW_Internal_Hack.Utility;
using UnityEngine;

namespace CW_Internal_Hack.Hacks
{
    class HealthESP : MonoBehaviour
    {
		// Screen turns blank / black after joining a match. Have to debug that one.
		// After having looked more into the Assembly-CSharp.dll,
		// I've found out that they check if you try to get the value from the same Assembly.
		// You can patch it out using dnSpy or libraries like Harmony that does patches in runtime

		private void OnGUI()
        {
			if (Config.Config.Visual.HealthESP)
			{
				HealthUpdate();
			}
        }

		private void HealthUpdate()
		{
			foreach (EntityNetPlayer player in Peer.ClientGame.AlivePlayers)
			{
				if (GameUtility.IsTeammate(Peer.ClientGame.LocalPlayer, player))
					continue;
				Vector3 screenPos = Camera.main.WorldToScreenPoint(player.Position);
				if (screenPos.z > 0f)
				{
					// Missing Thing: Check if the player is VIP
					// Currently it draws out of the box if it got more than 100 healt points
					DrawHealth(new Vector2(screenPos.x, Screen.height - screenPos.y), player.Health, true);
				}
			}
		}

		private void DrawHealth(Vector2 pos, float health, bool center = false)
		{
			if (center)
			{
				pos -= new Vector2(26f, 0f);
			}
			pos += new Vector2(0f, 18f);
			BoxRect(new Rect(pos.x, pos.y, 52f, 5f), Color.black);
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
			BoxRect(new Rect(pos.x, pos.y, 0.5f * health, 3f), color);
		}

		public static void BoxRect(Rect rect, Color color)
		{
			texture2D_0.SetPixel(0, 0, color);
			texture2D_0.Apply();
			color_0 = color;
			GUI.color = color;
			GUI.DrawTexture(rect, texture2D_0);
		}


		private static Texture2D texture2D_0 = new Texture2D(1, 1);

		private static Color color_0;
	}
}
