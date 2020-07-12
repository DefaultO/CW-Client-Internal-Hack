using System.Collections.Generic;
using UnityEngine;

namespace CW_Internal_Hack
{
    public class Main : MonoBehaviour
    {
        void OnGUI()
        {
            Draw.DrawString(new Vector2(Screen.width / 2, 20), new UColor(66, 155, 245).Get(), Draw.TextFlags.TEXT_FLAG_CENTERED, "TEAM EHRENLOS @ UNKOWNCHEATS.ME");
        }



        // Testing Stuff
        void GrenadeESP()
        {
            List<ClientEntity> Entities = Peer.ClientGame.AllEntities;
            for (int i = 0; i < Peer.ClientGame.AllEntities.Count; i++)
            {
                // Due to obfuscation not possible yet by directly getting the entity type
            }
        }

        void BuyNicknameChanges()
        {
            
        }

        void ModeratorCount()
        {
            foreach (EntityNetPlayer player in Peer.ClientGame.AllPlayers)
            {

            }
        }
    }
}
