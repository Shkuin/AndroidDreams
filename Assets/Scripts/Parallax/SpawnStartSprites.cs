using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStartSprites : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _backgrounds;
    [SerializeField] private List<SpriteRenderer> _botCity;
    [SerializeField] private List<GameObject> _midCity;
    void Start()
    {
        //SpawnMidCity();
        SpawnBackgroundAndBotCity();
    }

    void SpawnMidCity()
    {
        float cameraHalfHeight = Camera.main.orthographicSize;
        float cameraHalfWidth = cameraHalfHeight * Camera.main.aspect;

        Vector3 position = new Vector3(-cameraHalfWidth, -cameraHalfHeight, 0);
        float xPositionRightBottomCorner = position.x;
        while (xPositionRightBottomCorner < cameraHalfWidth)
        {
            for (int i = 0; i < _midCity.Count; ++i)
            {
                if (i == 0)
                {
                    Instantiate(_midCity[0], position, Quaternion.identity);
                    xPositionRightBottomCorner += _midCity[0].GetComponent<SpriteRenderer>().size.x;
                }
                else
                {
                    float prevBuildingWidth = _midCity[i - 1].GetComponent<SpriteRenderer>().size.x;
                    float curBuildingWidth = _midCity[i].GetComponent<SpriteRenderer>().size.x;
                    position += new Vector3(prevBuildingWidth + curBuildingWidth / 2, 0, 0);
                    Instantiate(_midCity[i], position, Quaternion.identity);
                }

                xPositionRightBottomCorner = position.x + _midCity[i].GetComponent<SpriteRenderer>().size.x;
                if (xPositionRightBottomCorner >= cameraHalfWidth)
                    return;
            }
        }


    }

    void SpawnBackgroundAndBotCity()
    {
        _backgrounds[0].transform.localPosition = new Vector3(0, 0, 0);
        _backgrounds[1].transform.localPosition = new Vector3(_backgrounds[0].bounds.size.x, 0, 0);
        _botCity[0].transform.localPosition = new Vector3(0, 0, 0);
        _botCity[1].transform.localPosition = new Vector3(_botCity[0].bounds.size.x, 0, 0);
    }
}
