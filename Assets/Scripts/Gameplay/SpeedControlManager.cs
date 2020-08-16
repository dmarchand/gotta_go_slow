using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControlManager : MonoBehaviour
{
    public float BaseGameSpeed;
    public float CollisionSpeedReduction;

    [HideInInspector]
    public float CurrentGameSpeed;

    private void Awake() {
        CurrentGameSpeed = BaseGameSpeed;
    }
}
