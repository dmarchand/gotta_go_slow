﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfScene : MonoBehaviour
{
    void Update() {
        if(transform.position.y < -6) {
            Destroy(gameObject);
        }
    }
}
