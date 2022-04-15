using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabHolder : MonoBehaviour
{
    [SerializeField] GameObject spawnSystemPrefab;
    public Sprite red_Button;
    public Sprite green_Button;

    public GameObject GetSpawnSystem()
    {
        return spawnSystemPrefab;
    }
}
