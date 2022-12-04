using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurnPageRight : MonoBehaviour
{
    public bool SendSignal=false;
    public float timer=20.0f;
    public static event Action<float> onFlip;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
      if(SendSignal){


        //if someone is listening
        if(onFlip != null ){
            //call the event OnFlip
            onFlip(50);
            //wait a bit so it can't be invoked again
        }
        SendSignal=false;
        //
        Invoke("waitABit",timer);
      }
    }
    void waitABit(){
      SendSignal=false;
    }
}
