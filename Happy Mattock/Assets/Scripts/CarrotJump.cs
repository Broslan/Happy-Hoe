using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotJump : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void MakeJump()
    {
        //Vector3 vector3 = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
    }

}
