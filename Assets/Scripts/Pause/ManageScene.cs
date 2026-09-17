using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script is reponsible for dealing with the scenes
public class ManageScene : MonoBehaviour
{
    [SerializeField] public int Scene;
    public void Destroying(string s)
    {
        SceneManager.UnloadSceneAsync(s);
    }

    public void Add(string s)
    {
        SceneManager.LoadScene(s, LoadSceneMode.Additive);
    }

    public void Change(string s)
    {
        SceneManager.LoadScene(s);
    }
}
