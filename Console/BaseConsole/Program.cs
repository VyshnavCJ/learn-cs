// Random dice = new Random();
// int roll = dice.Next(1, 7);
// Console.WriteLine(roll);
string[] f = new string[10];
foreach (string name in f)
{
    Console.WriteLine(f.Length);
}
string value = "bad";
int result = 0;
if (int.TryParse(value, out result))
{
    Console.WriteLine($"Measurement: {result}");
}
else
{
    Console.WriteLine("Unable to report the measurement.");
}

if (result > 0)
    Console.WriteLine($"Measurement (w/ offset): {50 + result}");

var hello = Console.ReadLine();
Console.WriteLine(hello);
MyMethod();
void MyMethod()
{
    Console.WriteLine("hello freinds");
}
void quick_sort(int[] arr, int left, int right)
{
    int pivot = arr[(left + right) / 2];
    int i = left;
    int j = right;
    while (i <= j)
    {
        while (arr[i] < pivot)
            i++;
        while (arr[j] > pivot)
            j--;
        if (i <= j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }
    }
    if (left < j)
        quick_sort(arr, left, j);
    if (i < right)
        quick_sort(arr, i, right);
}
try
{
    throw new Exception("hello");
}
catch (System.Exception e)
{
    Console.WriteLine(e.Message);
}
