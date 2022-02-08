using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovementSettings
{
    public float speed;
    public float accelerationModifier; 
    public float decelerationModifier;
    public float jumpAcceleration;
    public float maxFallSpeed;
    public float gravity;
    public float xRotationSens;
    public float yRotationSens;
    public float xRotationMin;
    public float xRotationMax;
    public LayerMask groundLayer;
}
