using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float count;
    public GameObject startCount;
    public GameObject puppymanager;
    bool managerspawned;
    // Start is called before the first frame update
    private void Awake()
    {
        startCount.gameObject.SetActive(true);
    }
    void Start()
    {
        count = 3;
        managerspawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        startCount.GetComponent<Text>().text = count.ToString("f0");
        count -= Time.deltaTime;
        if (count <= 0)
        {
            startCount.gameObject.SetActive(false);
            if (managerspawned == false)
            {
                Instantiate(puppymanager, transform.position, Quaternion.identity);
                managerspawned = true;
            }
        }
    }
}
