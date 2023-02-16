using KitchenData;
using KitchenLib;
using System.Reflection;

namespace BetterHeldAppliances
{
	public class Main : BaseMod
	{
		public const string MOD_GUID = "betterheldappliances";
		public const string MOD_NAME = "Better Held Appliances";
		public const string MOD_VERSION = "0.1.0";
		public const string MOD_AUTHOR = "StarFluxGames";
		public const string MOD_GAMEVERSION = ">=1.1.3";
		public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

		protected override void OnInitialise()
		{
			foreach (Appliance appliance in GameData.Main.Get<Appliance>())
			{
				appliance.HeldAppliancePrefab = appliance.Prefab;
			}
		}
	}
}