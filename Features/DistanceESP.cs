using CW_Internal_Hack.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CW_Internal_Hack.Hacks
{
    class DistanceESP : MonoBehaviour
    {
        private void OnGUI()
        {
            if (Config.Config.Visual.DistanceESP)
            {
                DistanceUpdate();
            }
        }

        private void DistanceUpdate(bool showTeam = false)
        {
            List<EntityNetPlayer> players = Peer.ClientGame.AlivePlayers;
            for (int i = 0; i < players.Count; i++)
            {
                if (showTeam == false && GameUtility.IsTeammate(Peer.ClientGame.LocalPlayer, players[i]))
                    continue;

                Vector3 screenPos = Camera.main.WorldToScreenPoint(players[i].Position);
                if (screenPos.z > 0f)
                {
                    Draw.DrawString(new Vector2(screenPos.x, Screen.height - screenPos.y), new UColor(214, 214, 214).Get(), Draw.TextFlags.TEXT_FLAG_CENTERED & Draw.TextFlags.TEXT_FLAG_DROPSHADOW, String.Format("{0:0.00}m", Vector3.Distance(Peer.ClientGame.LocalPlayer.Position, players[i].Position)));
                }
            }
        }
    }
}
