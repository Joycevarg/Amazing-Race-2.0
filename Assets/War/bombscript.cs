using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombscript : MonoBehaviour {
    public GameObject explosionVFX;
	// Use this for initialization

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            if (other.gameObject.tag == "Target")
            {
                other.GetComponent<bombtargetscript>().Hit();
            }
            Instantiate(explosionVFX, this.transform.position,this.transform.rotation);
            Destroy(this.gameObject);
        }


    }
}
