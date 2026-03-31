namespace _09_UpcastingDowncastingExplicitImplicit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Upcasting
            //Dog dog = new Dog {  AvgLifeTime = 10,Breed ="Afqacka",Gender="male",Name ="alabas"};
            //Eagle eagle = new Eagle { AvgLifeTime =50,FlySpeed=100,Gender ="famale"};

            //////UpCASTING 
            ////Animals animals = dog;
            ////Animals animals2 = eagle;


            ////Downcasting
            ////Dog dog1 = (Dog )animals;
            ////Eagle eagle1 = animals2 as Eagle ; 


            //Animals[] animals = { eagle ,dog ,};
            //foreach (var animal in animals)
            //{
            //    Eagle eagle1 =animal as Eagle;
            //    //eagle1.Fly();

            //    //if ( eagle1 != null)
            //    //{
            //    //    eagle1.Fly();
            //    //}
            //    if ( animal is Eagle )
            //    {
            //        eagle1.Fly();
            //    }
            //} 
            #endregion


            #region Boxing
            ////boxing
            //int a = 5;
            //Object b = a;


            ////unboxing
            //int c = (int)b; 
            #endregion

           

        }
    }
}
