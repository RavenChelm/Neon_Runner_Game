using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    private Rigidbody level;
    [SerializeField] public float velosity = 7;
    private PlayerContoller player;
    private Vector3 move;

    void Start()
    {

        level = GetComponent<Rigidbody>();
        level.velocity = move;
    }
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }
    private void FixedUpdate()
    {
        if (player.GetGameStatus())
        {
            move = new Vector3(-1 * velosity * Time.fixedDeltaTime * 100, 0, 0);
            level.velocity = move;
        }
    }
}
