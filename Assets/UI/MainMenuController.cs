using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private Canvas menuCanvas;
    private Button category1Button;
    private Button category2Button;
    private Button category3Button;
    private Button quitButton;
    private QuestionController questionController;
    private CategoriesController categoriesController;

    private void Awake()
    {
        questionController = GameObject.Find("QuestionCanvas").GetComponent<QuestionController>();
        categoriesController = GameObject.Find("CategoryCanvas").GetComponent<CategoriesController>();
        menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        category1Button = GameObject.Find("Category1").GetComponent<Button>();
        category2Button = GameObject.Find("Category2").GetComponent<Button>();
        category3Button = GameObject.Find("Category3").GetComponent<Button>();
        quitButton = GameObject.Find("Quit").GetComponent<Button>();
    }

    private void OnEnable()
    {
        category1Button.onClick.AddListener(OnCategory1ButtonClicked);
        category2Button.onClick.AddListener(OnCategory2ButtonClicked);
        category3Button.onClick.AddListener(OnCategory3ButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClick);
        
    }

    private void OnDisable()
    {
        category1Button.onClick.RemoveListener(OnCategory1ButtonClicked);
        category2Button.onClick.RemoveListener(OnCategory2ButtonClicked);
        category3Button.onClick.RemoveListener(OnCategory3ButtonClicked);
        quitButton.onClick.RemoveListener(OnQuitButtonClick);
        
    }

    private void OnCategory1ButtonClicked()
    {
        menuCanvas.enabled = false;
        
        categoriesController.Enable();
        categoriesController.SetCategory(1);
        /*
        questionController.SetPossibleCards(Enumerable.Range(2, 131).ToList());
        
        questionController.enabled = false;
        questionController.enabled = true; // da bi se okinuo onEnable, ne treba
        questionController.Enable(); // da se prikaze canvas
        */
    }

    private void OnCategory2ButtonClicked()
    {
        menuCanvas.enabled = false;
        categoriesController.Enable();
        categoriesController.SetCategory(2);
        /*
        questionController.SetPossibleCards(Enumerable.Range(2, 131).ToList());

        questionController.enabled = false;
        questionController.enabled = true;
        questionController.Enable();
*/
    }

    private void OnCategory3ButtonClicked()
    {
        menuCanvas.enabled = false;
        categoriesController.Enable();
        categoriesController.SetCategory(3);
        /*
        questionController.SetPossibleCards(Enumerable.Range(2, 130).ToList());

        questionController.enabled = false;
        questionController.enabled = true;
        questionController.Enable();
        */
    }

    private void OnQuitButtonClick()
    {
        Application.Quit();
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
#endif        
    }
}
