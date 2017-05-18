using UnityEngine;
using System.Collections;

public class dontdestroyonload : MonoBehaviour {

    void Awake()
    {
        print("awake");

        DontDestroyOnLoad(this);
        
    }
}
