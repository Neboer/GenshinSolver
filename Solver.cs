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
    public class NoSolutionException : Exception
    {
        public NoSolutionException() : base() { }
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
        private float target_value; // 目标状态

        public Solver(float[] init_state, float[,] change_list, int m, float target = float.MaxValue)
        {
            mod = m;
            if(init_state.Length == change_list.GetLength(0) && change_list.GetLength(0) == change_list.GetLength(1))
            {
                count = init_state.Length;
                init_ve = DenseVector.OfArray(init_state);
                change_mt = DenseMatrix.OfArray(change_list);
                target_value = target;
            }
            else
            {
                throw new MalformedMatrixException();
            }
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
            if (target_value == float.MaxValue) // 默认目标，全部覆盖
            {
                for(float target = 1; target <= mod; target++)
                {
                    VectorF target_vt = DenseVector.Create(count, target) - init_ve;
                    SolutionTypes st = DiscussSolutionType(change_mt, target_vt);
                    if (st == SolutionTypes.Single)
                    {
                        VectorF solution_p = change_mt.Solve(target_vt);
                        result_list.Add(solution_p);
                    }
                }
            } else // 设置了目标。
            {
                VectorF target_vt = DenseVector.Create(count, target_value) - init_ve;
                SolutionTypes st = DiscussSolutionType(change_mt, target_vt);
                if (st == SolutionTypes.Single)
                {
                    VectorF solution_p = change_mt.Solve(target_vt);
                    result_list.Add(solution_p);
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

        public int final_value(int[] solution) // 输入解，得到根据这个解可以达到的最后的值。
        {
            // 取初值的首个进行计算
            int tmp = (int) Math.Round(init_ve[0]);
            for(int i = 0;i < solution.Length;i++)
            {
                tmp += ((int)Math.Round(change_mt.Column(0)[i]) * solution[i]);
            }
            int result = tmp % (int)mod;
            return (int)(result == 0?mod:result);
        }
        public (int[],int) solve() // 返回一组最优的解。如果最优解有多个，则返回其中的一个。返回一个解和一个解的结果。
        {
            List<VectorF> p_result = primitive_solve();
            if (p_result.Count == 0) throw new NoSolutionException();
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
            return (best_solution, final_value(best_solution));
        }
    }
}
