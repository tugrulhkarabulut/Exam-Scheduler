using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DiscreteMathProject
{
    public class Graph
    {
        public int[,] AdjacencyMatrix { get; }
        public string[] CourseNames { get; }

        public Graph(Dictionary<string, string[]> Courses) 
        {
            int totalCourses = Courses.Count();
            AdjacencyMatrix = new int[totalCourses, totalCourses];
            string[] courses = Courses.Keys.ToArray();
            CourseNames = courses;
            BuildGraph(Courses);
        }

        private void BuildGraph(Dictionary<string, string[]> Courses)
        {
            for (int i = 0; i < CourseNames.Length; i++)
            {
                for (int j = 0; j < CourseNames.Length; j++)
                {
                    if (CourseNames[i] != CourseNames[j])
                    {
                        string key = CourseNames[i];
                        string keyInner = CourseNames[j];
                        string[] studentsI = Courses[key].ToArray();
                        string[] studentsJ = Courses[keyInner].ToArray();
                        bool hasCommonStudents = false;
                        for (int k = 0; k < studentsI.Length; k++)
                        {
                            if (hasCommonStudents)
                            {
                                break;
                            }

                            for (int l = 0; l < studentsJ.Length; l++)
                            {
                                if (studentsI[k].Equals(studentsJ[l]))
                                {
                                    hasCommonStudents = true;
                                    break;
                                }
                            }
                        }

                        if (hasCommonStudents)
                        {
                            AdjacencyMatrix[i, j] = 1;
                            AdjacencyMatrix[j, i] = 1;
                        }
                    }
                }
            }
        }

        public int[] GetColors()
        {
            Queue<int> toBeVisited = new Queue<int>();
            int current;
            int[] colorOfVertices = new int[AdjacencyMatrix.GetLength(0)];
            bool[] visited = new bool[AdjacencyMatrix.GetLength(0)];

            for (int j = 0; j < visited.Length; j++)
            {
                if (!visited[j])
                {
                    toBeVisited.Enqueue(j);

                    while (toBeVisited.Count != 0)
                    {
                        current = toBeVisited.Dequeue();
                        visited[current] = true;

                        for (int i = 0; i < CourseNames.Length; i++)
                        {
                            if (AdjacencyMatrix[current, i] == 1)
                            {
                                if (colorOfVertices[i] == colorOfVertices[current])
                                {
                            
                                    colorOfVertices[i] = colorOfVertices[current] + 1;
                                }

                                if (!visited[i])
                                {
                                    toBeVisited.Enqueue(i);
                                }
                            }
                        }
                    }
                }
            }


            return colorOfVertices;
        }
    }
}
