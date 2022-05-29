using UnityEngine;
using TMPro;

namespace ArgonAssault
{
    public class ScoreBoard : MonoBehaviour
    {
        int _score;
        TextMeshProUGUI _scoreText;

        private void Start()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            UpdateScoreDisplay();
        }

        public void IncreaseScore(int amountToAdd)
        {
            //event
            _score += amountToAdd;
            UpdateScoreDisplay();
        }

        void UpdateScoreDisplay() => _scoreText.text = _score.ToString();
    }
}
