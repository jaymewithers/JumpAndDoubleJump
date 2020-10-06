using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterJump : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 movement;

    public float gravity = -9.81f, jumpForce = 30f;
    private float yVar;

    public IntData playerJumpCount;
    private int jumpCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        yVar += gravity * Time.deltaTime;
        movement.Set(0, yVar, 0);

        if (controller.isGrounded && movement.y < 0)
        {
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < playerJumpCount.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }
        
        controller.Move(movement* Time.deltaTime);
    }
}