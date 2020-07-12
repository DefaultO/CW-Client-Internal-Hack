using CW_Internal_Hack.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace CW_Internal_Hack.Hacks
{
    class Snaplines : MonoBehaviour
    {
        void OnGUI()
        {
            if (Config.Config.Visual.Snaplines)
            {
                SnaplinesUpdate();
            }
        }

        void SnaplinesUpdate(bool showTeam = false)
        {
            List<EntityNetPlayer> players = Peer.ClientGame.AlivePlayers;
            for (int i = 0; i < players.Count; i++)
            {
                if (showTeam == false && GameUtility.IsTeammate(Peer.ClientGame.LocalPlayer, players[i]))
                    continue;

                Vector3 w2sHead = Camera.main.WorldToScreenPoint(players[i].NeckPosition);
                Vector3 w2sBottom = Camera.main.WorldToScreenPoint(players[i].Position);

                if (w2sHead.z > 0f)
                {
                    Draw.DrawLine(new Vector2(Screen.width / 2, Screen.height), new Vector2(w2sBottom.x, (Screen.height - w2sBottom.y) + 20), new UColor(235, 235, 235, 50).Get());
                }
            }
        }
    }
}
