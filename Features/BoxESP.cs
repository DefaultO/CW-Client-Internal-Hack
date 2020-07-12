using CW_Internal_Hack.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace CW_Internal_Hack.Hacks
{
    class BoxESP : MonoBehaviour
    {
        void OnGUI()
        {
            if (Config.Config.Visual.BoxESP)
            {
                BoxEspUpdate();
            }
        }

        void BoxEspUpdate(bool showTeam = false, bool cornered = false)
        {
            // Might addd Corner Boxes in the future. For now there is no option for that yet.
            List<EntityNetPlayer> players = Peer.ClientGame.AlivePlayers;
            for (int i = 0; i < players.Count; i++)
            {
                if (showTeam == false && GameUtility.IsTeammate(Peer.ClientGame.LocalPlayer, players[i]))
                    continue;

                Vector3 w2sHead = Camera.main.WorldToScreenPoint(players[i].NeckPosition);
                Vector3 w2sBottom = Camera.main.WorldToScreenPoint(players[i].Position);
                float height = 1.5f * Math.Abs(w2sHead.y - w2sBottom.y);
                float width = height;

                if (w2sHead.z > 0f)
                {
                    if (GameUtility.IsVisable(Camera.main.gameObject, w2sHead))
                    {
                        Draw.DrawBoxOutlines(new Vector2(w2sHead.x - (width / 2f), Screen.height - w2sHead.y), new Vector2(width, height), 1f, new UColor(245, 233, 66).Get());
                    }
                    else
                    {
                        Draw.DrawBoxOutlines(new Vector2(w2sHead.x - (width / 2f), Screen.height - w2sHead.y), new Vector2(width, height), 1f, new UColor(66, 155, 245).Get());
                    }

                }
            }
        }
    }
}
