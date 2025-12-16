
using UnityEngine;
using UnityEngine.InputSystem;

public class WorldLocalScript : MonoBehaviour
{
    //Componente pLayerInput, gestión del input de Unity
   private PlayerInput input;
    //Vector que almacenará el movimiento obtenido del input
   private Vector2 movement;
    //Vector director del movimiento en el espacio 3D
   private Vector3 direction;
   private Vector3 directionLocalToWorld;

    [Header("Parameters")]
    [SerializeField] private float speed = 5.0f;
     void Awake()
    {
        //Obtenemos el componente
        input = GetComponent<PlayerInput>();
    }

     void Update()
    {
        movement = input.actions["Move"]. ReadValue<Vector2>();
        //Movimiento con respecto del mundo
        direction = new Vector3(movement.x, 0f, movement.y);
        //Movimiento con respecto al objeto
        directionLocalToWorld = transform.TransformDirection(direction);
        transform.position += directionLocalToWorld * speed * Time.deltaTime;
        Debug.Log(movement);
    }
}
