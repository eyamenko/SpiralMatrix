namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrix = GetSpiralMatrix(4);

            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    System.Console.Write("{0,-5}", matrix[y, x]);
                }

                System.Console.WriteLine();
            }
        }

        static int[,] GetSpiralMatrix(int n)
        {
            var matrix    = new int[n, n];
            var direction = Direction.RIGHT;        // initial direction
            int x         = 0, y               = 0; // initial coordinates
            int steps     = 2, currentStep     = 1; // steps
            int movements = n, currentMovement = 0; // movements

            for (int i = 1; i <= n * n; i++)
            {
                matrix[y, x] = i;

                if (++currentMovement == movements)
                {
                    currentMovement = 0;

                    if (++currentStep == steps)
                    {
                        --movements;
                        currentStep = 0;
                    }

                    switch (direction)
                    {
                        case Direction.RIGHT:
                            direction = Direction.DOWN;
                            break;
                        case Direction.DOWN:
                            direction = Direction.LEFT;
                            break;
                        case Direction.LEFT:
                            direction = Direction.UP;
                            break;
                        case Direction.UP:
                            direction = Direction.RIGHT;
                            break;
                    }
                }

                switch (direction)
                {
                    case Direction.RIGHT:
                        ++x;
                        break;
                    case Direction.DOWN:
                        ++y;
                        break;
                    case Direction.LEFT:
                        --x;
                        break;
                    case Direction.UP:
                        --y;
                        break;
                }
            }

            return matrix;
        }

        enum Direction
        {
            RIGHT,
            DOWN,
            LEFT,
            UP,
        }
    }
}
