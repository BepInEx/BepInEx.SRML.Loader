﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SRML.Console.Commands
{
    public class GiveCommand : ConsoleCommand
    {
        public override string ID => "give";

        public override string Usage => "give <id> <amount>";

        public override string Description => "Gives an item";

        public override bool Execute(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                Console.LogError("Incorrect number of arguments!");
                return false;
            }

            Identifiable.Id id;
            try
            {
                id = (Identifiable.Id)Enum.Parse(typeof(Identifiable.Id), args[0], true);
            }
            catch
            {
                Console.LogError("Invalid ID!");
                return false;
            }

            int count = 0;

            if (args.Length != 2 || !Int32.TryParse(args[1], out count)) count = 1;

            var g = SRBehaviour.InstantiateActor(GameContext.Instance.LookupDirector.GetPrefab(id), SceneContext.Instance.PlayerState.model.currRegionSetId);
            for (int i = 0; i < count; i++) SceneContext.Instance.PlayerState?.Ammo.MaybeAddToSlot(id, g.GetComponent<Identifiable>());
            GameObject.DestroyImmediate(g);
            return true;
        }

        public override List<string> GetAutoComplete(int argIndex, string argText)
        {
            if (argIndex == 0)
            {
                return SceneContext.Instance.PlayerState?.GetPotentialAmmo().Select(x => x.ToString()).ToList();
            }
            return base.GetAutoComplete(argIndex, argText);
        }
    }
}
