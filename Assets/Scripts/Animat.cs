using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animat : MonoBehaviour
{
    private Animator animat;
    private PlayerContoller plcont;
    private int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        animat = gameObject.transform.GetChild(0).GetComponent<Animator>();
        plcont = gameObject.GetComponent<PlayerContoller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (plcont._score.timeStart > 0)
        {
            if (time == 0)
            {
                time = 1;
                animat.SetInteger("Time", time);
                Debug.Log(time);
            }
            if (plcont.slide == true &&
                plcont.GetGameStatus() == true && plcont.GetDeadStatus() == false &&
                plcont.jump == false && plcont._controller.isGrounded)
            {
                animat.SetBool("Slide", true);
            }
            else
            {
                animat.SetBool("Slide", false);
            }
            if (plcont.jump == true &&
                plcont.GetGameStatus() == true && plcont.GetDeadStatus() == false)
            {
                animat.SetBool("Jump", true);
            }
            else
            {
                animat.SetBool("Jump", false);

            }

        }
    }
}
