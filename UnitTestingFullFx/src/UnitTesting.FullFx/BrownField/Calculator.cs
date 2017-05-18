using System;

namespace UnitTesting.FullFx.BrownField
{
    public class MultiCulturalCalculator
    {
        //TODO: Refactor this code, so it can be unit tested.
        //Note that not all of the tests need to be created.
        //Code has (at least) 2 bugs to fix

        /// <summary>
        /// Calculates stuff.
        /// </summary>
        /// <param name="operandOne"></param>
        /// <param name="operandTwo"></param>
        /// <param name="operator"></param>
        /// <returns></returns>
        public static object CalculateInDutch(int operandOne, int? operandTwo, Operator @operator)
        {
            object result = null;
            if (@operator == Operator.Add)
            {
                if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                result = $"Resultaat is {operandOne + operandTwo} ({DateTime.Now})";
            }
            else
            {
                if (@operator == Operator.Subtract)
                {
                    if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                    if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                    if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                    if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                    if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                    result = $"Resultaat is {operandOne - operandTwo} ({DateTime.Now})";
                }
                else
                {
                    if (@operator == Operator.Pow)
                    {
                        if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                        if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                        if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                        if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                        if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                        result = $"Resultaat is {Math.Pow(operandOne, operandTwo.Value)} ({DateTime.Now})";
                    }
                    else
                    {
                        if (@operator == Operator.Multiply)
                        {
                            if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                            if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                            if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                            if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                            if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                            result = $"Resultaat is {operandOne * operandTwo} ({DateTime.Now})";
                        }
                        else
                        {
                            if (@operator == Operator.Divide)
                            {
                                if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                                if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                                if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                                result = $"Resultaat is {operandOne / operandTwo} ({DateTime.Now})";
                            }
                            else
                            {
                                //single operator:
                                if (@operator == Operator.SquareRoot)
                                {
                                    if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                    if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                    if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                    result = $"Resultaat is {Math.Sqrt(operandOne)} ({DateTime.Now})";
                                }
                                else
                                {
                                    //single operator:
                                    if (@operator == Operator.Sin)
                                    {
                                        if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                        if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                        if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                        result = $"Resultaat is {Math.Sin(operandOne)} ({DateTime.Now})";
                                    }
                                    else
                                    {
                                        //single operator:
                                        if (@operator == Operator.Cos)
                                        {
                                            if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                            if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                            if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                            result = $"Resultaat is {Math.Cos(operandOne)} ({DateTime.Now})";
                                        }
                                        else
                                        {
                                            //single operator:
                                            if (@operator == Operator.Tan)
                                            {
                                                if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                                result = $"Resultaat is {Math.Tan(operandOne)} ({DateTime.Now})";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Calculates stuff.
        /// </summary>
        /// <param name="operandOne"></param>
        /// <param name="operandTwo"></param>
        /// <param name="operator"></param>
        /// <returns></returns>
        public static object CalculateInEnglish(int operandOne, int? operandTwo, Operator @operator)
        {
            object result = null;
            if (@operator == Operator.Add)
            {
                if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                result = $"Result is {operandOne + operandTwo} ({DateTime.Now})";
            }
            else
            {
                if (@operator == Operator.Subtract)
                {
                    if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                    if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                    if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                    if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                    if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                    result = $"Result is {operandOne - operandTwo} ({DateTime.Now})";
                }
                else
                {
                    if (@operator == Operator.Pow)
                    {
                        if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                        if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                        if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                        if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                        if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                        result = $"Result is {Math.Pow(operandOne, operandTwo.Value)} ({DateTime.Now})";
                    }
                    else
                    {
                        if (@operator == Operator.Multiply)
                        {
                            if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                            if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                            if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                            if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                            if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                            result = $"Result is {operandOne * operandTwo} ({DateTime.Now})";
                        }
                        else
                        {
                            if (@operator == Operator.Divide)
                            {
                                if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                                if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                                if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                                result = $"Result is {operandOne / operandTwo} ({DateTime.Now})";
                            }
                            else
                            {
                                //single operator:
                                if (@operator == Operator.SquareRoot)
                                {
                                    if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                    if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                    if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                    result = $"Result is {Math.Sqrt(operandOne)} ({DateTime.Now})";
                                }
                                else
                                {
                                    //single operator:
                                    if (@operator == Operator.Sin)
                                    {
                                        if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                        if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                        if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                        result = $"Result is {Math.Sin(operandOne)} ({DateTime.Now})";
                                    }
                                    else
                                    {
                                        //single operator:
                                        if (@operator == Operator.Cos)
                                        {
                                            if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                            if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                            if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                            result = $"Result is {Math.Cos(operandOne)} ({DateTime.Now})";
                                        }
                                        else
                                        {
                                            //single operator:
                                            if (@operator == Operator.Tan)
                                            {
                                                if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                                result = $"Result is {Math.Tan(operandOne)} ({DateTime.Now})";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Calculates stuff.
        /// </summary>
        /// <param name="operandOne"></param>
        /// <param name="operandTwo"></param>
        /// <param name="operator"></param>
        /// <returns></returns>
        public static object CalculateInGerman(int operandOne, int? operandTwo, Operator @operator)
        {
            object result = null;
            if (@operator == Operator.Add)
            {
                if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                result = $"Ergebnis ist {operandOne + operandTwo} ({DateTime.Now})";
            }
            else
            {
                if (@operator == Operator.Subtract)
                {
                    if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                    if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                    if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                    if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                    if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                    result = $"Ergebnis ist {operandOne - operandTwo} ({DateTime.Now})";
                }
                else
                {
                    if (@operator == Operator.Pow)
                    {
                        if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                        if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                        if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                        if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                        if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                        result = $"Ergebnis ist {Math.Pow(operandOne, operandTwo.Value)} ({DateTime.Now})";
                    }
                    else
                    {
                        if (@operator == Operator.Multiply)
                        {
                            if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                            if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                            if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                            if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                            if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                            result = $"Ergebnis ist {operandOne * operandTwo} ({DateTime.Now})";
                        }
                        else
                        {
                            if (@operator == Operator.Divide)
                            {
                                if (!operandTwo.HasValue) throw new ArgumentNullException(nameof(operandTwo));
                                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");
                                if (operandTwo > 1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Max range is 1000.");
                                if (operandTwo < -1000) throw new ArgumentOutOfRangeException(nameof(operandTwo), "Min range is -1000.");

                                result = $"Ergebnis ist {operandOne / operandTwo} ({DateTime.Now})";
                            }
                            else
                            {
                                //single operator:
                                if (@operator == Operator.SquareRoot)
                                {
                                    if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                    if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                    if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                    result = $"Ergebnis ist {Math.Sqrt(operandOne)} ({DateTime.Now})";
                                }
                                else
                                {
                                    //single operator:
                                    if (@operator == Operator.Sin)
                                    {
                                        if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                        if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                        if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                        result = $"Ergebnis ist {Math.Sin(operandOne)} ({DateTime.Now})";
                                    }
                                    else
                                    {
                                        //single operator:
                                        if (@operator == Operator.Cos)
                                        {
                                            if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                            if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                            if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                            result = $"Ergebnis ist {Math.Cos(operandOne)} ({DateTime.Now})";
                                        }
                                        else
                                        {
                                            //single operator:
                                            if (@operator == Operator.Tan)
                                            {
                                                if (operandTwo.HasValue) throw new InvalidOperationException(nameof(operandTwo));
                                                if (operandOne > 1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Max range is 1000.");
                                                if (operandOne < -1000) throw new ArgumentOutOfRangeException(nameof(operandOne), "Min range is -1000.");

                                                result = $"Ergebnis ist {Math.Tan(operandOne)} ({DateTime.Now})";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
    }

    public enum Operator
    {
        Add,
        Subtract,
        Pow,
        Multiply,
        Divide,
        SquareRoot,
        Sin,
        Cos,
        Tan
    }
}
