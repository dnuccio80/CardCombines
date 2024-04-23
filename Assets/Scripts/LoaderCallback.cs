using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    bool isFIrstUpdate = false;

    private void Update()
    {
        if(!isFIrstUpdate)
        {
            Loader.LoadTargetScene();
            isFIrstUpdate = true;
        }

    }


}
