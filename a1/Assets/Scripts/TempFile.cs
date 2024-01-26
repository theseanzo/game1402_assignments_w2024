using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 5;
        int y = 10;
        Func<float,float,float> mathFunc = (someX, someY) => someX + someY;
        float z = mathFunc(5.0f, 2.0f);
        mathFunc = (someX, someY) => someX - someY;
        mathFunc = (someX, someY) => someX * someY;
        mathFunc += (someX, someY) => someX / someY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
