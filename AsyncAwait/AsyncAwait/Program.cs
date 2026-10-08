// These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
internal class HashBrown { }
internal class Coffee { }
internal class Egg { }
internal class Juice { }
internal class Toast { }

class Program
{
    static async Task Main(string[] args)
    {
        //ChamadaSincrona();
        await ChamadaAssincrona(args);
    }

    private static async Task ChamadaAssincrona(string[] args)
    {
        Coffee cup = PourCoffee();
        Console.WriteLine("coffee is ready");

        //Chama esses 3 métodos em paralelo
        var eggsTask = FryEggsAsync(2);
        var hashBrownTask = FryHashBrownsAsync(3);
        var toastTask = MakeToastWithButterAndJamAsync(2);

        //Somente nesse ponto a rotina espera para obter o resultado
        var eggs = await eggsTask;
        Console.WriteLine("eggs are ready");

        var hashBrown = await hashBrownTask;
        Console.WriteLine("hash browns are ready");

        var toast = await toastTask;
        Console.WriteLine("toast is ready");

        Juice oj = PourOJ();
        Console.WriteLine("oj is ready");
        Console.WriteLine("Breakfast is ready!");
    }

    private static void ChamadaSincrona()
    {
        Coffee cup = PourCoffee();
        Console.WriteLine("coffee is ready");

        Egg eggs = FryEggs(2);
        Console.WriteLine("eggs are ready");

        HashBrown hashBrown = FryHashBrowns(3);
        Console.WriteLine("hash browns are ready");

        Toast toast = ToastBread(2);
        ApplyButter(toast);
        ApplyJam(toast);
        Console.WriteLine("toast is ready");

        Juice oj = PourOJ();
        Console.WriteLine("oj is ready");
        Console.WriteLine("Breakfast is ready!");
    }

    static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
    {
        var toast = await ToastBreadAsync(number);
        ApplyButter(toast);
        ApplyJam(toast);

        return toast;
    }

    private static async Task<Toast> ToastBreadAsync(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("Putting a slice of bread in the toaster");
        }
        Console.WriteLine("Start toasting...");
        await Task.Delay(3000);
        Console.WriteLine("Remove toast from toaster");

        return new Toast();
    }

    private static async Task<HashBrown> FryHashBrownsAsync(int patties)
    {
        Console.WriteLine($"putting {patties} hash brown patties in the pan");
        Console.WriteLine("cooking first side of hash browns...");
        await Task.Delay(3000);
        for (int patty = 0; patty < patties; patty++)
        {
            Console.WriteLine("flipping a hash brown patty");
        }
        Console.WriteLine("cooking the second side of hash browns...");
        await Task.Delay(3000);
        Console.WriteLine("Put hash browns on plate");

        return new HashBrown();
    }

    private static async Task<Egg> FryEggsAsync(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");
        await Task.Delay(3000);
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine("cooking the eggs ...");
        await Task.Delay(3000);
        Console.WriteLine("Put eggs on plate");

        return new Egg();
    }

    private static Juice PourOJ()
    {
        Console.WriteLine("Pouring orange juice");
        return new Juice();
    }

    private static void ApplyJam(Toast toast) =>
        Console.WriteLine("Putting jam on the toast");

    private static void ApplyButter(Toast toast) =>
        Console.WriteLine("Putting butter on the toast");

    private static Toast ToastBread(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("Putting a slice of bread in the toaster");
        }
        Console.WriteLine("Start toasting...");
        Task.Delay(3000).Wait();
        Console.WriteLine("Remove toast from toaster");

        return new Toast();
    }

    private static HashBrown FryHashBrowns(int patties)
    {
        Console.WriteLine($"putting {patties} hash brown patties in the pan");
        Console.WriteLine("cooking first side of hash browns...");
        Task.Delay(3000).Wait();
        for (int patty = 0; patty < patties; patty++)
        {
            Console.WriteLine("flipping a hash brown patty");
        }
        Console.WriteLine("cooking the second side of hash browns...");
        Task.Delay(3000).Wait();
        Console.WriteLine("Put hash browns on plate");

        return new HashBrown();
    }

    private static Egg FryEggs(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");
        Task.Delay(3000).Wait();
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine("cooking the eggs ...");
        Task.Delay(3000).Wait();
        Console.WriteLine("Put eggs on plate");

        return new Egg();
    }

    private static Coffee PourCoffee()
    {
        Console.WriteLine("Pouring coffee");
        return new Coffee();
    }
}