using AspNetGame.Models.Game.Contracts;
using AspNetGame.Models.Game.Units;
using System;

namespace AspNetGame.Models.Game.Base
{
    /// <summary>
    /// Abilities is a Set of constants that represents the capabilities of a unit template.
    /// That can be used as flags so it's possible for a unit to cumulate several capabilities.
    /// </summary>
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

    /// <summary>
    /// An helper class that allows to determine whether a unit template support some abilities
    /// and to get unit casted with the corresponding behavioral interface (see Contracts/)
    /// </summary>
    public static class AbilitiesHelper
    { 
        /// <summary>
        /// To know if flag belongs to the set of flags
        /// </summary>
        /// <param name="flags">The set of flags</param>
        /// <param name="flag">The flag to test</param>
        /// <returns></returns>
        private static bool IsSet(Abilities flags, Abilities flag) 
        {
            int flagsValue = (int)(object)flags;
            int flagValue = (int)(object)flag;

            return (flagsValue & flagValue) != 0;
        }

        /// <summary>
        /// Indicated whether current unit template is an attacker
        /// </summary>
        /// <param name="unit">The unit template</param>
        /// <returns></returns>
        public static bool IsAttacker(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Attacker);
        }

        /// <summary>
        /// Indicated whether current unit template is mobile
        /// </summary>
        /// <param name="unit">The unit template</param>
        /// <returns></returns>
        public static bool IsMobile(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Mobile);
        }

        /// <summary>
        /// Indicated whether current unit template is a builder
        /// </summary>
        /// <param name="unit">The unit template</param>
        /// <returns></returns>
        public static bool IsBuilder(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Builder);
        }

        /// <summary>
        /// Indicated whether current unit template is an extractor
        /// </summary>
        /// <param name="unit">The unit template</param>
        /// <returns></returns>
        public static bool IsExtractor(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Extractor);
        }


        /// <summary>
        /// Indicated whether current unit template is a store
        /// </summary>
        /// <param name="unit">The unit template</param>
        /// <returns></returns>
        public static bool IsStorage(UnitTemplate unit)
        {
            return IsSet(unit.Abilities, Abilities.Storage);
        }


        /// <summary>
        /// Indicated whether current unit template is a researcher
        /// </summary>
        /// <param name="unit">The unit template</param>
        /// <returns></returns>
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