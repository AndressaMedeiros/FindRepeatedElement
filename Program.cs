using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] tamanhos = { 10, 100, 1000, 10000, 100000 };
        Random random = new Random();

        Console.Write("Deseja exibir as listas geradas? (s/n): ");

        string resposta = Console.ReadLine()?.Trim().ToLower();
        bool exibir = (resposta == "s" || resposta == "sim");

        Console.WriteLine("Algoritmo\tTempo de execucao (ms)\tMemoria usada (MB)\tNumero repetido");

        foreach (var tam in tamanhos)
        {
            int[] lista = GerarLista(tam, random);
            Console.WriteLine($"\nTamanho: {tam}");

            if (exibir)
                Console.WriteLine("Lista: [" + string.Join(", ", lista) + "]");

            Performance("Forca Bruta", () => FindForcaBruta(lista), tam);
            Performance("Algo. Guloso", () => FindGuloso(lista), tam);
            Performance("Div. Conquista", () => FindDivisaoConquista(lista), tam);
            Performance("Prog. Dinamica", () => FindProgDinamica(lista), tam);
        }
    }

    static int[] GerarLista(int tamanho, Random random)
    {
        int[] lista = new int[tamanho];

        for (int i = 0; i < tamanho; i++)
            lista[i] = random.Next(1, tamanho / 2);

        return lista;
    }

    static void Performance(string metodo, Func<(bool, int?)> algoritmo, int tamanho)
    {
        long memoriaAtual = GC.GetTotalMemory(true);

        Stopwatch stopwatch = Stopwatch.StartNew();

        (bool encontrado, int? numRepetido) = (false, null);

        try
        {
            (encontrado, numRepetido) = algoritmo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro em {metodo}: {ex.Message}");
        }

        stopwatch.Stop();

        long memoriaDepois = GC.GetTotalMemory(true);
        double memoriaUsada = (double)(memoriaDepois - memoriaAtual) / (1024 * 1024);
        double elapsedMilliseconds = stopwatch.Elapsed.TotalMilliseconds;

        Console.WriteLine($"{metodo}\t{elapsedMilliseconds:F4} ms\t{memoriaUsada:F5} MB\t{(encontrado ? numRepetido.ToString() : "Sem repeticao")}");
    }

    static (bool, int?) FindForcaBruta(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
                if (nums[i] == nums[j]) return (true, nums[i]);
        }

        return (false, null);
    }

    static (bool, int?) FindGuloso(int[] nums)
    {
        HashSet<int> check = new HashSet<int>();

        foreach (var num in nums)
        {
            if (check.Contains(num)) return (true, num);
            check.Add(num);
        }
        return (false, null);
    }

    static (bool, int?) FindDivisaoConquista(int[] nums)
    {

        (bool, int?) RecurFind(int[] lista, int left, int right)
        {
            if (right <= left) return (false, null);

            int pontoMedio = (left + right) / 2;

            var leftResult = RecurFind(lista, left, pontoMedio);
            var rightResult = RecurFind(lista, pontoMedio + 1, right);

            if (leftResult.Item1) return leftResult;
            if (rightResult.Item1) return rightResult;

            HashSet<int> check = new HashSet<int>();

            for (int i = left; i <= pontoMedio; i++)
            {
                if (check.Contains(lista[i])) return (true, lista[i]);
                check.Add(lista[i]);
            }

            for (int i = pontoMedio + 1; i <= right; i++)
            {
                if (check.Contains(lista[i])) return (true, lista[i]);
                check.Add(lista[i]);
            }

            return (false, null);
        }

        return RecurFind(nums, 0, nums.Length - 1);
    }

    static (bool, int?) FindProgDinamica(int[] nums)
    {
        Dictionary<int, bool> dic = new Dictionary<int, bool>();

        foreach (var num in nums)
        {
            if (dic.ContainsKey(num)) return (true, num);
            dic[num] = true;
        }

        return (false, null);
    }
}
