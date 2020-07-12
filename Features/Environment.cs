using UnityEngine;

namespace CW_Internal_Hack.Hacks
{
    class Environment : MonoBehaviour
    {
        private void Update()
        {
            if (Config.Config.Misc.RemovePlants)
            {
                RemoveGrass();
            }
        }

        private void RemoveGrass()
        {
            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.activeInHierarchy)
                {
                    if (go.name.Contains("grass") || go.name.Contains("brush") || go.name.Contains("paporotnik") || go.name.Contains("bush"))
                    {
                        go.SetActive(false);
                    }
                }
            }
        }
    }
}
