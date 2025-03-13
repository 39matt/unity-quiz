using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CategoriesController : MonoBehaviour
    {
        private QuestionController questionController;
        private Canvas menuCanvas;
        private Canvas categoriesCanvas;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Button returnButton;
        private int category;
        
        private void Awake()
        {
            questionController = GameObject.Find("QuestionCanvas").GetComponent<QuestionController>();
            menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
            categoriesCanvas = GameObject.Find("CategoryCanvas").GetComponent<Canvas>();
            button1 = GameObject.Find("Button1").GetComponent<Button>();
            button2 = GameObject.Find("Button2").GetComponent<Button>();
            button3 = GameObject.Find("Button3").GetComponent<Button>();
            button4 = GameObject.Find("Button4").GetComponent<Button>();
            button5 = GameObject.Find("Button5").GetComponent<Button>();
            button6 = GameObject.Find("Button6").GetComponent<Button>();
            button7 = GameObject.Find("Button7").GetComponent<Button>();
            button8 = GameObject.Find("Button8").GetComponent<Button>();
            button9 = GameObject.Find("Button9").GetComponent<Button>();
            button10 = GameObject.Find("Button10").GetComponent<Button>();
            button11 = GameObject.Find("Button11").GetComponent<Button>();
            button12 = GameObject.Find("Button12").GetComponent<Button>();
            button13 = GameObject.Find("Button13").GetComponent<Button>();
            returnButton = GameObject.Find("ReturnButton").GetComponent<Button>();
        }

        private void OnEnable()
        {
            button1.onClick.AddListener(delegate{OnClick(1);});
            button2.onClick.AddListener(delegate{OnClick(2);});
            button3.onClick.AddListener(delegate{OnClick(3);});
            button4.onClick.AddListener(delegate{OnClick(4);});
            button5.onClick.AddListener(delegate { OnClick(5); });
            button6.onClick.AddListener(delegate { OnClick(6); });
            button7.onClick.AddListener(delegate { OnClick(7); });
            button8.onClick.AddListener(delegate { OnClick(8); });
            button9.onClick.AddListener(delegate { OnClick(9); });
            button10.onClick.AddListener(delegate { OnClick(10); });
            button11.onClick.AddListener(delegate { OnClick(11); });
            button12.onClick.AddListener(delegate { OnClick(12); });
            button13.onClick.AddListener(delegate { OnClick(13); });
            returnButton.onClick.AddListener(OnReturnClick);

        }

        private void OnDisable()
        {
            button1.onClick.RemoveAllListeners();
            button2.onClick.RemoveAllListeners();
            button3.onClick.RemoveAllListeners();
            button4.onClick.RemoveAllListeners();
            button5.onClick.RemoveAllListeners();
            button6.onClick.RemoveAllListeners();
            button7.onClick.RemoveAllListeners();
            button8.onClick.RemoveAllListeners();
            button9.onClick.RemoveAllListeners();
            button10.onClick.RemoveAllListeners();
            button11.onClick.RemoveAllListeners();
            button12.onClick.RemoveAllListeners();
            button13.onClick.RemoveAllListeners();
            returnButton.onClick.RemoveAllListeners();
        }

        private void OnClick(int number)
        {
            Disable();
            if (category == 3 && (number == 3 || number == 2 || number == 9))
            {
                questionController.SetPossibleCards(Enumerable.Range(0, 9).ToList());
                
            }
            else
            {
                questionController.SetPossibleCards(Enumerable.Range(0, 10).ToList());
            }
            questionController.SetCatNum(number);
            questionController.SetCategory(category);
            questionController.Enable();
        }
        private void OnReturnClick()
        {
            menuCanvas.enabled = true;
            Disable();
        }

        public void SetCategory(int category)
        {
            this.category = category;
            questionController.SetCategory(category);
        }
        public void Enable()
        {
            categoriesCanvas.enabled = true;
        }

        public void Disable()
        {
            categoriesCanvas.enabled = false;
        }
    }
}