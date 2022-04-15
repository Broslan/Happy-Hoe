using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround : MonoBehaviour
{
    [SerializeField] GroundSpawn groundSpawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IGround ground = collision.GetComponent<IGround>();
        if (collision.CompareTag("DirtTile") && !ground.GetUsedForSpawn())
        {
            ground.SetUsedForSpawn(true);
            ground.AddSpawnInfo(groundSpawn);
            groundSpawn.SpawnGroundTile();
            //Debug.Log("Hello Dirt");
        }
    }

}
