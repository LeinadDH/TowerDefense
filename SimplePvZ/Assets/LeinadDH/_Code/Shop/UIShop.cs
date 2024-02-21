using System.Collections.Generic;
using UnityEngine;

namespace com.LeinadDH.ChessDefense
{
    public class UIShop : MonoBehaviour
    {
        public List<GameObject> prefabList;
        public GameObject parentUIObject;

        void Awake()
        {
            InstantiatePrefabs();
        }

        void InstantiatePrefabs()
        {
            if (parentUIObject == null || prefabList.Count == 0)
            {
                Debug.LogWarning("Parent UI object or prefab list not set.");
                return;
            }

            Vector2 spawnPosition = Vector2.zero;

            foreach (GameObject prefab in prefabList)
            {
                GameObject instantiatedPrefab = Instantiate(prefab, parentUIObject.transform);
                instantiatedPrefab.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
            }
        }
    }
}