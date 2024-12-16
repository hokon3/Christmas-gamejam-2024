using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float m_Thrust = 20f;
    public Rigidbody Rigidbody;
    private InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        if (moveValue.y != 0)
        {
            var vector = Vector3.ClampMagnitude(transform.forward * m_Thrust, 1);
            //vector.y *= moveValue.y;
            Rigidbody.AddForce(vector);
        }
        if (moveValue.x != 0)
        {
            transform.Rotate(new Vector3(0, moveValue.x, 0));
        }

        ;
    }
}
