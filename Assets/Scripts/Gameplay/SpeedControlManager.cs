using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControlManager : MonoBehaviour
{
    public float BaseGameSpeed;
    public float BaseCollisionSpeedReduction;

    [HideInInspector]
    public float CurrentGameSpeed;
    [HideInInspector]
    public float CurrentCollisionSpeedReduction;
}
