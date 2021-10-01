using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KyleEditor : MonoBehaviour
{
    public GameObject kyle;
    public void ChangeKyleScale(float scaleVal)
    {
        kyle.transform.localScale *= scaleVal;
    }

    public void ChangeKyleRotation(float rotAngle)
    {
        kyle.transform.Rotate(new Vector3(0, rotAngle, 0));
    }
}
