using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handPointer : MonoBehaviour
{
    //line Renderer
    public LineRenderer linePointer;
    public float lineWidth= 0.1f;
    public float lineMaxLength= 1f;
    
    //bool to see if lineRenderer is on or off
    public bool LineToggle=false;

    //right hand trigger input from 0 to 1.0
    private float rhand= OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);

    //bool to see if we hit the rightSpot with the raycast
    public bool RightSpotHit= false;

    //game object to store the rightSpot game object
    private GameObject touched;


    // Start is called before the first frame update
    void Start()
    {
    //line Render is set up
     Vector3[] VectorStartPosition= new Vector3[2] {Vector3.zero, Vector3.zero};
     linePointer.SetPositions(VectorStartPosition);
     linePointer.enabled = false;   
    }

    // Update is called once per frame
    void Update()
    {
    //always get the new value of the trigger
     rhand= OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger);   

    //if the trigger is fully enabled
     if(rhand>0.9f){
        LineToggle=true;
        linePointer.enabled =true;
     }
     else{
        linePointer.enabled =false;
        LineToggle=false;
        RightSpotHit=false;
     }

     if(LineToggle){
        //start raycasting
        handCasting(transform.position,transform.forward,lineMaxLength);
     }

    }
    //cast ray from hand 
    private void handCasting(Vector3 pos,Vector3 dir, float len)
    {
        //check if raycast touches something
        RaycastHit touch;

        //set raycast
        Ray PLineOut= new Ray(pos, dir);
        
        //sets end position for line renderer
        Vector3 end= pos + (len*dir);

        //run raycast
        if(Physics.Raycast(PLineOut,out touch)){

            end=touch.point;
            touched=touch.collider.gameObject;
            //if touches a game object with the tag "RightHotSp"
            if(touched.GetComponent<TurnPageRight>()){
                RightSpotHit=true;
                //set the turnpageR in TurnPageRight to true
                touched.GetComponent<TurnPageRight>().SendSignal=true;
                //get the pageChanger component and change the page
                touched.GetComponentInParent<PageChanger>().CPage=true;
            }
            else{
                RightSpotHit=false;
            }
        }
        else if(touched){
            RightSpotHit=false;
        }
      
        linePointer.SetPosition(0,pos);
        linePointer.SetPosition(1,end);
    }
}
