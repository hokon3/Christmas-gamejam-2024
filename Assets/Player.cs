using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float m_Thrust;
    public Rigidbody Rigidbody;
    private InputAction moveAction;
    public GameObject victoryText;
    private bool gotNose = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        Rigidbody.maxLinearVelocity = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gotNose)
        {
            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            if (moveValue.y != 0)
            {
                var vector = transform.forward * m_Thrust;
                vector *= moveValue.y;
                Rigidbody.AddForce(vector);
            }
            if (moveValue.x != 0)
            {
                transform.Rotate(new Vector3(0, moveValue.x, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) { 
            Application.Quit();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Nose")
        {
            victoryText.SetActive(true);
            gotNose = true;
        }
    }

    public void startGame()
    {
        gotNose = false;
    }
}
