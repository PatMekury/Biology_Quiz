using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public string sceneName;
    public GameObject[] plantDropZones;
    public GameObject[] animalDropZones;
    public GameObject[] combinedDropZones;

    public GameObject[] plantCorrectAnswers;
    public GameObject[] animalCorrectAnswers;
    public GameObject[] combinedCorrectAnswers;

    public Sprite checkSprite;
    public Sprite xSprite;
    public Sprite nillSprite;

    private int score = 0;

    public Text scoreText;

    public void SubmitAnswers()
    {
        score = 0;

        CheckAnswers(plantDropZones, plantCorrectAnswers);
        CheckAnswers(animalDropZones, animalCorrectAnswers);
        CheckAnswers(combinedDropZones, combinedCorrectAnswers);

        scoreText.text = "Score: " + score.ToString();
    }

    void CheckAnswers(GameObject[] dropZones, GameObject[] correctAnswers)
    {
        foreach (GameObject dropZone in dropZones)
        {
            ItemSlot itemSlot = dropZone.GetComponent<ItemSlot>();
            if (itemSlot != null && itemSlot.currentObjectInSlot != null)
            {
                DragDrop droppedObject = itemSlot.currentObjectInSlot;
                bool isCorrect = IsCorrectAnswer(droppedObject.parentGameObject, correctAnswers);
                ShowResult(itemSlot.resultDisplay, isCorrect);
                if (isCorrect)
                {
                    score++;
                }
            }
        }
    }

    bool IsCorrectAnswer(GameObject droppedObject, GameObject[] correctAnswers)
    {
        // Compare the dropped object to the correct answers array
        foreach (GameObject correctAnswer in correctAnswers)
        {
            if (droppedObject == correctAnswer)
            {
                return true;
            }
        }
        return false;
    }

    void ShowResult(GameObject resultDisplay, bool isCorrect)
    {
        Image resultImage = resultDisplay.GetComponent<Image>();
        if (isCorrect)
        {
            // Change sprite to check sprite for correct answers
            resultImage.sprite = checkSprite;
        }
        else
        {
            // Change sprite to x sprite for incorrect answers
            resultImage.sprite = xSprite;
        }
    } 

    public void Retry()
    {
        SceneManager.LoadScene(sceneName);
    }
}