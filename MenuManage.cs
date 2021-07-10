using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManage : MonoBehaviour
{


    public void ChangeLvl(int num)
    {
        SceneManager.LoadScene(num);
    }
}
