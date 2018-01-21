using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
    public float WaitTime;
    private void Start()
    {
        Destroy(gameObject,WaitTime);
    }
}
