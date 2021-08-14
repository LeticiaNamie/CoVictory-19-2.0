using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour
{
	public int gameLevel;
	public float SpeedScale = 7f;
	
	bool clicked = false;
	float time = 0; 

    void Start()
    {
        Time.timeScale = 1;
    }

    public void ResetItem(GameObject obj)
    {
    	Vector3 curPos = obj.transform.position;

    	curPos.x = 620;

    	transform.position = new Vector3(curPos.x, curPos.y, curPos.z);

    	obj.SetActive(false);
    }

    void Update()
    {
    	time = time + Time.deltaTime;

        if (GameManager.Instance.GameOver)
            return;

        Vector3 curPos = transform.position;
        
        if(gameLevel == 3)
        {
        	SpeedScale += 0.007f*time;
        }

        curPos.x -= GameManager.Instance.ScrollSpeed * SpeedScale * Time.deltaTime;

        transform.position = curPos;

        if(curPos.x < -1380)
        {
        	ResetItem(gameObject);
        }

        if(clicked)
        {
        	if(Input.GetButtonDown("Fire1") && gameObject.CompareTag("FN or Virus"))
        	{
        		PlayerController pc = GameObject.FindObjectOfType<PlayerController>();
        		pc.ChangeXp(15, 2);

        		ResetItem(gameObject);

        		clicked = false;
        	}
        }
    }

    void OnMouseEnter()
    {
    	clicked = true;
    }
}
