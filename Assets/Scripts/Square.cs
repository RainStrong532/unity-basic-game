using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameController;
    private float halfWidth, halfHeight;

    private int startTime, endTime;
    void Start()
    {
        gameController = GameObject.Find("GameController");
        Camera camera = Camera.main;
        startTime = (int)Time.time;
        endTime = 2;
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= endTime){
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        float posX, posY;
        posX = Random.Range(-halfWidth + 0.5f, halfWidth - 0.5f);
        posY = Random.Range(-halfHeight + 0.5f, halfHeight - 0.5f);
        gameObject.transform.position = new Vector3(posX, posY, gameObject.transform.position.z);
        startTime = (int)Time.time;
    }

    void OnMouseDown()
    {
        gameController.GetComponent<GameController>().ClickObj(0);
        UpdatePosition();
    }
}
