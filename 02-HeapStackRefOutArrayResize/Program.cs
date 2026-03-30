//1-ci forma


//int[] num1 = { 1, 2, 3 };
//int[] num2 = {4, 5, 6, 7, 8, 9 , 0 };
//ArrSize(ref num1, num2);
//static void ArrSize(ref int[] num1, params int[] num2)
//{
//    int[] newArr = new int[num1.Length + num2.Length];

//    for (int i = 0; i < num1.Length; i++)
//    {
//        newArr[i] = num1[i];
//    }
//    for (int i = 0; i < num2.Length; i++)
//    {
//        newArr[num1.Length + i] = num2[i];
//    }
//    num1 = newArr;
//    for (int i = 0; i < newArr.Length; i++)
//    {
//        Console.WriteLine(newArr[i]);
//    }
//}



//Foreach ile

//int[] num1 = { 1, 2, 3 };
//int[] num2 = {4, 5, 6, 7, 8, 9, 0};

//ArrSize(ref num1, num2);

//static void ArrSize(ref int[] num1, params int[] num2)
//{
//    int[] newArr = new int[num1.Length + num2.Length];
//    int index = 0;

//    foreach (int item in num1)
//    {
//        newArr[index] = item;
//        index++;
//    }

//    foreach (int item in num2)
//    {
//        newArr[index] = item;
//        index++;
//    }

//    num1 = newArr;

//    foreach (int item in newArr)
//    {
//        Console.WriteLine(item);
//    }
//}