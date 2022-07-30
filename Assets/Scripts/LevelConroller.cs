using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConroller : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;

    private void OnTriggerEnter(Collider other)
    {
        int index = (int)Random.Range(0, _prefabs.Length);
        if (other.tag == "Level")
            Instantiate(_prefabs[index], new Vector3(69.9f, -4f, 0f), Quaternion.identity);
    }


}
