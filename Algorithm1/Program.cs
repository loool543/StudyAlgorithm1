namespace Algorithm1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player = new Player();
            board.Initialize(25, player);
            player.Initialize(1, 1, board);

            Console.CursorVisible = false;
            int lastTick = 0; //마지막으로 측정한 시간
            const int WAIT_TICK = 1000 / 30; //(경과 시간)1초는 1000밀리세컨드이기 때문에

            while (true)
            {
                //FPS 프레임
                //프레임은 그냥 이 루프가 1초에 몇번 반복되냐를 말하는 것

                #region 프레임관리
                int currentTick = System.Environment.TickCount; //현재시간, 절대적인 시간의 개념은 아님
                //특정 기준 ex)시스템이 시작되고 난 후에 밀리seconds
                //경과시간이 얼마인지가 중요하기 때문에 이런 경우에 TickCount 사용함.
                 
                //만약에 경과한 시간이 1/30초보다 작다면 continue
                if (currentTick - lastTick < WAIT_TICK) 
                    continue;
                int deltaTick = currentTick - lastTick;
                lastTick = currentTick;
                #endregion

                // 입력

                // 로직
                player.Update(deltaTick);

                // 렌더링
                Console.SetCursorPosition(0, 0);
                board.Render();                
            }
        }
    }
}
