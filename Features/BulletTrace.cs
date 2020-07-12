using UnityEngine;

namespace CW_Internal_Hack.Hacks
{
    class BulletTrace
    {
		private void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.position = start;
			gameObject.AddComponent<LineRenderer>();
			LineRenderer component = gameObject.GetComponent<LineRenderer>();
			component.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
			component.material.SetFloat("_ZTest", 0f);
			component.material.SetFloat("_ZWrite", 0f);
			component.SetColors(color, color);
			component.SetWidth(0.01f, 0.01f);
			component.SetPosition(0, start);
			component.SetPosition(1, end);
			UnityEngine.Object.Destroy(gameObject, duration);
		}

		private void DrawNoSpread()
		{

		}
	}
}
