using System;

namespace UnitTesting.FullFx.BrownField
{
    public class MultiCulturalCalculator
    {
        //TODO: Refactor this code, so it can be unit tested.
        //Goal: the ability to add a language without adding tests
        //Note that not all of the tests need to be created.
        //Code has (at least) 2 bugs to fix

        public static object Calculate(string language, int operandOne, int? operandTwo, Operator @operator)
        {
            object result = null;

            if (language == "NL")
            {
                int operandOne1 = operandOne;
                int? operandTwo1 = operandTwo;
                object result1 = null;
                if (@operator == Operator.Add)
                {
                    if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                    if (operandOne1 > 1000)
                        throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                    if (operandOne1 < -1000)
                        throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                    if (operandTwo1 > 1000)
                        throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                    if (operandTwo1 < -1000)
                        throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                    result1 = $"Resultaat is {operandOne1 + operandTwo1} ({DateTime.Now})";
                }
                else
                {
                    if (@operator == Operator.Subtract)
                    {
                        if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                        if (operandOne1 > 1000)
                            throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                        if (operandOne1 < -1000)
                            throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                        if (operandTwo1 > 1000)
                            throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                        if (operandTwo1 < -1000)
                            throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                        result1 = $"Resultaat is {operandOne1 - operandTwo1} ({DateTime.Now})";
                    }
                    else
                    {
                        if (@operator == Operator.Pow)
                        {
                            if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                            if (operandOne1 > 1000)
                                throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                            if (operandOne1 < -1000)
                                throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                            if (operandTwo1 > 1000)
                                throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                            if (operandTwo1 < -1000)
                                throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                            result1 = $"Resultaat is {Math.Pow(operandOne1, operandTwo1.Value)} ({DateTime.Now})";
                        }
                        else
                        {
                            if (@operator == Operator.Multiply)
                            {
                                if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                if (operandOne1 > 1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                        "Max range is 1000.");
                                if (operandOne1 < -1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                        "Min range is -1000.");
                                if (operandTwo1 > 1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                        "Max range is 1000.");
                                if (operandTwo1 < -1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                        "Min range is -1000.");

                                result1 = $"Resultaat is {operandOne1 * operandTwo1} ({DateTime.Now})";
                            }
                            else
                            {
                                if (@operator == Operator.Divide)
                                {
                                    if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                    if (operandOne1 > 1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                            "Max range is 1000.");
                                    if (operandOne1 < -1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                            "Min range is -1000.");
                                    if (operandTwo1 > 1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                            "Max range is 1000.");
                                    if (operandTwo1 < -1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                            "Min range is -1000.");

                                    result1 = $"Resultaat is {operandOne1 / operandTwo1} ({DateTime.Now})";
                                }
                                else
                                {
                                    //single operator:
                                    if (@operator == Operator.SquareRoot)
                                    {
                                        if (operandTwo1.HasValue)
                                            throw new InvalidOperationException(nameof(operandTwo1));
                                        if (operandOne1 > 1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                "Max range is 1000.");
                                        if (operandOne1 < -1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                "Min range is -1000.");

                                        result1 = $"Resultaat is {Math.Sqrt(operandOne1)} ({DateTime.Now})";
                                    }
                                    else
                                    {
                                        //single operator:
                                        if (@operator == Operator.Sin)
                                        {
                                            if (operandTwo1.HasValue)
                                                throw new InvalidOperationException(nameof(operandTwo1));
                                            if (operandOne1 > 1000)
                                                throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                    "Max range is 1000.");
                                            if (operandOne1 < -1000)
                                                throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                    "Min range is -1000.");

                                            result1 = $"Resultaat is {Math.Sin(operandOne1)} ({DateTime.Now})";
                                        }
                                        else
                                        {
                                            //single operator:
                                            if (@operator == Operator.Cos)
                                            {
                                                if (operandTwo1.HasValue)
                                                    throw new InvalidOperationException(nameof(operandTwo1));
                                                if (operandOne1 > 1000)
                                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                        "Max range is 1000.");
                                                if (operandOne1 < -1000)
                                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                        "Min range is -1000.");

                                                result1 = $"Resultaat is {Math.Cos(operandOne1)} ({DateTime.Now})";
                                            }
                                            else
                                            {
                                                //single operator:
                                                if (@operator == Operator.Tan)
                                                {
                                                    if (operandTwo1.HasValue)
                                                        throw new InvalidOperationException(nameof(operandTwo1));
                                                    if (operandOne1 > 1000)
                                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                            "Max range is 1000.");
                                                    if (operandOne1 < -1000)
                                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                            "Min range is -1000.");

                                                    result1 =
                                                        $"Resultaat is {Math.Tan(operandOne1)} ({DateTime.Now})";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                result = result1;
            }
            else if (language == "EN")
            {
                {
                    int operandOne1 = operandOne;
                    int? operandTwo1 = operandTwo;
                    object result1 = null;
                    if (@operator == Operator.Add)
                    {
                        if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                        if (operandOne1 > 1000)
                            throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                        if (operandOne1 < -1000)
                            throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                        if (operandTwo1 > 1000)
                            throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                        if (operandTwo1 < -1000)
                            throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                        result1 = $"Result is {operandOne1 + operandTwo1} ({DateTime.Now})";
                    }
                    else
                    {
                        if (@operator == Operator.Subtract)
                        {
                            if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                            if (operandOne1 > 1000)
                                throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                            if (operandOne1 < -1000)
                                throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                            if (operandTwo1 > 1000)
                                throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                            if (operandTwo1 < -1000)
                                throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                            result1 = $"Result is {operandOne1 - operandTwo1} ({DateTime.Now})";
                        }
                        else
                        {
                            if (@operator == Operator.Pow)
                            {
                                if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                if (operandOne1 > 1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                                if (operandOne1 < -1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                                if (operandTwo1 > 1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                                if (operandTwo1 < -1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                                result1 = $"Result is {Math.Pow(operandOne1, operandTwo1.Value)} ({DateTime.Now})";
                            }
                            else
                            {
                                if (@operator == Operator.Multiply)
                                {
                                    if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                    if (operandOne1 > 1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                            "Max range is 1000.");
                                    if (operandOne1 < -1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                            "Min range is -1000.");
                                    if (operandTwo1 > 1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                            "Max range is 1000.");
                                    if (operandTwo1 < -1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                            "Min range is -1000.");

                                    result1 = $"Result is {operandOne1 * operandTwo1} ({DateTime.Now})";
                                }
                                else
                                {
                                    if (@operator == Operator.Divide)
                                    {
                                        if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                        if (operandOne1 > 1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                "Max range is 1000.");
                                        if (operandOne1 < -1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                "Min range is -1000.");
                                        if (operandTwo1 > 1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                                "Max range is 1000.");
                                        if (operandTwo1 < -1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                                "Min range is -1000.");

                                        result1 = $"Result is {operandOne1 / operandTwo1} ({DateTime.Now})";
                                    }
                                    else
                                    {
                                        //single operator:
                                        if (@operator == Operator.SquareRoot)
                                        {
                                            if (operandTwo1.HasValue)
                                                throw new InvalidOperationException(nameof(operandTwo1));
                                            if (operandOne1 > 1000)
                                                throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                    "Max range is 1000.");
                                            if (operandOne1 < -1000)
                                                throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                    "Min range is -1000.");

                                            result1 = $"Result is {Math.Sqrt(operandOne1)} ({DateTime.Now})";
                                        }
                                        else
                                        {
                                            //single operator:
                                            if (@operator == Operator.Sin)
                                            {
                                                if (operandTwo1.HasValue)
                                                    throw new InvalidOperationException(nameof(operandTwo1));
                                                if (operandOne1 > 1000)
                                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                        "Max range is 1000.");
                                                if (operandOne1 < -1000)
                                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                        "Min range is -1000.");

                                                result1 = $"Result is {Math.Sin(operandOne1)} ({DateTime.Now})";
                                            }
                                            else
                                            {
                                                //single operator:
                                                if (@operator == Operator.Cos)
                                                {
                                                    if (operandTwo1.HasValue)
                                                        throw new InvalidOperationException(nameof(operandTwo1));
                                                    if (operandOne1 > 1000)
                                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                            "Max range is 1000.");
                                                    if (operandOne1 < -1000)
                                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                            "Min range is -1000.");

                                                    result1 = $"Result is {Math.Cos(operandOne1)} ({DateTime.Now})";
                                                }
                                                else
                                                {
                                                    //single operator:
                                                    if (@operator == Operator.Tan)
                                                    {
                                                        if (operandTwo1.HasValue)
                                                            throw new InvalidOperationException(nameof(operandTwo1));
                                                        if (operandOne1 > 1000)
                                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                                "Max range is 1000.");
                                                        if (operandOne1 < -1000)
                                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                                "Min range is -1000.");

                                                        result1 = $"Result is {Math.Tan(operandOne1)} ({DateTime.Now})";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    result = result1;
                }
            }
            else if (language == "DE")
            {
                {
                    int operandOne1 = operandOne;
                    int? operandTwo1 = operandTwo;
                    object result1 = null;
                    if (@operator == Operator.Add)
                    {
                        if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                        if (operandOne1 > 1000)
                            throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                        if (operandOne1 < -1000)
                            throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                        if (operandTwo1 > 1000)
                            throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                        if (operandTwo1 < -1000)
                            throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                        result1 = $"Ergebnis ist {operandOne1 + operandTwo1} ({DateTime.Now})";
                    }
                    else
                    {
                        if (@operator == Operator.Subtract)
                        {
                            if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                            if (operandOne1 > 1000)
                                throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                            if (operandOne1 < -1000)
                                throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                            if (operandTwo1 > 1000)
                                throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                            if (operandTwo1 < -1000)
                                throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                            result1 = $"Ergebnis ist {operandOne1 - operandTwo1} ({DateTime.Now})";
                        }
                        else
                        {
                            if (@operator == Operator.Pow)
                            {
                                if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                if (operandOne1 > 1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandOne1), "Max range is 1000.");
                                if (operandOne1 < -1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandOne1), "Min range is -1000.");
                                if (operandTwo1 > 1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Max range is 1000.");
                                if (operandTwo1 < -1000)
                                    throw new ArgumentOutOfRangeException(nameof(operandTwo1), "Min range is -1000.");

                                result1 = $"Ergebnis ist {Math.Pow(operandOne1, operandTwo1.Value)} ({DateTime.Now})";
                            }
                            else
                            {
                                if (@operator == Operator.Multiply)
                                {
                                    if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                    if (operandOne1 > 1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                            "Max range is 1000.");
                                    if (operandOne1 < -1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                            "Min range is -1000.");
                                    if (operandTwo1 > 1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                            "Max range is 1000.");
                                    if (operandTwo1 < -1000)
                                        throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                            "Min range is -1000.");

                                    result1 = $"Ergebnis ist {operandOne1 * operandTwo1} ({DateTime.Now})";
                                }
                                else
                                {
                                    if (@operator == Operator.Divide)
                                    {
                                        if (!operandTwo1.HasValue) throw new ArgumentNullException(nameof(operandTwo1));
                                        if (operandOne1 > 1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                "Max range is 1000.");
                                        if (operandOne1 < -1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                "Min range is -1000.");
                                        if (operandTwo1 > 1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                                "Max range is 1000.");
                                        if (operandTwo1 < -1000)
                                            throw new ArgumentOutOfRangeException(nameof(operandTwo1),
                                                "Min range is -1000.");

                                        result1 = $"Ergebnis ist {operandOne1 / operandTwo1} ({DateTime.Now})";
                                    }
                                    else
                                    {
                                        //single operator:
                                        if (@operator == Operator.SquareRoot)
                                        {
                                            if (operandTwo1.HasValue)
                                                throw new InvalidOperationException(nameof(operandTwo1));
                                            if (operandOne1 > 1000)
                                                throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                    "Max range is 1000.");
                                            if (operandOne1 < -1000)
                                                throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                    "Min range is -1000.");

                                            result1 = $"Ergebnis ist {Math.Sqrt(operandOne1)} ({DateTime.Now})";
                                        }
                                        else
                                        {
                                            //single operator:
                                            if (@operator == Operator.Sin)
                                            {
                                                if (operandTwo1.HasValue)
                                                    throw new InvalidOperationException(nameof(operandTwo1));
                                                if (operandOne1 > 1000)
                                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                        "Max range is 1000.");
                                                if (operandOne1 < -1000)
                                                    throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                        "Min range is -1000.");

                                                result1 = $"Ergebnis ist {Math.Sin(operandOne1)} ({DateTime.Now})";
                                            }
                                            else
                                            {
                                                //single operator:
                                                if (@operator == Operator.Cos)
                                                {
                                                    if (operandTwo1.HasValue)
                                                        throw new InvalidOperationException(nameof(operandTwo1));
                                                    if (operandOne1 > 1000)
                                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                            "Max range is 1000.");
                                                    if (operandOne1 < -1000)
                                                        throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                            "Min range is -1000.");

                                                    result1 = $"Ergebnis ist {Math.Cos(operandOne1)} ({DateTime.Now})";
                                                }
                                                else
                                                {
                                                    //single operator:
                                                    if (@operator == Operator.Tan)
                                                    {
                                                        if (operandTwo1.HasValue)
                                                            throw new InvalidOperationException(nameof(operandTwo1));
                                                        if (operandOne1 > 1000)
                                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                                "Max range is 1000.");
                                                        if (operandOne1 < -1000)
                                                            throw new ArgumentOutOfRangeException(nameof(operandOne1),
                                                                "Min range is -1000.");

                                                        result1 =
                                                            $"Ergebnis ist {Math.Tan(operandOne1)} ({DateTime.Now})";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    result = result1;
                }
            }
            else throw new ArgumentOutOfRangeException(nameof(language), "Languages supported: NL, EN, DE.");
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
