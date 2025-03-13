    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;
    using Random = UnityEngine.Random;

    public class QuestionController : MonoBehaviour
    {
        [SerializeField] private int category = 1;
        [SerializeField] private int maxCards = 130;
        private int catNum = 0;
        private Canvas questionCanvas;
        private Canvas menuCanvas;
        private Canvas categoryCanvas;
        private Button nextButton;
        private Button returnButton;
        private Image card;
        private List<int> possibleCards;
        
        private void Awake()
        {
            
            questionCanvas = GameObject.Find("QuestionCanvas").GetComponent<Canvas>();
            
            menuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
            menuCanvas.enabled = true;
            
            categoryCanvas = GameObject.Find("CategoryCanvas").GetComponent<Canvas>();
            
            returnButton = GameObject.Find("Return").GetComponent<Button>();
            nextButton = GameObject.Find("Next").GetComponent<Button>();
            card = GameObject.Find("Card").GetComponent<Image>();
            
            possibleCards = Enumerable.Range(2, maxCards).ToList();
            
        }

        private void OnEnable()
        {
            Debug.Log("Enable: " + possibleCards.Count);
            returnButton.onClick.AddListener(OnReturnButtonClicked);
            nextButton.onClick.AddListener(OnNextButtonClicked);
        }

        private void OnDisable()
        {
            returnButton.onClick.RemoveListener(OnReturnButtonClicked);
            nextButton.onClick.RemoveListener(OnNextButtonClicked);
        }

        private void DisplayRandomCard()
        {
            if (category <= 0)
            {
                Debug.LogError("Invalid category. Cannot display card.");
                return;
            }
            Debug.Log("DisplayRandomCard: " + possibleCards.Count);
            if (possibleCards.Count > 0)
            {
                int index = Random.Range(0, possibleCards.Count - 1);
                string path = $"category{category}/{catNum}/{possibleCards[index]}";
                possibleCards.RemoveAt(index);

                Sprite sprite = Resources.Load<Sprite>(path);

                if (sprite != null)
                {
                    card.overrideSprite = sprite;
                    Debug.Log("Kartica: " + path);
                }
                else
                {
                    Debug.LogError($"Card not found: {path}");
                }
            }
            else
            {
                OnReturnButtonClicked();
            }
        }

        private void OnNextButtonClicked()
        {
            Debug.Log("OnNextButtonClicked: " + possibleCards.Count);
            DisplayRandomCard();
        }

        private void OnReturnButtonClicked()
        {
            categoryCanvas.enabled = true;
            Disable();
        }

        public void SetCategory(int category)
        {
            Debug.Log("SetCategory: " + possibleCards.Count);
            this.category = category;
            maxCards = category == 3 ? 130 : 131; 
            
            DisplayRandomCard();
        }

        public void SetPossibleCards(List<int> possibleCards)
        {
            Debug.Log("PossibleCards set to:" + possibleCards.Count);
            this.possibleCards = possibleCards;
        }

        public void SetCatNum(int catNum)
        {
            this.catNum = catNum;
        }

        public void Disable()
        {
            questionCanvas.enabled = false;
        }

        public void Enable()
        {
            questionCanvas.enabled = true;
        }
    }
