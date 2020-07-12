using CW_Internal_Hack.Hacks;
using UnityEngine;

namespace CW_Internal_Hack
{
    class Loader
    {
        public static GameObject load_object;

        public static void Load()
        {
            load_object = new GameObject();


            load_object.AddComponent<Main>();

            load_object.AddComponent<Aimbot>();
            load_object.AddComponent<BoxESP>();
            load_object.AddComponent<Chams>();
            load_object.AddComponent<DistanceESP>();
            load_object.AddComponent<Environment>();
            load_object.AddComponent<HealthESP>();
            load_object.AddComponent<Snaplines>();

            Object.DontDestroyOnLoad(load_object);
        }
        public static void Unload()
        {
            Object.Destroy(load_object);
        }
    }
}
