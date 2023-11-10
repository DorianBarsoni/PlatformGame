using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetTextLevel : MonoBehaviour
{
    [SerializeField] Text levelText;

    void Start()
    {
        string name = SceneManager.GetActiveScene().name;
        levelText.text = "Level " + name[name.Length - 1];
    }
}
