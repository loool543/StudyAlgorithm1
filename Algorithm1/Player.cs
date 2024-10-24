﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm1
{
    class Pos
    {
        public Pos(int y, int x) { Y = y; X = x; } 
        public int Y;
        public int X;
    }
    internal class Player
    {
        public int PosY { get; private set; }

        public int PosX {  get; private set; }
        Random random = new Random();

        enum Dir{
            up = 0,
            left = 1,
            down = 2,
            right = 3
        }

        private int _dir = (int)Dir.up;
        Board _board;
        List<Pos> _points = new List<Pos>();

        public void Initialize(int posY, int posX, Board board)
        {
            PosY = posY;
            PosX = posX;
            _board = board;

            //RightHand();
            BFS();

        }

        void BFS()
        {
            int[] deltaY = new int[] {-1, 0, 1, 0 };
            int[] deltaX = new int[] { 0, -1, 0, 1};

            bool
        }

        void RightHand()
        {
            int[] moveY = { -1, 0, 1, 0 };
            int[] moveX = { 0, -1, 0, 1 };
            int[] rightY = { 0, -1, 0, 1 };
            int[] rightX = { 1, 0, -1, 0 };


            while (PosY != _board.DestY || PosX != _board.DestX)
            {
                //오른쪽으로 갈 수 있으면 오른쪽으로 90도  회전하고 앞으로 1보 이동
                if (_board.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Board.TileType.Empty)
                {
                    _dir = (_dir - 1 + 4) % 4; //오른쪽으로 90도 회전
                    PosY = PosY + moveY[_dir];
                    PosX = PosX + moveX[_dir];

                    _points.Add(new Pos(PosY, PosX));
                }
                else if (_board.Tile[PosY + moveY[_dir], PosX + moveX[_dir]] == Board.TileType.Empty)     //그렇지 않고 정면으로 갈 수 있으면 정면으로 앞으로 1보 이동           
                {
                    PosY = PosY + moveY[_dir];
                    PosX = PosX + moveX[_dir];

                    _points.Add(new Pos(PosY, PosX));

                }
                else
                {
                    _dir = (_dir + 1) % 4;  // 왼쪽으로 90도 회전
                }
            }

        }

        const int MOVE_TICK = 100; // 100ms는 0.1초 1000ms가 1초니까
        int _sumTick = 0;
        int index = 0;

        public void Update(int deltaTick)
        {
            if (index >= _points.Count)
                return;
            _sumTick += deltaTick;
            if (_sumTick >= MOVE_TICK)
            {
                _sumTick = 0;

                PosY = _points[index].Y;
                PosX = _points[index].X;
                index++;
            }

        }
    }
}