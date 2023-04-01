using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private static GameController gameController;
    [SerializeField] private MapBorder Map;


    [Serializable]
    public struct MapBorder
    {
        public float maxY;
        public float minY;
        public float maxX;
        public float minX;

    }
    private void Awake() {
        gameController=this;
        
    }
    public static float GetMaxX()
    {
        return gameController.Map.maxX;


    }
    public static float GetMaxY()
    {
        return gameController.Map.maxY;


    }
    public static float GetMinX()
    {
        return gameController.Map.minX;


    }
    public static float GetMinY()
    {
        return gameController.Map.minY;


    }
    


}
