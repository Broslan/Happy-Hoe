using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotGround : MonoBehaviour, IGround
{
    [SerializeField] int m_groundType = 1;
    [SerializeField] CarrotJump[] carrotJump;
    private bool isUsedForSpawn = false;
    private GroundSpawn groundSpawn;

    private void Start()
    {
        Destroy(gameObject, 8);
    }

    int IGround.GetGroundType()
    {
        return m_groundType;
    }

    void IGround.OnContact()
    {
        foreach (var carrot in carrotJump)
        {
            carrot.MakeJump();
        }
        groundSpawn.StopSpawn();
        Destroy(gameObject);
    }

    bool IGround.GetUsedForSpawn()
    {
        return isUsedForSpawn;
    }

    void IGround.SetUsedForSpawn(bool isUsed)
    {
        isUsedForSpawn = isUsed;
    }

    void IGround.AddSpawnInfo(GroundSpawn groundSpawn)
    {
        this.groundSpawn = groundSpawn;
    }
}
