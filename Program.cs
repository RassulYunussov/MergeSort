using System;
using System.Linq;
namespace ms
{
    class Program
    {
        static void MergeSort(int [] src)
        {
            int [] buff = new int [src.Length];
            ms(0,src.Length);
            void ms(int left,int right)
            {
                int length = right-left;
                int mid = (length)/2;
                int leftSide = left+mid;
                int rightSide = length-mid;
                if(mid>1)
                    ms(left,leftSide);
                if(rightSide>1)
                    ms(leftSide,right);
                int i =0,j=0,k=0;
                while(i<mid&&j<rightSide)
                {
                    if(src[left+i]<src[leftSide+j])
                        buff[k++]=src[left+i++];
                    else
                        buff[k++]=src[leftSide+j++];
                }
                if(i<mid)
                    Buffer.BlockCopy(src,(left+i)*sizeof(int),buff,k*sizeof(int),(mid-i)*sizeof(int));
                if(j<rightSide)
                    Buffer.BlockCopy(src,(leftSide+j)*sizeof(int),buff,k*sizeof(int),(rightSide-j)*sizeof(int));
                Buffer.BlockCopy(buff,0,src,left*sizeof(int),(length)*sizeof(int));
            }
        }
        static void Main(string[] args)
        {
            Random r = new Random();
            int [] a = Enumerable.Range(0,1000)
                                .Select(i=>r.Next(1,1000))
                                .ToArray();
            MergeSort(a);
        }
    }
}
