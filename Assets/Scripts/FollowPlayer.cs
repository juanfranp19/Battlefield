using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public Vector3 desplazamiento = new Vector3(0, 10, 15);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // asigna la posición del player
        this.transform.position = player.transform.position + desplazamiento;
    }
}
