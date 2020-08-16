using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisFallingController : MonoBehaviour
{
    private DebrisConfigurationController debrisConfigurationController;
    private SpeedControlManager SpeedControlManager;

    private void Awake() {
        debrisConfigurationController = GetComponent<DebrisConfigurationController>();    

        if(debrisConfigurationController == null) {
            throw new MissingComponentException("No DebrisConfigurationController found");
        }

        SpeedControlManager = GameObject.Find("SpeedControlManager").GetComponent<SpeedControlManager>();
        if (SpeedControlManager == null) {
            throw new MissingComponentException("Where's the SpeedControlManager?");
        }
    }

    private void Update() {
        transform.Translate(new Vector3(0, CalculateFallSpeed(), 0));
    }

    private float CalculateFallSpeed() {
        float fallSpeed = debrisConfigurationController.BaseFallSpeed;
        fallSpeed += SpeedControlManager.CurrentGameSpeed;
        fallSpeed *= Time.deltaTime;
        
        return -fallSpeed;
    }
}
