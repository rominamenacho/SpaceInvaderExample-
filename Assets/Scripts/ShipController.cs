using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private Vector2 movement;

    public float speed = 1f;
    private float maxSpeed = 10.0f;
    private float vel_imp = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        //pos aleatoria en x cdo arranca 
        float x = Random.Range(-25, 26);
        rigidbody.position = new Vector2(x, 0);

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector2(moveHorizontal, 0f);

    }

    //fixedUpdate se llama en cada fixed frame-rate frame
    //50 llamadas por segundo por defecto
    private void FixedUpdate()
    {
        //limite velocidad maxima
        speed += vel_imp;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        //aplica la fuerza al rigidbody2d
        rigidbody.AddForce(movement * speed * 5f);
    }
}
