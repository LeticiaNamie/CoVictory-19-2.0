using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
	int randomNumber;
	float time = 0, vaccineTime = 0;

	public GameObject HandSanitizer, News, HomemadeClothMask, FaceShield, SurgicalMask, PFF2FaceMask, FakeNews, FakeNews2, Virus, Virus2, Vaccine;
	public int gameLevel;

    void Start()
    {
    	Time.timeScale = 1;
    }

    void Update()
    {
        time = time + Time.deltaTime;
    	vaccineTime += Time.deltaTime;

    	if(gameLevel == 1 && vaccineTime >= 30)
	    {
	    	Vaccine.gameObject.SetActive(true);

	    	vaccineTime = 0;

	    	time = -1;
	    }
	    else if(gameLevel == 2 && vaccineTime >= 60)
	    {
	    	Vaccine.gameObject.SetActive(true);

	    	vaccineTime = 0;

	    	time = -1;
	    }
    	else if(time >= 2)
    	{
    		RandomItem();

    		time = 0;
    	}
    }

    void RandomItem()
    {
    	bool x = false;

    	do{

    		if(gameLevel == 1)
    		{
    			randomNumber = Random.Range(0,8);
    		}
    		else if(gameLevel == 2)
    		{
    			randomNumber = Random.Range(0,9);
    		}
    		else
    		{
    			randomNumber = Random.Range(0,10);
    		}

    		if(randomNumber == 0)
    		{
    			if(!HandSanitizer.activeSelf)
    			{
    				HandSanitizer.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    		else if (randomNumber == 1)
    		{
                if(!News.activeSelf)
    			{
    				News.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    		else if (randomNumber == 2)
    		{
    			if(!FaceShield.activeSelf)
    			{
    				FaceShield.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    		else if (randomNumber == 3)
    		{
    			if(!SurgicalMask.activeSelf)
    			{
    				SurgicalMask.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    		else if (randomNumber == 4)
    		{
    			if(!HomemadeClothMask.activeSelf)
    			{
    				HomemadeClothMask.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    		else if (randomNumber == 5)
    		{
    			if(!PFF2FaceMask.activeSelf)
    			{
    				PFF2FaceMask.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    		else if (randomNumber == 6 || randomNumber == 9)
    		{
    			if(!FakeNews.activeSelf)
    			{
    				FakeNews.gameObject.SetActive(true);
    				x = true;
    			}
    			else if(gameLevel == 3 && !FakeNews2.activeSelf)
    			{
    				FakeNews2.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    		else
    		{
    			if(!Virus.activeSelf)
    			{
    				Virus.gameObject.SetActive(true);
    				x = true;
    			}
    			else if((gameLevel == 2 || gameLevel == 3) && !Virus2.activeSelf)
    			{
    				Virus2.gameObject.SetActive(true);
    				x = true;
    			}
    		}

    	}while(x == false);
    }
}
