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
        if (Input.GetKeyDown(KeyCode.F1))
        {
            tank.SetActive(false);
            van.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            van.SetActive(false);
            tank.SetActive(true);
        }

    }
}
