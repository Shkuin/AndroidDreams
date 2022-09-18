using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartSprites : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _backgrounds;
    [SerializeField] private List<SpriteRenderer> botCity;
    [SerializeField] private List<GameObject> midCity;

    void Start()
    {
        SpawnMidCity();
        SpawnBackgroundAndbotCity();
    }

    void SpawnMidCity()
    {
        float cameraHeight = 2f * Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        Vector3 position = new Vector3(-cameraWidth / 2, -cameraHeight / 2, 0);
        for (int i = 0; i < midCity.Count; ++i)
        {
            if (i == 0)
            {
                Instantiate(midCity[0], position, Quaternion.identity);
            }
            else
            {
                float prevBuildingWidth = midCity[i - 1].GetComponent<SpriteRenderer>().size.x;
                float curBuildingWidth = midCity[i].GetComponent<SpriteRenderer>().size.x;
                position += new Vector3(prevBuildingWidth + curBuildingWidth / 2, 0, 0);
                Instantiate(midCity[i], position, Quaternion.identity);
            }
        }
    }

    void SpawnBackgroundAndbotCity()
    {
        _backgrounds[0].transform.localPosition = new Vector3(0, 0, 0);
        _backgrounds[1].transform.localPosition = new Vector3(_backgrounds[0].bounds.size.x, 0, 0);
        botCity[0].transform.localPosition = new Vector3(0, 0, 0);
        botCity[1].transform.localPosition = new Vector3(botCity[0].bounds.size.x, 0, 0);
    }
}
