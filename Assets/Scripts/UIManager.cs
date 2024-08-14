using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class UIManager : MonoBehaviour
{
    [SerializeField] Toggle testToggle;

    public void RestartGame() 
    {
        SceneManager.LoadScene("Asteroids");

        bool isToggleChecked = testToggle.isOn;

    }

}
