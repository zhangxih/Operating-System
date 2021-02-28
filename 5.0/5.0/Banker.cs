using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _5._0
{
    class Banker
    {
		static int[] available = new int[3];
		static int[,] max = new int[5, 3];
		static int[,] allocation = new int[5, 3];
		static int[,] need = new int[5, 3];
		static int[] request = new int[3];

		int process;

		public void getData()
		{
			Console.Write("请输入A,B,C三类资源的数目：");
			for (int i = 0; i < 3; i++)
			{
				available[i] = int.Parse(Console.ReadLine());
			}
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("请输入进程" + i + "对A,B,C三类资源的最大需求");
				for (int j = 0; j < 3; j++)
				{
					max[i, j] = int.Parse(Console.ReadLine());
				}
			}
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("请输入进程" + i + "已分配的A,B,C三类资源数");
				for (int j = 0; j < 3; j++)
				{
					allocation[i, j] = int.Parse(Console.ReadLine());
				}
			}
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					need[i, j] = max[i, j] - allocation[i, j];
				}
			}
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					available[i] -= allocation[j, i];
				}
			}
		}

		public void GetResource()
		{
			Console.WriteLine("请输入申请资源的进程");
			int thread = int.Parse(Console.ReadLine());
			this.process = thread;
			Console.WriteLine("请输入申请的资源");
			for (int i = 0; i < 3; i++)
			{
				request[i] = int.Parse(Console.ReadLine());
			}
			if (request[0] > need[thread, 0] || request[1] > need[thread, 1] || request[2] > need[thread, 2])
			{
				Console.WriteLine(thread + "线程申请的资源超出其需要的资源");
				return;
			}
			else
			{
				if (request[0] > available[0] || request[1] > available[1] || request[2] > available[2])
				{
					Console.WriteLine(thread + "线程申请的资源大于系统资源");
					return;
				}
			}
			TryAllocate(thread);
			if (SafetyCheck(thread))
			{ 
				for(int i = 0; i < 3; i++)
				{
					if (allocation[thread, i] != max[thread, i])
					{
						return;
					}
				}
				for(int i = 0; i < 3; i++)
				{
					available[i] += allocation[thread, i];
					allocation[thread, i] = 0;
				}
			}
			else
			{
				RecoverData(thread);
				return;
			}
		}

		public void TryAllocate(int thread)
		{
			for (int i = 0; i < 3; i++)
			{
				available[i] -= request[i];
				allocation[thread, i] += request[i];
				need[thread, i] -= request[i];
			}
		}
   
		public void RecoverData(int thread)
		{
			for (int i = 0; i < 3; i++)
			{
				available[i] += request[i];
				allocation[thread, i] -= request[i];
				need[thread, i] += request[i];
			}
		}

		public bool SafetyCheck(int thread)
		{
			bool[] finish = new bool[5];
			int[] work = new int[4];
			int[] queue = new int[5];
			int k = 0;
			int j = 0;
			int i;
			for (i = 0; i < 5; i++)
				finish[i] = false;
			for (i = 0; i < 3; i++)
			{
				work[i] = available[i];
			}
			while (j < 5)
			{
				for (i = 0; i < 3; i++)
				{
					if (finish[j])
					{
						j++;
						break;
					}
					else if (need[j, i] > work[i])
					{
						j++;
						break;
					}
					else if (i == 2)
					{
						for (int m = 0; m < 3; m++)
						{
							work[m] += allocation[j, m];
						}
						finish[j] = true;
						queue[k] = j;
						k++;
						j = 0;
					}
				}
			}
			for (int p = 0; p < 5; p++)
			{
				if (finish[p] == false)
				{
					Console.WriteLine("系统不安全，资源申请失败");
					return false;
				}
			}
			Console.WriteLine("资源申请成功，安全队列为：");
			for (int q = 0; q < 5; q++)
			{
				Console.WriteLine(queue[q]);
			}
			return true;
		}

		public void showData()
		{
			Console.WriteLine("need");
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine(need[i, 0] + "	" + need[i,1] + "	" + need[i,2]);
			}
			Console.WriteLine("available");
			for (int j = 0; j < 3; j++)
			{
				Console.WriteLine(available[j] + "     ");
			}
		}
	}
}
