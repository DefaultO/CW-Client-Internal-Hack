using UnityEngine;

namespace CW_Internal_Hack
{
    class Chams : MonoBehaviour
    {
		// Set-up the Shader + Material
		private void Start()
		{
			enemyTex = new Texture2D(1, 1);
			enemyTex.SetPixel(0, 0, new UColor(255, 213, 0).Get());
			enemyTex.Apply();
			mateTex = new Texture2D(1, 1);
			mateTex.SetPixel(0, 0, new UColor(0, 255, 208).Get());
			mateTex.Apply();
			ThermalMatFriend = new Material("Shader \"Unlit a7efd2 \" { SubShader { Pass { Color (0,1,0,0) }}}");
			ThermalMatEnemy = new Material("Shader \"Unlit a7efd2 \" { SubShader { Pass { Cull Off ZWrite Off ZTest Always Color (1,0,0,0) } Pass { ZWrite On ZTest LEqual Color (0,0,1,0) }}}");
		}

		private void OnGUI()
		{
			if (Config.Config.Visual.Chams)
			{
				ChamsUpdate();
			}
		}

		private void ChamsUpdate()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;

			Transform transform = Camera.main.transform;
			Plane[] array = GeometryUtility.CalculateFrustumPlanes(Camera.main);

			foreach (EntityNetPlayer entityNetPlayer in Peer.ClientGame.AlivePlayers)
			{
				GameObject gameObject;
				if (entityNetPlayer.PlayerObject)
				{
					gameObject = entityNetPlayer.PlayerObject;
				}
				else
				{
					gameObject = entityNetPlayer.gameObject;
				}
				if (!(gameObject == null))
				{
					Bounds bounds;
					if (gameObject.GetComponent<Collider>() != null)
					{
						bounds = gameObject.GetComponent<Collider>().bounds;
						num2++;
					}
					else if (gameObject.GetComponent<Renderer>() != null)
					{
						bounds = gameObject.GetComponent<Renderer>().bounds;
						num3++;
					}
					else
					{
						if (!(gameObject.transform != null))
						{
							continue;
						}
						bounds = TransformToBounds(gameObject.transform);
						num4++;
					}
					Vector3.Distance(bounds.center, transform.position);
					if (GeometryUtility.TestPlanesAABB(array, bounds))
					{
						if (gameObject.GetComponent<MeshRenderer>() != null)
						{
							gameObject.GetComponent<MeshRenderer>().receiveShadows = false;
						}
						bool isBear = Peer.ClientGame.LocalPlayer.IsBear;
						SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
						for (int i = 0; i < componentsInChildren.Length; i++)
						{
							componentsInChildren[i].receiveShadows = false;
							componentsInChildren[i].material = (Peer.ClientGame.IsTeamGame ? ((entityNetPlayer.IsBear == isBear) ? ThermalMatFriend : ThermalMatEnemy) : ThermalMatEnemy);
							componentsInChildren[i].material.mainTexture = (Peer.ClientGame.IsTeamGame ? ((entityNetPlayer.IsBear == isBear) ? mateTex : enemyTex) : enemyTex);
							Material[] materials = componentsInChildren[i].materials;
							for (int j = 0; j < materials.Length; j++)
							{
								materials[j] = (Peer.ClientGame.IsTeamGame ? ((entityNetPlayer.IsBear == isBear) ? ThermalMatFriend : ThermalMatEnemy) : ThermalMatEnemy);
								materials[j].mainTexture = (Peer.ClientGame.IsTeamGame ? ((entityNetPlayer.IsBear == isBear) ? mateTex : enemyTex) : enemyTex);
							}
						}
						Texture2D texture2D = Peer.ClientGame.IsTeamGame ? ((entityNetPlayer.IsBear == isBear) ? mateTex : enemyTex) : enemyTex;
					}
					num++;
				}
			}
		}

		public static Bounds TransformToBounds(Transform t)
		{
			return new Bounds(t.position, t.localScale);
		}


		public static Material ThermalMatFriend;

		public static Material ThermalMatEnemy;

		public static Texture2D mateTex;

		public static Texture2D enemyTex;
	}
}
