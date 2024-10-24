using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Exercise
{
    class Graph
    {
        int[,] adj = new int[6,6]
        {
            {0, 1, 0, 1, 0, 0 },
            {1, 0, 1, 1, 0, 0 },
            {0, 1, 0, 0, 0, 0 },
            {1, 1, 0, 0, 1, 0 },
            {0, 0, 0, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0 }
        };

        List<int>[] adj2 = new List<int>[]
        {
            new List<int>() { 1, 3 },
            new List<int>() { 0, 2, 3 },
            new List<int>() { 1 },
            new List<int>() { 0, 1, 4 },
            new List<int>() { 3, 5 },
            new List<int>() { 4 },

        };

        public void BFS(int start)
        {
            //BFS Breadth First Search
            //이거는 어떻게 하면 되냐면 시작점에서부터 가까운 지점부터 차례대로 탐색해나가는 방법
            //예약 시스템을 사용해서 예약을 미리 해놓고
            // 순서대로 예약에 따라서 방문하기 이런 구조!!
            // BFS에서는 각각의 이전노드 혹은, 몇번째 만에 왔는지 등을 기억할 수 있음
            bool[] visited = new bool[6];
            Queue<int> queue = new Queue<int>();
            int[] parent = new int[6];
            int[] distance = new int[6];

            queue.Enqueue(start);
            visited[start] = true;
            parent[start] = start;
            distance[start] = 0;


            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);

                for(int next = 0; next < 6; next++)
                {
                    if (adj[now, next] == 0)
                        continue;
                    else if (visited[next])
                        continue;
                    queue.Enqueue(next);
                    visited[next] = true;
                    parent[next] = now;
                    distance[next] = distance[now]+1;

                }
            }

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.BFS(0);
        }
    }
}
