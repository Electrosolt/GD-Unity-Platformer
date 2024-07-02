using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    private enum GravityDirection
    {
        UP,
        LEFT,
        DOWN,
        RIGHT,
    }

    [SerializeField] private GameObject gravityDisplay;
    private GravityDirection currentDirection = GravityDirection.DOWN;
    
    // Start is called before the first frame update
    void Start()
    {
        RotateBy(0); // Refresh rotation display
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateGravityLeft(InputAction.CallbackContext context)
    {
        if (context.performed) RotateBy(-1);
    }
    
    public void RotateGravityRight(InputAction.CallbackContext context)
    {
        if (context.performed) RotateBy(1);
    }
    
    public void FlipGravity(InputAction.CallbackContext context)
    {
        if (context.performed) RotateBy(2);
    }

    private void RotateBy(int amount)
    {
        int newDir = ((int) currentDirection + amount) % 4;
        currentDirection = (GravityDirection) newDir;
        gravityDisplay.transform.rotation = Quaternion.AngleAxis(newDir * 90, Vector3.forward);
    }
    
    
}
