using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerTest : MonoBehaviour
{
    private Controllers input;

    private void Awake()
    {
        input = new Controllers();
        input.Test.Pressing.performed += ctx =>Pressing();
    }
    public void Pressing(){
        Debug.Log("lol");
    }
    private void OnEnable()
    {
        input.Test.Enable();
    }
    private void OnDisable()
    {
        input.Test.Disable();
    }
}
