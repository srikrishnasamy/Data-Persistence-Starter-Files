using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        GameManager.Instance.ExitGame();
    }
    
}
