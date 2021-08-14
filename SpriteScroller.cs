using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
	public float SpeedScale = 1f;
    public AudioClip scoreSound;
	float spriteWidth;

    void Start()
    {

    	Time.timeScale = 1;
        GameObject rightGO = Instantiate<GameObject>(gameObject, transform);
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;        
        Destroy(rightGO.GetComponent<SpriteScroller>());
        spriteWidth = sprite.bounds.size.x;
        rightGO.transform.localPosition = new Vector3(spriteWidth - 1, 0, 0);
    }

    void Update()
    {
        if (GameManager.Instance.GameOver)
            return;

        Vector3 curPos = transform.position;
        
        curPos.x -= GameManager.Instance.ScrollSpeed * SpeedScale * Time.deltaTime;

        curPos.x = curPos.x % (spriteWidth - 1);

        transform.position = curPos;
    }

}
