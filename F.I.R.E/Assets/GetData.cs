using UnityEngine;
using UnityEditor;
using Models;
using Proyecto26;
using System.Collections.Generic;
using UnityEngine.Networking;
public class GetData : MonoBehaviour
{
    var ServerUrl;
    //file type

    // Update is called once per frame
    void Update()
    {
        while(true){
            RestClient.Get<User>(ServerUrl + "/1").Then(firstUser => {
                EditorUtility.DisplayDialog("JSON", JsonUtility.ToJson(firstUser, true), "Ok");
            });
        }
    }
}
