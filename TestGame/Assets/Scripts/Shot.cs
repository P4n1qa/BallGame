using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public GameObject player;


    private int _power = 0;
    private int _maxPower = 4;
    private Vector3 _scaleChange;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(IncreasePower());
        }
        if (Input.GetMouseButtonUp(0))
        {
            SCaleBullet();
            SCalePlayer();
            Shoot();
            StopAllCoroutines();          
        }
        Debug.Log(_power);
        Lose();
    }

    private IEnumerator IncreasePower()
    {
        while (_power < _maxPower)
        {
            _power++;
            yield return new WaitForSeconds(1f);
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        _power = 0;
    }
    private void SCaleBullet()
    {
        switch (_power)
        {
            case 1:
                bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                _scaleChange = new Vector3(-0.1f, -0.1f, -0.1f);
                bullet.GetComponent<Bullet>().radius = 0f;
                break;
            case 2:
                bullet.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                _scaleChange = new Vector3(-0.2f, -0.2f, -0.2f);
                bullet.GetComponent<Bullet>().radius=1f;             
                break;
            case 3:
                bullet.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                _scaleChange = new Vector3(-0.4f, -0.4f, -0.4f);
                bullet.GetComponent<Bullet>().radius = 2f;
                break;
            case 4:
                bullet.transform.localScale = player.transform.localScale;
                _scaleChange = -player.transform.localScale;
                break;
        }
    }
    private void SCalePlayer()
    {
        if (_power == 1)
        {
            player.transform.localScale += _scaleChange;
        }
        if (_power == 2)
        {
            player.transform.localScale += _scaleChange;
        }
        if (_power == 3)
        {
            player.transform.localScale += _scaleChange;
        }
        if (_power == 4)
        {
            player.transform.localScale += _scaleChange;
        }
    }
    private void Lose()
    {
        if(player.transform.localScale.x <= 0.1f) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
