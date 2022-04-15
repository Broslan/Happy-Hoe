using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IGround
{
    public void OnContact();

    public int GetGroundType();

    public bool GetUsedForSpawn();

    public void SetUsedForSpawn(bool isUsed);

    public void AddSpawnInfo(GroundSpawn groundSpawn);
}
