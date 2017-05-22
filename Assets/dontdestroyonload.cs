using UnityEngine;
using System.Collections;

public class dontdestroyonload : MonoBehaviour {

    private static GameObject _instance;
    void Awake()
    {

        if (!_instance)
            _instance = this.gameObject;
        else
            Destroy(this.gameObject);
        print("awake");

        DontDestroyOnLoad(this.gameObject);
        
    }
}
