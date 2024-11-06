using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm1
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        List<T> _heap = new List<T>();

        public void Push(T value)
        {
            _heap.Add(value);
            int now = _heap.Count - 1;

            while (now > 0)
            {
                int next = (now - 1) / 2;
                if (_heap[now].CompareTo(_heap[next]) <= 0)
                    break;
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                now = next;
            }
        }
        public T Pop()
        {
            //root 노드의 값을 일단 뺴오고
            //정렬을 해줘야 해!
            //마지막 노드의 값을 root에 넣는다
            //그리고 위에서부터 아래로 내리기
            T ret = _heap[0];
            int lastIndex = _heap.Count - 1;

            //0으로 만들어주고 
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);

            lastIndex = _heap.Count - 1;

            int now = 0;

            while (now <= lastIndex)
            {
                //parent노드 = now -1 /2
                //child노드 왼쪽 : now*2 +1 오른쪽 now*2+1
                int left = now * 2 + 1;
                int right = now * 2 + 2;

                int next = now;
                //크기가 heap의 크기를 넘어가면 안됨
                if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
                    next = left;
                if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
                    next = right;

                if (next == now)
                    break;

                //두 값을 교체하기를 안했네..
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;
                // 검사 위치를 이동한다.
                now = next;
            }

            return ret;
        }

        public int Count { get { return _heap.Count; } }
    }
}
