using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject playerGround;
    public GameObject player;
    public LayerMask whatIsEnemy;
    public Transform checkEnemy;


    public Vector3 _hitBoxSize = Vector3.one;


    private float _z;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        ScalePlayerGround();
    }
    private void FixedUpdate()
    {
        CheckEnemy();
    }
    private void ScalePlayerGround()
    {
        _z = player.transform.localScale.z / 10;
        playerGround.transform.localScale = new Vector3(2.5f, 1f, _z);
        _hitBoxSize.z = playerGround.transform.localScale.z*5;
    }
    private void CheckEnemy()
    {
        Collider[] colliders = Physics.OverlapBox(checkEnemy.position, _hitBoxSize, Quaternion.identity, whatIsEnemy);
        if (colliders.Length==0)
        {
            playerController.Move();
        }
    }
}
