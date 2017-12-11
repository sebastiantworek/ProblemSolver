using Algorithms.DataStructures.Permutations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game15
{
    public class Board
    {
        public const int Width = 4;
        public const int Heigh = 3;
        public const int Size = Width * Heigh;
        public const int Blank = 0;

        private List<int> _fields;

        public void InitRandom()
        {
            var permutation = PermutationsUtil.GetRandomPermutation(Size);
            Init(permutation);
        }

        public void Init(List<int> permutation)
        {
            if (permutation.Count != Size)
                throw new ArgumentException("Invalid permutation size");

            _fields = new List<int>(permutation);
        }

        public void Init()
        {
            Init(PermutationsUtil.GetIdentity(Size));
        }

        public int this[int x, int y]
        {
            get
            {
                return _fields[PositionToIndex(x, y)];
            }
            set
            {
                _fields[PositionToIndex(x, y)] = value;
            }
        }

        public int PositionToIndex(int x, int y)
        {
            int index = y * Width + x;
            if (index >= Size)
                throw new IndexOutOfRangeException();

            return index;
        }

        public (int x, int y) IndexToPosition(int index)
        {
            if (index >= Size)
                throw new IndexOutOfRangeException();
            return (x: index % Width, y: index / Width);
        }

        public int FindIndex(int field)
        {
            return _fields.IndexOf(field);
        }

        public (int x, int y) FindPostion(int field)
        {
            int index = FindIndex(field);
            return IndexToPosition(index);
        }

        public Board Clone()
        {
            var result = new Board();
            result.Init(_fields);
            return result;
        }

        public bool Move(Direction direction)
        {
            var blankPosition = FindPostion(Blank);
            (int x, int y) newPosition;
            switch (direction)
            {
                case Direction.Top:
                    newPosition = (x: blankPosition.x, y: blankPosition.y - 1);
                    break;
                case Direction.Down:
                    newPosition = (x: blankPosition.x, y: blankPosition.y + 1);
                    break;
                case Direction.Left:
                    newPosition = (x: blankPosition.x - 1, y: blankPosition.y);
                    break;
                case Direction.Right:
                    newPosition = (x: blankPosition.x + 1, y: blankPosition.y);
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (newPosition.x < 0 || newPosition.x >= Width)
                return false;

            if (newPosition.y < 0 || newPosition.y >= Heigh)
                return false;

            this[blankPosition.x, blankPosition.y] = this[newPosition.x, newPosition.y];
            this[newPosition.x, newPosition.y] = Blank;
            return true;

        }

        public override bool Equals(object obj)
        {
            var board = obj as Board;

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Heigh; j++)
                    if (this[i, j] != board[i, j])
                        return false;
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 1957759084;
            for(int i=0;i<Size;i++)
                hashCode = hashCode * -1521134295 + _fields[i];
            return hashCode;
        }
    }
}
