using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Units;
using System;

namespace AspNetGame.Models.Game.Base
{
    [Flags]
    public enum Abilities
    {
        None = 0,
        Attacker = 1,
        Mobile = 2,
        Builder = 4,
        Extractor = 8,
        Storage = 16,
        Researcher = 32,
        All = 63
    }

    public static class AbilitiesHelper
    { 
        private static bool IsSet(Abilities flags, Abilities flag) 
        {
            int flagsValue = (int)(object)flags;
            int flagValue = (int)(object)flag;

            return (flagsValue & flagValue) != 0;
        }

        public static bool IsAttacker(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Attacker);
        }
        public static bool IsMobile(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Mobile);
        }

        public static bool IsBuilder(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Builder);
        }

        public static bool IsExtractor(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Extractor);
        }

        public static bool IsStorage(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Storage);
        }

        public static bool IsResearcher(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Researcher);
        }

        public static IAttacker AsAttacker(UnitTemplate unit)
        {
            if (!IsAttacker(unit))
                throw new InvalidOperationException("This unit is not an attacker");

            return (unit as IAttacker);
        }

        public static IMobile AsMobile(UnitTemplate unit)
        {
            if (!IsMobile(unit))
                throw new InvalidOperationException("This unit is not mobile");

            return (unit as IMobile);
        }

        public static IBuilder AsBuilder(UnitTemplate unit)
        {
            if (!IsBuilder(unit))
                throw new InvalidOperationException("This unit is not a builder");

            return (unit as IBuilder);
        }

        public static IExtractor AsExtractor(UnitTemplate unit)
        {
            if (!IsExtractor(unit))
                throw new InvalidOperationException("This unit is not an extractor");

            return (unit as IExtractor);
        }

        public static IStorage AsStorage(UnitTemplate unit)
        {
            if (!IsStorage(unit))
                throw new InvalidOperationException("This unit is not a storage");

            return (unit as IStorage);
        }

        public static IResearcher AsResearcher(UnitTemplate unit)
        {
            if (!IsResearcher(unit))
                throw new InvalidOperationException("This unit is not a storage");

            return (unit as IResearcher);
        }


    }
}