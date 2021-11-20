using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    public GameObject destroyVersion;

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    public void Destroy()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0.9339623f, 0.4407934f, 0.03964933f, 1);
        StartCoroutine(Death());
    }
}
