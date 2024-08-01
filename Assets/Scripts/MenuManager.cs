using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ToEasy()
    {
        SceneManager.LoadScene("GameCard8");
    }

    public void ToMeduim()
    {
        SceneManager.LoadScene("GameCard12");
    }

    public void ToHard()
    {
        SceneManager.LoadScene("GameCard18");
    }
}