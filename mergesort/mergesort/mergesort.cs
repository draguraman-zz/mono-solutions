/*MergeSort - By: Vladimir Sutskever
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace mergesort{
	class Program {
        public static void  Main( string[] args ) {
            MergeSorter oSorter = new MergeSorter();
            //--------------------------------------
            //Create Array List, add some numbers
            //--------------------------------------
            ArrayList arrayUnsorted= new ArrayList();
            arrayUnsorted.Add(1);
            arrayUnsorted.Add(33);
            arrayUnsorted.Add(4);
            arrayUnsorted.Add(43);
			   arrayUnsorted.Add(3);
			   arrayUnsorted.Add(35);   arrayUnsorted.Add(243);    arrayUnsorted.Add(-43);    arrayUnsorted.Add(14);
            //--------------------------------------
            //Sort
            //--------------------------------------
            ArrayList arraySorted = oSorter.MergeSort(arrayUnsorted);
            //--------------------------------------
            //Print
            //--------------------------------------
            foreach (int i in arraySorted) {
                Console.WriteLine(i);
            }
            
        }
    }
    class MergeSorter{
        //==================================================
        //Constructor
        //==================================================
        public MergeSorter(){
        }
        //==================================================
        // MergeSort
        //==================================================
        public ArrayList MergeSort ( ArrayList arrIntegers ) {
            if (arrIntegers.Count == 1) {
                return arrIntegers;
            }
            ArrayList arrSortedInt = new ArrayList();
            int middle = (int)arrIntegers.Count/2;
            ArrayList leftArray = arrIntegers.GetRange(0, middle);
            ArrayList rightArray = arrIntegers.GetRange(middle, arrIntegers.Count - middle);
            leftArray =  MergeSort(leftArray);
            rightArray = MergeSort(rightArray);
            int leftptr = 0;
            int rightptr=0;
            for (int i = 0; i < leftArray.Count + rightArray.Count; i++) {
                if (leftptr==leftArray.Count){
                    arrSortedInt.Add(rightArray[rightptr]);
                    rightptr++;
                }else if (rightptr==rightArray.Count){
                    arrSortedInt.Add(leftArray[leftptr]);
                    leftptr++;
                }else if ((int)leftArray[leftptr]<(int)rightArray[rightptr]){
                    //need the cast above since arraylist returns Type object
                    arrSortedInt.Add(leftArray[leftptr]);
                    leftptr++;
                }else{
                    arrSortedInt.Add(rightArray[rightptr]);
                    rightptr++;
                }
            }
            return arrSortedInt;
        }

    }
}
