using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] groundTiles;
    int tilesAmmount;
    [SerializeField] private bool m_SpawnIsEnabled = true;
    [SerializeField] Transform cameraTransform;
    CameraMover cameraMover;
    GameObject newSpawnPointObject;
    [SerializeField] float newSpawnPointOffset = 20;
    [SerializeField] PrefabHolder prefabHolderObject;


    void Start()
    {
        cameraTransform = Camera.main.transform;
        prefabHolderObject = GameObject.Find("PrefabHolder").GetComponent<PrefabHolder>();
        cameraMover = GameObject.Find("PrefabHolder").GetComponent<CameraMover>();

        tilesAmmount = groundTiles.GetLength(0);
        newSpawnPointObject = prefabHolderObject.GetSpawnSystem();
        //Debug.Log("Tiles " + tilesAmmount);
    }



    public void SpawnGroundTile()
    {
        if (m_SpawnIsEnabled)
        {
            int rnd = Random.Range(0, 6 + tilesAmmount);
            //Debug.Log(rnd);
            if (rnd <= 6)
            {
                Instantiate(groundTiles[0], gameObject.transform.position, Quaternion.identity);
            }
            else
                Instantiate(groundTiles[rnd - 6], gameObject.transform.position, Quaternion.identity);
        }
    }

    public void StopSpawn()
    {
        if (m_SpawnIsEnabled)
        {
            m_SpawnIsEnabled = false;
            Instantiate(newSpawnPointObject, new Vector3(this.transform.parent.position.x, this.transform.parent.position.y + newSpawnPointOffset, this.transform.parent.position.z), Quaternion.identity);
            //cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y + newSpawnPointOffset * 0.5f, cameraTransform.position.z);
            cameraMover.cameraLevel++;
            Destroy(this.transform.parent.gameObject, 1);
        }
    }
}
