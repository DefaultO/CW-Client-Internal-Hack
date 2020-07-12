using UnityEngine;

namespace CW_Internal_Hack.Utility
{
    internal class GameUtility
    {
        public static bool IsLocalplayer(EntityNetPlayer player)
        {
            return Peer.ClientGame.LocalPlayer == player;
        }

        public static bool IsTeammate(ClientNetPlayer localPlayer, EntityNetPlayer player)
        {
            return Peer.ClientGame.IsTeamGame && (localPlayer.IsBear == player.IsBear);
        }

        public static bool IsVisable(GameObject origin, Vector3 toCheck)
        {
            RaycastHit hit;
            if (Physics.Linecast(Camera.main.transform.position, toCheck, out hit))
            {
                if (hit.transform.name.Contains("NPC") ||
                    hit.transform.name.Contains("NPC_Spine1") ||
                    hit.transform.name.Contains("shell_rifle") ||
                    hit.transform.name.Contains("client") ||
                    hit.transform.name == Camera.main.name ||
                    hit.transform.name == Camera.main.gameObject.name ||
                    hit.transform.name == Camera.main.transform.name ||
                    hit.transform.tag.Contains("Player"))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Visible(Vector3 pos)
        {
            GameObject gameObject = new GameObject
            {
                transform =
                {
                    position = Camera.main.transform.position
                }
            };
            gameObject.transform.LookAt(pos);
            Ray ray = new Ray(Camera.main.transform.position, gameObject.transform.forward);
            RaycastHit raycastHit = default(RaycastHit);
            return Physics.Raycast(ray, out raycastHit) && gameObject.layer == 1 << LayerMask.NameToLayer("client_ragdoll");
        }
    }
}
