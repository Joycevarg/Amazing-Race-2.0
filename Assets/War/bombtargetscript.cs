using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombtargetscript : MonoBehaviour {
    //Animator anim;
    public Helicontrol heliControl;
    public GameObject fire;
    bool hit = false;
	// Use this for initialization
	void Start ()
    {
    //    anim = GetComponent<Animator>();
	}

    // Update is called once per frame
   
    public void Hit()
    {
        if (!hit)
        {
            heliControl.score++;
            fire.SetActive(true);
            //anim.SetTrigger("bombed");
            hit = true;
        }
    }
}
