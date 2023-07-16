using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBallCrank : MonoBehaviour
{
    
    private float speed = 100.0f;
    [SerializeField] private Transform crank;
    [SerializeField] GameObject basketBall;
    private bool willRotate = false;
    private AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(willRotate)
        {
            
            crank.transform.Rotate(Vector3.right, speed * Time.deltaTime);
        }
    }

    public void DropBasketBall()
    {
        StartCoroutine(StartBallGame());
    }

    IEnumerator StartBallGame()
    {
        audioSrc.Play();
        willRotate = true;
        yield return new WaitForSeconds(3);
        willRotate = false;
        basketBall.SetActive(true);
    }
}
