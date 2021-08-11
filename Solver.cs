using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Single;

using MatrixF = MathNet.Numerics.LinearAlgebra.Matrix<float>;
using VectorF = MathNet.Numerics.LinearAlgebra.Vector<float>;

namespace GenshinSolver
{
    public enum SolutionTypes
    {
        Single, // 线性方程组有一个解
        Infinite, // 线性方程组有无穷解
        None // 线性方程组无解
    }

    public class InfiniteSolutionException : Exception
    {
        public InfiniteSolutionException() : base() { }
    }

    public class NoneSolutionException : Exception
    {
        public NoneSolutionException() : base() { }
    }
    
    public class MalformedMatrixException : Exception
    {
        public MalformedMatrixException() : base() { }
    }

    class Solver
    {
        public int count; // 总共未知数个数
        public float mod; // 模数，可能取值为[1, mod]
        private MatrixF change_mt; // 变化列表，每一步的影响
        private VectorF init_ve; // 初始状态

        public Solver(float[] init_state, float[,] change_list, int m)
        {
            mod = m;
            count = init_state.Length;
            init_ve = DenseVector.OfArray(init_state);
            change_mt = DenseMatrix.OfArray(change_list);
        }
        
        private static SolutionTypes DiscussSolutionType(MatrixF m, VectorF v) // 判断线性方程组解的情况。
        {
            // 首先线性方程组的系数矩阵行列数必须相等
            if (m.RowCount == m.ColumnCount)
            {
                // 线性方程组有解的条件是系数矩阵的秩等于增广矩阵的秩
                int rankm = m.Rank();
                MatrixF augmented_m = m.InsertColumn(m.ColumnCount, v);
                int rankam = augmented_m.Rank();
                if (rankm == rankam)
                {
                    if (rankm != m.ColumnCount)
                    {
                        return SolutionTypes.Infinite;
                    } else
                    {
                        return SolutionTypes.Single;
                    }
                } else
                {
                    return SolutionTypes.None;
                }
            } else
            {
                throw new MalformedMatrixException();
            }

        }
        private List<VectorF> primitive_solve() // 初步求解，获得带有不完整模数的列表。
        {
            List<VectorF> result_list = new List<VectorF>();
            for(float target = 1; target <= mod; target++)
            {
                VectorF target_vt = DenseVector.Create(count, target) - init_ve;
                SolutionTypes st = DiscussSolutionType(change_mt, target_vt);
                if (st == SolutionTypes.Single)
                {
                    VectorF solution_p = change_mt.Solve(target_vt);
                    result_list.Add(solution_p);
                } else if (st == SolutionTypes.Infinite)
                {
                    throw new InfiniteSolutionException();
                } else if (st == SolutionTypes.None)
                {
                    throw new NoneSolutionException();
                }

            }
            return result_list;
        }

        private (int[], int) normalize_solution(VectorF solution) // 将一个解向量变为标准整数列表，返回标准化的结果和总步长。
        {
            int[] result = new int[count];
            int total_step = 0;
            float[] f = solution.ToArray();
            for(int i = 0; i < f.Length; i++)
            {
                int t = (int)Math.Round(f[i] % mod);
                if (t < 0) t += (int) mod;
                result[i] = t;
                total_step += t;
            }
            return (result, total_step);
        }

        public static float[,] generate_default_change_list(int count)
        {
            float[,] t = new float[count, count];
            for(int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if(Math.Abs(i - j) <= 1)
                    {
                        t[i, j] = 1;
                    } else
                    {
                        t[i, j] = 0;
                    }
                }
            }
            return t;
        }
        public int[] solve() // 返回一组最优的解。如果最优解有多个，则返回其中的一个。
        {
            List<VectorF> p_result = primitive_solve();
            int[] step_count = new int[p_result.Count];
            int minimal_step_count = int.MaxValue;
            int[] best_solution = new int[count];
            p_result.ForEach((VectorF solution) =>
            {
                var (current_solution, current_step) = normalize_solution(solution);
                if (current_step < minimal_step_count)
                {
                    minimal_step_count = current_step;
                    best_solution = current_solution;
                }
            });
            return best_solution;
        }
    }
}
