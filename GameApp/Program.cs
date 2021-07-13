using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    public enum Options
    {
        BASIC=1,INTERMEDIATE,ADVANCED
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Word Guess Game");
            
           
            string displayMessage = $"Enter Your Choice {(int)Options.BASIC}->Basic,{(int)Options.INTERMEDIATE}->Intermediate,{(int)Options.ADVANCED}->Advanced";
            Console.WriteLine(displayMessage);
            do
            {
                try
                {
                    Options _choice = (Options)Int32.Parse(Console.ReadLine());
                    int choice = (int)_choice;
                    if (_choice == Options.BASIC || _choice == Options.INTERMEDIATE || _choice == Options.ADVANCED)
                    {
                        switch (_choice)
                        {
                            case Options.BASIC:
                                Console.WriteLine("Basic Level");
                                System.Reflection.Assembly basicLevelLib =
                                System.Reflection.Assembly.LoadFile(@"C:\Users\srivatsa.mc\Documents\GitHub\latebinding-using-reflection-srivatsamc\GameApp\bin\Debug\LevelLibs\BasicLevelLib.dll");

                                System.Type basicLevelTypeClassRef = basicLevelLib.GetType("BasicLevelLib.BasicLevelType");
                                CheckForNullIsClassIsStatic(basicLevelTypeClassRef, "Play");

                                break;

                            case Options.INTERMEDIATE:
                                Console.WriteLine("Intermediate Level");

                                System.Reflection.Assembly intermediateLevelLib =
                                System.Reflection.Assembly.LoadFile(@"C:\Users\srivatsa.mc\Documents\GitHub\latebinding-using-reflection-srivatsamc\GameApp\bin\Debug\LevelLibs\IntermediateLevelLib.dll");

                                System.Type intermediateLevelTypeClassRef = intermediateLevelLib.GetType("IntermediateLevelLib.IntermediateLevelType");
                                CheckForNullIsClassIsStatic(intermediateLevelTypeClassRef,"Start");

                                break;

                            case Options.ADVANCED:
                                Console.WriteLine("Advanced Level");

                                System.Reflection.Assembly advancedLevelLib =
                                System.Reflection.Assembly.LoadFile(@"C:\Users\srivatsa.mc\Documents\GitHub\latebinding-using-reflection-srivatsamc\GameApp\bin\Debug\LevelLibs\AdvancedLevelLib.dll");

                                System.Type advancedLevelTypeClassRef = advancedLevelLib.GetType("AdvancedLevelLib.AdvancedLevelType");
                                CheckForNullIsClassIsStatic(advancedLevelTypeClassRef, "Begin");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                catch (SystemException)
                {
                    Console.WriteLine("Choice should be number");
                }
            } while (true);

               
        }
        public static void CheckForNullIsClassIsStatic(System.Type levelClassRef, string methodName)
        {
            if (levelClassRef != null)
            {
                if (levelClassRef.IsClass)
                {
                    Object objRef = System.Activator.CreateInstance(levelClassRef);
                    System.Reflection.MethodInfo _methodRef = levelClassRef.GetMethod(methodName);
                    
                    if (!_methodRef.IsStatic)
                    {
                        if (methodName == "Play")
                        {
                            object result = _methodRef.Invoke(objRef, new object[] { });
                            Console.WriteLine(result.ToString());
                        }
                        else if (methodName == "Start")
                        {
                            object result = _methodRef.Invoke(objRef, new object[] {"Srivatsa" });
                            Console.WriteLine(result.ToString());
                        }
                        else if (methodName == "Begin")
                        {
                            object result = _methodRef.Invoke(objRef, new object[] {"Srivatsa",100});
                            Console.WriteLine(result.ToString());
                        }
                    }

                }
            }
            
        }
       



        

    }
}
