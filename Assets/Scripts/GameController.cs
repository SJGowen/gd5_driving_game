using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject van;
    public GameObject tank;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            tank.SetActive(false);
            van.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            van.SetActive(false);
            tank.SetActive(true);
        }

    }
}
