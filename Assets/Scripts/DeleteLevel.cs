using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
