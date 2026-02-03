using System;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    [Header("Movimiento")]
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float velocidadMovimiento;
    private float entradaHorizontal;

    private void Update()
    {
        entradaHorizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        ControlarMovimientoHorizontal();
    }

    private void ControlarMovimientoHorizontal()
    {
        rb2D.linearVelocity = new Vector2(entradaHorizontal * velocidadMovimiento, rb2D.linearVelocity.y);

        if ((entradaHorizontal > 0 && !MirandoALaDerecha()) || (entradaHorizontal < 0 && MirandoALaDerecha()))
        {
            Girar(); //utiliza la rotación Y en 180° ya que por flip queda mal el collider
            //porque los sprites están mal cortados o no tienen bien el centro del pivot

        }
    }

    private void Girar()
    {
       Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private bool MirandoALaDerecha()
    {
       return transform.localScale.x == 1;
    }
}
