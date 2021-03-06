#region Copyright & License Information
/*
 * Copyright 2016-2018 The KKnD Developers (see AUTHORS)
 * This file is part of KKnD, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using OpenRA.Mods.Common.Activities;
using OpenRA.Mods.Kknd.Traits.Technicians;

namespace OpenRA.Mods.Kknd.Activities
{
	public class TechnicianRepair : Enter
	{
		private readonly Actor target;
		private readonly int amount;
		private readonly int duration;
		private readonly string voiceEnter;

		public TechnicianRepair(Actor self, Actor target, int amount, int duration, string voiceEnter) : base(self, target, EnterBehaviour.Dispose)
		{
			this.target = target;
			this.amount = amount;
			this.duration = duration;
			this.voiceEnter = voiceEnter;
		}

		protected override void OnInside(Actor self)
		{
			target.Trait<TechnicianRepairable>().Add(amount, duration);

			if (self.Owner == self.World.LocalPlayer)
				self.PlayVoice(voiceEnter);
		}
	}
}
