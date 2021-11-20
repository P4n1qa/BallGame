using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] GameObject doorObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorObj.SetActive(true);
        }
    }
}
