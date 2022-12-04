using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneMove1 : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable(){
        TurnPageRight.onFlip+=moveHouse;
    }   
    //move the house
    public void moveHouse(float y){
        //move the house down by -50s
        transform.position -= new Vector3(0, y, 0);
       // transform.Translate(Vector3.down * y * Time.deltaTime);;
    }
    private void onDisable(){
         TurnPageRight.onFlip-=moveHouse;
    }
    

  
}
