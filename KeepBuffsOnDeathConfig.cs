using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace KeepBuffsOnDeath;

public class KeepBuffsOnDeathConfig : ModConfig
{
	public static KeepBuffsOnDeathConfig Instance => ModContent.GetInstance<KeepBuffsOnDeathConfig>();

	public override ConfigScope Mode => ConfigScope.ClientSide;

	[DefaultValue(false)]
	public bool KeepDebuffs { get; set; }

	[DefaultValue(0.75f)]
	public float BuffTimeMultiplier { get; set; }
}