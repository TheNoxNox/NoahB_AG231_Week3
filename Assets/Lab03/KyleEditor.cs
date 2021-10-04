using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyleEditor : MonoBehaviour
{
    public static bool isMOPdisabled = false;

    public GameObject kyle;
    public void ChangeKyleScale(float scaleVal)
    {
        kyle.transform.localScale = Vector3.one * scaleVal;
    }

    public void ChangeKyleRotation(float rotAngle)
    {
        Quaternion rotVal = new Quaternion();
        rotVal.eulerAngles = new Vector3(0, rotAngle, 0);

        kyle.transform.rotation = rotVal;
    }

    public void EnableDisableMakeOnPlane()
    {
        if (isMOPdisabled)
        {
            isMOPdisabled = false;
        }
        else
        {
            isMOPdisabled = true;
        }
    }
}
