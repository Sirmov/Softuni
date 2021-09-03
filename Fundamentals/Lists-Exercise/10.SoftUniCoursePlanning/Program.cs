using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "course start")
            {
                string[] commandArgs = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Add")
                {
                    AddLesson(lessons, commandArgs[1]);
                }
                else if (commandArgs[0] == "Insert")
                {
                    InsertLesson(lessons, int.Parse(commandArgs[2]), commandArgs[1]);
                }
                else if (commandArgs[0] == "Remove")
                {
                    RemoveLesson(lessons, commandArgs[1]);
                }
                else if (commandArgs[0] == "Swap")
                {
                    SwapLessons(lessons, commandArgs[1], commandArgs[2]);
                }
                else if (commandArgs[0] == "Exercise")
                {
                    AddExercise(lessons, commandArgs[1]);
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessons[i]}");
            }
        }

        static void SwapLessons(List<string> lessons, string firstLesson, string secondLesson)
        {
            if (!lessons.Contains(firstLesson) || !lessons.Contains(secondLesson))
            {
                return;
            }
            bool isFirstExercise = lessons.Contains(firstLesson + "-Exercise");
            bool isSecondExercise = lessons.Contains(secondLesson + "-Exercise");

            int firstIndex = lessons.IndexOf(firstLesson);
            int secondIndex = lessons.IndexOf(secondLesson);

            int firstExercise = -1;
            int secondExercise = -1;

            if (isFirstExercise)
            {
                firstExercise = lessons.IndexOf(firstLesson + "-Exercise");
            }

            if (isSecondExercise)
            {
                secondExercise = lessons.IndexOf(secondLesson + "-Exercise");
            }

            string temp = firstLesson;
            lessons[firstIndex] = lessons[secondIndex];
            lessons[secondIndex] = temp;

            if (isFirstExercise)
            {
                lessons.RemoveAt(firstExercise);
                firstIndex = lessons.IndexOf(firstLesson);
                lessons.Insert(firstIndex + 1, firstLesson + "-Exercise");
            }

            if (isSecondExercise)
            {
                lessons.RemoveAt(secondExercise);
                secondIndex = lessons.IndexOf(secondLesson);
                lessons.Insert(secondIndex + 1, secondLesson + "-Exercise");
            }
        }

        static void AddExercise(List<string> lessons, string lessonTitle)
        {
            if (lessons.Contains(lessonTitle) && !lessons.Contains(lessonTitle + "-Exercise"))
            {
                lessons.Insert(lessons.IndexOf(lessonTitle) + 1, lessonTitle + "-Exercise");
            }
            else if (!lessons.Contains(lessonTitle) && !lessons.Contains(lessonTitle + "-Exercise"))
            {
                lessons.Add(lessonTitle);
                lessons.Add(lessonTitle + "-Exercise");
            }
        }

        static void RemoveLesson(List<string> lessons, string lessonTitle)
        {
            if (lessons.Contains(lessonTitle))
            {
                lessons.Remove(lessonTitle);
            }

            if (lessons.Contains(lessonTitle + "-Exercise"))
            {
                lessons.Remove(lessonTitle + "-Exercise");
            }
        }

        static void InsertLesson(List<string> lessons, int index, string lessonTitle)
        {
            if (!lessons.Contains(lessonTitle))
            {
                lessons.Insert(index, lessonTitle);
            }
        }

        static void AddLesson(List<string> lessons, string lessonTitle)
        {
            if (!lessons.Contains(lessonTitle))
            {
                lessons.Add(lessonTitle);
            }
        }
    }
}
