using CW_Internal_Hack.Utility;
using System.Runtime.InteropServices;
using UnityEngine;

namespace CW_Internal_Hack.Hacks
{
    class Aimbot : MonoBehaviour
    {
        // Mouse Movement, Mouse Input
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private void Update()
        {
            if (Config.Config.Aimbot.AimbotEnabled)
            {
                AimbotUpdate();
            }
        }

        private void AimbotUpdate()
        {
            float minDist = 99999; // Reset Distance to some high number because we know that the Enemies will be closer to us than that number.
            Vector2 AimTarget = Vector2.zero; // Declare a new Vector2 for the Screen Position where the mouse will aim at.

            try
            {
                var Lobby = Peer.ClientGame;

                if (Lobby)
                {
                    var LocalPlayer = Lobby.LocalPlayer;

                    foreach (EntityNetPlayer Player in Lobby.AlivePlayers)
                    {
                        if (GameUtility.IsTeammate(LocalPlayer, Player))
                        {
                            continue;
                        }

                        Vector3 Enemy_Bodypart_Position = Player.NeckPosition;
                        var shit = Camera.main.WorldToScreenPoint(Enemy_Bodypart_Position);

                        if (shit.z > 0f)
                        {
                            float dist = System.Math.Abs(Vector2.Distance(new Vector2(shit.x, Screen.height - shit.y), new Vector2((Screen.width / 2), (Screen.height / 2))));
                            if (dist < 300)
                            {
                                if (dist < minDist)
                                {
                                    minDist = dist;
                                    AimTarget = new Vector2(shit.x, Screen.height - shit.y);
                                }
                            }
                        }
                    }
                    if (AimTarget != Vector2.zero)
                    {
                        double DistX = AimTarget.x - Screen.width / 2.0f;
                        double DistY = AimTarget.y - Screen.height / 2.0f;

                        DistX /= Config.Config.Aimbot.smooth;
                        DistY /= Config.Config.Aimbot.smooth;

                        if (Input.GetKey(KeyCode.B))
                        {
                            mouse_event(0x0001, (int)DistX, (int)DistY, 0, 0);
                        }
                    }
                }
            }
            catch
            {
                // Handle Errors here.
            }
        }
    }
}
