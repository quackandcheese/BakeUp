using KitchenLib.Utils;
using UnityEngine;

namespace KitchenBakeUp.Utils
{
    /**
     * Adapted from https://github.com/ZekNikZ/PlateUpDrinksMod/blob/main/Util/Helper.cs
     */
    internal static class Helper
    {
        // Prefab / GameObject
        public static GameObject GetPrefab(string name)
        {
            return Mod.Bundle.LoadAsset<GameObject>(name);
        }
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }
        public static T TryAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T comp = gameObject.GetComponent<T>();
            if (comp == null)
                return gameObject.AddComponent<T>();
            return comp;
        }
        public static GameObject GetChild(this GameObject gameObject, string childName)
        {
            return gameObject.transform.Find(childName).gameObject;
        }
        public static GameObject GetChild(this GameObject gameObject, int childIndex)
        {
            return gameObject.transform.GetChild(childIndex).gameObject;
        }
        public static GameObject GetChildFromPath(this GameObject gameObject, string childPath)
        {
            return GameObjectUtils.GetChildObject(gameObject, childPath);
        }
        public static int GetChildCount(this GameObject gameObject)
        {
            return gameObject.transform.childCount;
        }
    }
}