using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuizApp.ViewModels;

namespace QuizApp.Pages
{
    public class GameModel : PageModel
    {
        public List<QuizModel> listQuiz { get; set; }
        public void OnGet()
        {
            //list of quiz questions along with options and correct answer
            listQuiz = new List<QuizModel>
                {
                    new QuizModel
                    {
                        QuestionID=1,
                        Question="What is the capital of the USA?",
                        Option1="New York",
                        Option2="Washington DC",
                        Option3="Texas",
                        Option4="Colorado",
                        CorrectOption="Washington DC"
                    },
                    new QuizModel
                    {
                        QuestionID=2,
                        Question="What is the capital of GERMANY?",
                        Option1="Berlin",
                        Option2="Munich",
                        Option3="Frankfurt",
                        Option4="Hamburg",
                        CorrectOption="Berlin"
                    },
                    new QuizModel
                    {
                        QuestionID=3,
                        Question="What is the capital of AUSTRALIA?",
                        Option1="Canberra",
                        Option2="Sydney",
                        Option3="Victoria",
                        Option4="Perth",
                        CorrectOption="Canberra"
                    },
                    new QuizModel
                    {
                        QuestionID=4,
                        Question="What is the capital of CHINA?",
                        Option1="Shanghai",
                        Option2="Beijing",
                        Option3="Wuhan",
                        Option4="Teinjin",
                        CorrectOption="Beijing"
                    },
                    new QuizModel
                    {
                        QuestionID=5,
                        Question="What is the capital of SPAIN?",
                        Option1="Barcelona",
                        Option2="Madrid",
                        Option3="Granada",
                        Option4="Valencia",
                        CorrectOption="Madrid"
                    },
                    new QuizModel
                    {
                        QuestionID=6,
                        Question="What is the capital of CANADA?",
                        Option1="Vancouver",
                        Option2="Montreal",
                        Option3="Toronto",
                        Option4="Ottowa",
                        CorrectOption="Ottowa"
                    },
                    new QuizModel
                    {
                        QuestionID=7,
                        Question="What is the capital of RUSSIA?",
                        Option1="Kazan",
                        Option2="Saint Petersburg",
                        Option3="Moscow",
                        Option4="Volgograd",
                        CorrectOption="Moscow"
                    },
                    new QuizModel
                    {
                        QuestionID=8,
                        Question="What is the capital of BRAZIL?",
                        Option1="Rio de Janeiro",
                        Option2="Sao Paulo",
                        Option3="Brasilia",
                        Option4="Salvador",
                        CorrectOption="Brasilia"
                    },
                    new QuizModel
                    {
                        QuestionID=9,
                        Question="What is the capital of INDIA?",
                        Option1="Hyderabad",
                        Option2="Mumbai",
                        Option3="Utter Pradesh",
                        Option4="Delhi",
                        CorrectOption="Delhi"
                    },
                    new QuizModel
                    {
                        QuestionID=10,
                        Question="What is the capital of POLAND?",
                        Option1="Poznan",
                        Option2="Lublin",
                        Option3="Warsaw",
                        Option4="Krakow",
                        CorrectOption="Warsaw"
                    }
                };
        }
    }
}