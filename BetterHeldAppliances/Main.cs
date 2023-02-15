using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BetterHeldAppliances
{
	public class Main : BaseMod
	{
		public const string MOD_ID = "betterheldappliances";
		public const string MOD_NAME = "Better Held Appliances";
		public const string MOD_AUTHOR = "StarFluxGames";
		public const string MOD_VERSION = "0.1.1";
		public const string MOD_BETA_VERSION = "";
		public const string MOD_COMPATIBLE_VERSIONS = "1.1.3";
		public Main() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_BETA_VERSION, MOD_COMPATIBLE_VERSIONS, Assembly.GetExecutingAssembly()) { }

		protected override void OnInitialise()
		{
			GameObject gameobject = new GameObject();
			gameobject.SetActive(false);
			foreach (Appliance appliance in GameData.Main.Get<Appliance>())
			{
				if (appliance.Prefab != null)
				{
					GameObject prefab = GameObject.Instantiate(appliance.Prefab);
					prefab.transform.parent = gameobject.transform;
					appliance.HeldAppliancePrefab = prefab;
				}
			}

			DisableCollisions(GameData.Main);
		}


		private static List<GameObject> ListOfChildren = new List<GameObject>();
		private static void getChildRecursive(GameObject obj)
		{
			if (null == obj)
				return;

			foreach (Transform child in obj.transform)
			{
				if (null == child)
					continue;
				ListOfChildren.Add(child.gameObject);
				getChildRecursive(child.gameObject);
			}
		}

		public static void DisableCollisions(GameData gameData)
		{
			foreach (Appliance app in gameData.Get<Appliance>())
				getChildRecursive(app.HeldAppliancePrefab);
			foreach (GameObject o in ListOfChildren)
				if (o.GetComponent<Collider>() != null)
					o.GetComponent<Collider>().enabled = false;
		}
	}
}	