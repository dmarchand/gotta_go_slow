using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisFallingController : MonoBehaviour
{
    private DebrisConfigurationController debrisConfigurationController;

    private void Awake() {
        debrisConfigurationController = GetComponent<DebrisConfigurationController>();    

        if(debrisConfigurationController == null) {
            throw new System.MissingMemberException("No DebrisConfigurationController found");
        }
    }

    private void Update() {
        transform.Translate(new Vector3(0, CalculateFallSpeed(), 0));
    }

    private float CalculateFallSpeed() {
        float fallSpeed = debrisConfigurationController.BaseFallSpeed;
        fallSpeed *= Time.deltaTime;
        // Add base game speed here

        return -fallSpeed;
    }
}
