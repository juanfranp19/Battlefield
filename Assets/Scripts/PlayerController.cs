using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 20), SerializeField]
    private float lateralSpeed = 15f;

    [Range(0, 100), SerializeField]
    private float forwardSpeed = 100f;

    [SerializeField]
    private float maxZ = -6f;

    [SerializeField]
    private float maxX = 8f;

    [SerializeField]
    private float minX = -8f;

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
            // posición x
            float positionX = this.transform.position.x;

            horizontalInput = Input.GetAxis("Horizontal");

            // calcula el movimiento
            float movimiento = lateralSpeed * horizontalInput * Time.deltaTime;

            // mientras el movimiento esté en el límite, puede hacerlo
            if (positionX + movimiento <= maxX && positionX + movimiento >= minX)
            {
                // se mueve a la derecha o a la izquierda
                this.transform.Translate(Vector3.right * movimiento);
            }
            else
            {
                // hace que no se salga del límite
                if (positionX <= maxX) this.transform.Translate(Vector3.left);
                if (positionX >= minX) this.transform.Translate(Vector3.right);
            }
        }
        else
        {
            float positionZ = this.transform.position.z;

            // cuando llega a la posición máxima de Z, se para
            if (!(positionZ <= maxZ))
            {
                // se mueve hacia delante
                this.transform.Translate(forwardSpeed * Time.deltaTime * Vector3.forward);
            }
        }
    }
}
