using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20), SerializeField]
    private float lateralSpeed = 15f;

    [Range(0, 100), SerializeField]
    private float forwardSpeed = 100f;

    private bool moveForward = false;

    private float horizontalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // si pulsa la tecla espacio, bloqueará el movimiento lateral
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveForward = true;
        }

        if (!moveForward)
        {
            // se mueve a la derecha o a la izquierda
            horizontalInput = Input.GetAxis("Horizontal");
            this.transform.Translate(lateralSpeed * horizontalInput * Time.deltaTime * Vector3.right);
        }
        else
        {
            // se mueve hacia delante
            this.transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);
        }
    }
}
