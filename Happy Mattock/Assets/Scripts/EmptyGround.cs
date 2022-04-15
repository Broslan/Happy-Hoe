using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyGround : MonoBehaviour, IGround
{
    [SerializeField] int m_groundType = 0;
    [SerializeField] private bool isUsedForSpawn = false;

    private void Start()
    {
        Destroy(gameObject, 8);
    }

    int IGround.GetGroundType()
    {
        return m_groundType;
    }

    bool IGround.GetUsedForSpawn()
    {
        return isUsedForSpawn;
    }

    void IGround.OnContact()
    {
        //nothing
    }

    void IGround.SetUsedForSpawn(bool isUsed)
    {
        isUsedForSpawn = isUsed;
    }

    void IGround.AddSpawnInfo(GroundSpawn groundSpawn)
    {
        //nothing
    }
}
