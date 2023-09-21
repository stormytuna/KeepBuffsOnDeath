using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace KeepBuffsOnDeath;

public class KeepBuffsOnDeathPlayer : ModPlayer
{
	private (int type, int time)[] buffCache;

	public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource) {
		buffCache ??= new (int, int)[Player.MaxBuffs];

		for (int i = 0; i < Player.MaxBuffs; i++) {
			buffCache[i] = (Player.buffType[i], Player.buffTime[i]);
		}
	}

	public override void OnRespawn() {
		foreach ((int type, int time) in buffCache) {
			bool canAdd = (KeepBuffsOnDeathConfig.Instance.KeepDebuffs || !Main.debuff[type]) && type > 0 && !Main.persistentBuff[type] && time > 2;
			if (!canAdd) {
				continue;
			}

			int timeToAdd = (int)(time * KeepBuffsOnDeathConfig.Instance.BuffTimeMultiplier);
			Player.AddBuff(type, timeToAdd, false);
		}
	}
}