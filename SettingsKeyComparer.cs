using System.Collections.Generic;

namespace GalaxySmash
{
    class SettingsKeyComparer : IEqualityComparer<string>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(string x, string y)
        {
            return (string.Compare(x.Trim().ToLower(), y.Trim().ToLower()) == 0);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(string obj)
        {
            return obj.ToLower().GetHashCode();
        }
    }
}