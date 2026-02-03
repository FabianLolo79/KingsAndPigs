using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    [Header("Movimiento")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float entradaHorizontal;

    private void Update()
    {
        entradaHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(entradaHorizontal, rb2D.linearVelocity.y);
    }
}
