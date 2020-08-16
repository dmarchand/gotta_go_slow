using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionEventController : MonoBehaviour
{
    private SpeedControlManager SpeedControlManager;

    private void Awake() {
        SpeedControlManager = GameObject.Find("SpeedControlManager").GetComponent<SpeedControlManager>();
        if (SpeedControlManager == null) {
            throw new MissingComponentException("Where's the SpeedControlManager?");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
        SpeedControlManager.CurrentGameSpeed *= SpeedControlManager.CollisionSpeedReduction;
    }
}
