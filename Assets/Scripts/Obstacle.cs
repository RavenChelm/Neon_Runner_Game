using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private GameObject endGameMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Time.timeScale = 0;
            other.gameObject.GetComponent<PlayerContoller>().SetDeadStatus(true);
        }
    }
}
