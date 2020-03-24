using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public float count;
    public GameObject startCount;
    public GameObject puppymanager;
    public GameObject ball;
    public GameObject sensei;
    public GameObject neko;
    bool startcount = true;
    
    // Start is called before the first frame update
    private void Awake()
    {
        startCount.gameObject.SetActive(true);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startCount.GetComponent<Text>().text = count.ToString("f0");
        if (startcount == true) {
            count -= Time.deltaTime;
            if (count <= 0)
            {
                startCount.gameObject.SetActive(false);
                puppymanager.GetComponent<PuppyManager>().enabled = true;
                ball.GetComponent<StateMachineBall>().enabled = true;
                sensei.GetComponent<Animator>().enabled = true;
                neko.GetComponent<Animator>().enabled = true;
                startcount = false;
            }
        }
    }
}
