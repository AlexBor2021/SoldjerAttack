using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    public Transform MovePoint { get; private set; }
    public Transform WarPoint { get; private set; }



    public void SetStartPoint(Transform point, Transform warPoint)
    {
        MovePoint = point;
        WarPoint = warPoint;
    }
}
