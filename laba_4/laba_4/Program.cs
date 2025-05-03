using System;

class Program
{
    enum State { q0, q1, q2 }

    static bool IsAccepted(string input)
    {
        State state = State.q0;

        foreach (char ch in input)
        {
            switch (state)
            {
                case State.q0:
                    state = ch switch
                    {
                        'a' => State.q1,
                        'b' => State.q0,
                        'c' => State.q2,
                        'd' => State.q2,
                        _ => throw new ArgumentException($"Недопустимый символ: {ch}")
                    };
                    break;

                case State.q1:
                    state = ch switch
                    {
                        'a' => State.q1,
                        'b' => State.q0,
                        'c' => State.q2,
                        'd' => State.q2,
                        _ => throw new ArgumentException($"Недопустимый символ: {ch}")
                    };
                    break;

                case State.q2:
                    state = ch switch
                    {
                        'a' => State.q2,
                        'b' => State.q2,
                        'c' => State.q0,
                        'd' => State.q0,
                        _ => throw new ArgumentException($"Недопустимый символ: {ch}")
                    };
                    break;
            }
        }

        return state == State.q0;
    }

    static void Main()
    {
        while ( true )
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

            try
            {
                bool accepted = IsAccepted(input);
                Console.WriteLine(accepted ? "Строка принята" : "Строка отвергнута");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

    }
}
