using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{
    public float InitialControlSpeed;

    public float CurrentControlSpeed {
        get {
            return InitialControlSpeed;
        }
    }
}
