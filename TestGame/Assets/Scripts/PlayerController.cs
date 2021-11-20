using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;


    private float _speed =5f;
    public void Move()
    {
        player.transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
