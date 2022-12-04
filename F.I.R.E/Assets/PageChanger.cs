using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageChanger : MonoBehaviour
{
    public bool CPage=false;
    public Material[] pages;
    Renderer currpage;
    public int pageNumber=0;
    // Start is called before the first frame update
    void Start()
    { 
     currpage=GetComponent<Renderer>();   
     currpage.enabled=true;
     currpage.sharedMaterial=pages[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        //if turnPage was turned on
       if(CPage){
        //call page changer
        changeThePage();
       }
    }
    void changeThePage(){
        pageNumber=pageNumber+1;
            //go to the next page
        currpage.sharedMaterial=pages[pageNumber];
        
    }
}
