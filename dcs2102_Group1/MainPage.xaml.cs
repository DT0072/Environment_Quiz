using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SportsQuizApp
{
    public partial class MainWindow : Window
    {
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int correctAnswers = 0;
        private object questionText;
        private object option1;
        private object option2;
        private object option3;
        private object option4;
        private object option5;
        private object option6;

        public object Visibility { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeQuiz();
        }

        private void InitializeQuiz()
        {
            questions = new List<Question>
            {
                new Question("Question 1: Who won the last World Cup?", "A. France", "B. Brazil", "C. Germany", "D. Argentina", "A"),
                new Question("Question 2: In which sport do you score a 'hole-in-one'?", "A. Soccer", "B. Golf", "C. Tennis", "D. Basketball", "B"),
                new Question("Question 3: How many players are there in a standard soccer team?", "A. 11", "B. 7", "C. 5", "D. 9", "A"),
                new Question("Question 4: What is the national sport of Japan?", "A. Sumo Wrestling", "B. Karate", "C. Judo", "D. Baseball", "A"),
                new Question("Question 5: Who is the highest-scoring NBA player of all time?", "A. LeBron James", "B. Kobe Bryant", "C. Michael Jordan", "D. Kareem Abdul-Jabbar", "D"),
                new Question("Question 6: In which country did the sport of tennis originate?", "A. England", "B. France", "C. USA", "D. Australia", "A")
            };

            DisplayQuestion(currentQuestionIndex);
        }

        private void DisplayQuestion(int index)
        {
            if (index < questions.Count)
            {
                Question question = questions[index];
                questionText.Text = question.Text;
                option1.Content = question.Option1;
                option2.Content = question.Option2;
                option3.Content = question.Option3;
                option4.Content = question.Option4;

                option1.IsChecked = option2.IsChecked = option3.IsChecked = option4.IsChecked = false;
            }
            else
            {
                ShowResult();
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedOption = GetSelectedOption();

            if (selectedOption == questions[currentQuestionIndex].CorrectAnswer)
            {
                correctAnswers++;
            }

            currentQuestionIndex++;
            DisplayQuestion(currentQuestionIndex);
        }

        private string GetSelectedOption()
        {
            if (option1.IsChecked == true)
                return "A";
            if (option2.IsChecked == true)
                return "B";
            if (option3.IsChecked == true)
                return "C";
            if (option4.IsChecked == true)
                return "D";

            return "";
        }

        private void ShowResult()
        {
            double percentage = (correctAnswers * 100.0) / questions.Count;
            resultText.Text = $"Quiz Completed!\nYou got {correctAnswers} out of {questions.Count} questions correct.\nPercentage: {percentage}%";
            resultText.Visibility = Visibility.Visible;

            // Disable further interactions
            questionText.Visibility = option1.Visibility = option2.Visibility = option3.Visibility = option4.Visibility = nextButton.Visibility = Visibility.Hidden;
        }
    }
}
