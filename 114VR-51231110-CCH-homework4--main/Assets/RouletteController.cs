using UnityEngine;
using UnityEngine.InputSystem;   

public class RouletteController : MonoBehaviour
{
    public float rotateSpeed = 0f;      
    public float maxSpeed = 900f;       
    public float deceleration = 0.995f; 
    bool isSpinning = false;            
    bool isSlowing = false;             

    void Update()
    {
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            
            if (!isSpinning && !isSlowing)
            {
                isSpinning = true;
                rotateSpeed = maxSpeed;
            }
            
            else if (isSpinning)
            {
                isSpinning = false;
                isSlowing = true;
            }
        }

        if (isSpinning)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

   
        if (isSlowing)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            rotateSpeed *= deceleration;

            if (rotateSpeed < 5f)
            {
                rotateSpeed = 0f;
                isSlowing = false;
            }
        }
    }
}
