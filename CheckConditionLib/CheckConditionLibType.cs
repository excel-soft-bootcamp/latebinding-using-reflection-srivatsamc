using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckConditionLib
{
    public class CheckConditionLibType
    {
        public static void CheckForNullIsClassIsStatic(System.Type levelClassRef, string methodName, object[] argument)
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
                            object result = _methodRef.Invoke(objRef, argument);
                            Console.WriteLine(result.ToString());
                        }
                        else if (methodName == "Start")
                        {
                            object result = _methodRef.Invoke(objRef, argument);
                            Console.WriteLine(result.ToString());
                        }
                        else if (methodName == "Begin")
                        {
                            object result = _methodRef.Invoke(objRef, argument);
                            Console.WriteLine(result.ToString());
                        }
                    }

                }
            }

        }
    }
}
