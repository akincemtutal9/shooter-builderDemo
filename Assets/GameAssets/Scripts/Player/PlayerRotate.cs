using System;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private int rotateSpeed;
    //[SerializeField] private DynamicJoystick dynamicJoystick;
    [SerializeField] private FloatingJoystick floatingJoystick;

    [SerializeField] private GameSettings _gameSettings;
    private void Start()
    {
        rotateSpeed = _gameSettings.rotateSpeed;
    }

    private void Update()
    {
        
        float horizontalInput = floatingJoystick.Horizontal;
        float verticalInput = floatingJoystick.Vertical;

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        //Vector3 moveDirection = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        moveDirection.Normalize();
        
        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
        }
    }
}