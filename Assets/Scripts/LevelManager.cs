using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

   private static int scene;
   public void NextLevel()
    {
        scene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(scene);
        Brick.resetNumberOfBricks();
    }
    public void BrickDestroyed()
    {
        if (Brick.numberOfBricks <= 0)
        {
            NextLevel();
        }
    }
    public void loadLevel1()
    {
        scene = 2;
        SceneManager.LoadScene(scene);
        Brick.resetNumberOfBricks();
    }
    public void Lose()
    {
        SceneManager.LoadScene(1);
    }
    public void Repaly()
    {
        SceneManager.LoadScene(scene);
        Brick.resetNumberOfBricks();

    }
    public void BackToStart()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitRequer()
    {
        Debug.Log("Aplication Quit Requested");
        Application.Quit();
    }
}
